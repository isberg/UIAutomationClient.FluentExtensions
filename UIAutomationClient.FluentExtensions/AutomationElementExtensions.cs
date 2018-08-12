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
    }
}
