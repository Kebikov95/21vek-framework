using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Main.Framework.Browser
{
    class WebDriverFactory
    {
        private WebDriverFactory() { }

        public static IWebDriver GetWebDriver(BrowserTypes type)
        {
            IWebDriver driver = null;
            string pathToDriver = @"..\..\..\..\Framework\Resources\Drivers";

            switch (type)
            {
                case BrowserTypes.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(pathToDriver);
                    break;
                case BrowserTypes.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(pathToDriver);
                    break;
                case BrowserTypes.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver(pathToDriver);
                    break;
                default:
                    throw new ArgumentNullException("Unexpected browser type");
            }
            return driver;
        }
    }
}
