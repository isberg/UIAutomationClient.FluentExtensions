using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Windows.Automation;

namespace UIAutomationClient.FluentExtensions.Tests
{
    public class ProcessExtensionsTests
    {
        private Process sut;

        [SetUp]
        public void Setup()
        {
            sut = Process.Start("notepad");
        }

        [TearDown]
        public void Cleanup()
        {
            try
            {
                sut.WaitForInputIdle(200);
                sut.CloseMainWindow();
                sut.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception in Cleanup(): {ex.Message}");
            }
        }

        [Test]
        public void GetMainWindow_Should_Return_MainWindowAutomationElement()
        {          
            sut.WaitForInputIdle(500);

            AutomationElement window = sut.GetMainWindow();

            window.Current.NativeWindowHandle.Should().Be(sut.MainWindowHandle.ToInt32());
        }

        [Test]
        public void GetMainWindow_Should_WaitForInputIdle()
        {
            AutomationElement window = sut.GetMainWindow();

            window.Current.NativeWindowHandle.Should().NotBe(0);
        }
    }
}
