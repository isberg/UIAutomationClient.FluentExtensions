using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions
{
    public static class AutomationElementExtensions
    {
        public static AutomationElement FindFirstChild(this AutomationElement element, Condition condition)
        {
            return element.FindFirst(TreeScope.Children, condition);
        }
    }
}
