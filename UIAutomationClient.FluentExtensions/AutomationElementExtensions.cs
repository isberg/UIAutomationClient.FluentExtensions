using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions
{
    public static class AutomationElementExtensions
    {
        public static AutomationElement FindFirstChild(this AutomationElement element, Condition condition)
        {
            return element.FindFirst(TreeScope.Children, condition);
        }

        public static IEnumerable<AutomationElement> FindAllChildren(this AutomationElement element, Condition condition = null)
        {
            return element
                .FindAll(TreeScope.Children, condition ?? Condition.TrueCondition)
                .Cast<AutomationElement>();
        }

        public static AutomationElement FindFirstDescendant(this AutomationElement element, Condition condition)
        {
            return element.FindFirst(TreeScope.Descendants, condition);
        }

        public static IEnumerable<AutomationElement> FindAllDescendants(this AutomationElement element, Condition condition = null)
        {
            return element
                .FindAll(TreeScope.Descendants, condition ?? Condition.TrueCondition)
                .Cast<AutomationElement>();
        }

        public static T GetCurrentPattern<T>(this AutomationElement element)
            where T : BasePattern
        {
            var pattern = (AutomationPattern)typeof(T)
                .GetField("Pattern")
                .GetValue(null);

            return (T)element.GetCurrentPattern(pattern);
        }

        public static AutomationElement Pattern<T>(this AutomationElement element, Action<T> action)
            where T : BasePattern
        {
            var pattern = element.GetCurrentPattern<T>();

            action(pattern);

            return element;
        }

        public static AutomationElement SendKeys(this AutomationElement element, string keys)
        {
            element.SetFocus();
            System.Windows.Forms.SendKeys.SendWait(keys);
            return element;
        }
    }
}
