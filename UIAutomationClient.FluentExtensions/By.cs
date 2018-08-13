using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions
{
    public static class By
    {
        public static Condition Name(string value)
            => new PropertyCondition(AutomationElement.NameProperty, value);

        public static Condition ClassName(string value)
            => new PropertyCondition(AutomationElement.ClassNameProperty, value);

        public static Condition AutomationId(string value)
            => new PropertyCondition(AutomationElement.AutomationIdProperty, value);

    }
}
