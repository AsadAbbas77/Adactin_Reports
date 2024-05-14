using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace Adactin_POM_Reports
{
	public class Cancel : BaseClass
	{
        By AssertLocator = By.XPath("//*[@id=\"booked_form\"]/table/tbody/tr[1]/td/table/tbody/tr/td[1]");
        By btnCheckAll = By.XPath("//*[@id=\"check_all\"]");
        By btnCancelSelected = By.XPath("//*[@id=\"booked_form\"]/table/tbody/tr[3]/td/input[1]");

        By AssertLocator2 = By.XPath("/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr/td");
        By btnLogout = By.XPath("//*[@id=\"logout\"]");
        By btnLoginPage = By.XPath("/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr/td/a");

        public void HandleCancelRoom(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Cancel Selected Rooms");
            }

            MyAssertion(AssertLocator, "Booked Itinerary");
            Click(btnCheckAll, "Selecting all booked rooms", report);
            ClickWithoutSS(btnCancelSelected);
            Thread.Sleep(3000);

            IAlert alert = myDriver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(4000);
        }

        public void HandleUserLogout(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Logging Out");
            }

            Click(btnLogout, "Successful Logout", report);
            Thread.Sleep(2000);

            MyAssertion(AssertLocator2, "You have successfully logged out. Click here to login again");

            Click(btnLoginPage, "Taking user back to Login", report);

            Thread.Sleep(5000);
        }
    }
}

