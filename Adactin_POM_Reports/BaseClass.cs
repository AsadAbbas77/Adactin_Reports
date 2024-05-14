using System;
using System.Drawing;
using Allure.Net.Commons;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Adactin_POM_Reports
{
	public class BaseClass
	{

        public static IWebDriver myDriver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        public static void seleniumInt(string url)
        {
            var driver = new FirefoxDriver();
            myDriver = driver;
            myDriver.Navigate().GoToUrl(url);
        }

        public static void seleniumClose()
        {
            myDriver.Close();
            myDriver.Quit();
        }

        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();

            dirpath = @"../../TestExecutionReports/" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }

        public static void TakeScreenshotExtent(AventStack.ExtentReports.Status status, string stepDetail)
        {

            // Generate a unique file name for the screenshot
            //string fileName = "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "png";
            string fileName = "TestExecLog_" + stepDetail + ".png";

            try
            {
                // Take a screenshot using WebDriver
                ITakesScreenshot screenshotDriver = myDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Convert the screenshot to a byte array
                byte[] screenshotAsByteArray = screenshot.AsByteArray;

                // Define the directory path where you want to save the screenshot
                string directoryPath = "/Users/asadabbas/Projects/Adactin_POM_Reports/Adactin_POM_Reports/bin/Screenshots/";

                // Combine directory path and file name
                string fullPath = Path.Combine(directoryPath, fileName);

                // Save the screenshot to the specified path
                File.WriteAllBytes(fullPath, screenshotAsByteArray);

                // Log the screenshot in the Extent Report
                BaseClass.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                    .CreateScreenCaptureFromPath(fullPath).Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while taking screenshot: " + ex.Message);
                // Handle the exception as needed
            }
        }

        public static void TakeScreenshotAllure(string stepDetail)
        {
            string path = @"/Users/asadabbas/Projects/Adactin_POM_Reports/Adactin_POM_Reports/TestExecutionReport/" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var screenshot = ((ITakesScreenshot)myDriver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            AllureLifecycle.Instance.AddAttachment(stepDetail, "image/png", path);
        }

        public static void Write(By by, string data, string detail, string report)
        {
            if (report == "Extent")
            {
                try
                {
                    myDriver.FindElement(by).SendKeys(data);
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Entry Failed");
                }
            }

            if (report == "Allure")
            {
                try
                {
                    myDriver.FindElement(by).SendKeys(data);
                    TakeScreenshotAllure(detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotAllure("Entry Failed");
                }
            }
        }

        public static void Click(By by, string detail, string report)
        {
            if (report == "Extent")
            {
                try
                {
                    myDriver.FindElement(by).Click();
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Entry Failed" + ex);
                }
            }    

            if (report == "Allure")
            {
                try
                {
                    myDriver.FindElement(by).Click();
                    TakeScreenshotAllure(detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotAllure("Entry Failed" + ex);
                }
            }
        }

        public static void ClickWithoutSS(By by)
        {
            myDriver.FindElement(by).Click();
        }

        public static void SelectDropdownOption(By by, string value, string detail, string report)
        {
            if (report == "Extent")
            {
                try
                {
                    var Dropdown = myDriver.FindElement(by);
                    var SelectDropdown = new SelectElement(Dropdown);
                    SelectDropdown.SelectByValue(value);
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Entry Failed" + ex);
                }
            }

            if (report == "Allure")
            {
                try
                {
                    var Dropdown = myDriver.FindElement(by);
                    var SelectDropdown = new SelectElement(Dropdown);
                    SelectDropdown.SelectByValue(value);
                    TakeScreenshotAllure(detail);
                }
                catch (Exception ex)
                {
                    TakeScreenshotAllure("Entry Failed" + ex);
                }
            }
        }

        public static void MyAssertion(By by, string expectedText)
        {
            string actualText = myDriver.FindElement(by).Text;
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}

