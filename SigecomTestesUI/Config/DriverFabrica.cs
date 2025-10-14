using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace SigecomTestesUI.Config
{
    public class DriverFabrica
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string AppId = @"C:\SIGECOM\SIGECOM.exe";

        public WindowsDriver<WindowsElement> CriarDriver()
        {
            AbrirWinAppDriver();

            var appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", AppId);
            var driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appOptions);
            Assert.NotNull(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }

        public void AbrirWinAppDriver()
        {
            const string WinAppDriver = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
            Process.Start(WinAppDriver);
        }
    }
}
