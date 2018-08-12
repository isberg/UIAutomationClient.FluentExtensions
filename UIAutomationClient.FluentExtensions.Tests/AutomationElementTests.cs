using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions.Tests
{
    public class AutomationElementTests
    {
        private Process process;
        private AutomationElement sut;

        [SetUp]
        public void Setup()
        {
            process = Process.Start("notepad");
            sut = process.GetMainWindow();
        }

        [TearDown]
        public void Cleanup()
        {
            try
            {
                process.WaitForInputIdle();
                process.CloseMainWindow();
                sut.SendKeys("n");
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during Cleanup(): {ex.Message}");
            }
        }

        [Test]
        public void FindFirstChild()
        {
            sut.FindFirstChild(Condition.TrueCondition);
        }

        [Test]
        public void FindAllChildrenWithCondition()
        {
            IEnumerable<AutomationElement> children 
                = sut.FindAllChildren(Condition.TrueCondition);
        }

        [Test]
        public void FindAllChildrenWithoutCondition()
        {
            IEnumerable<AutomationElement> children 
                = sut.FindAllChildren();
        }

        [Test]
        public void FindAllChildrenWithNullCondition()
        {
            IEnumerable<AutomationElement> children
                = sut.FindAllChildren(null);
        }

        [Test]
        public void FindFirstDescendant()
        {
            sut.FindFirstDescendant(Condition.TrueCondition);
        }

        [Test]
        public void FindAllFirstDescendantsWithCondition()
        {
            IEnumerable<AutomationElement> children
                = sut.FindAllDescendants(Condition.TrueCondition);
        }

        [Test]
        public void FindAllFirstDescendantsWithoutCondition()
        {
            IEnumerable<AutomationElement> children
                = sut.FindAllDescendants();
        }

        [Test]
        public void FindAllFirstDescendantsWithNullCondition()
        {
            IEnumerable<AutomationElement> children
                = sut.FindAllDescendants(null);
        }

        [Test]
        public void Pattern()
        {
            sut.Pattern<WindowPattern>(x => x.Close());
        }

        [Test]
        public void SendKeys()
        {
            sut.SendKeys("Yoh!{ENTER}Bye!");
        }
    }
}
