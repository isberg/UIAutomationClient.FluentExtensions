using NUnit.Framework;
using System.Diagnostics;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions.Tests
{
    public class AutomationElementTests
    {
        private AutomationElement sut;

        [SetUp]
        public void Setup()
        {
            sut = Process.Start("notepad").GetMainWindow();
        }

        [Test]
        public void FindFirstChild()
        {
            sut.FindFirstChild(Condition.TrueCondition);
        }
    }
}
