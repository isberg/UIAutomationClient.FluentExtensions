using System.Diagnostics;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions
{
    public static class AutomationElementExtensions
    {
        public static AutomationElement GetMainWindow(this Process process)
        {
            process.WaitForInputIdle();
            return AutomationElement.FromHandle(process.MainWindowHandle);
        }
    }
}
