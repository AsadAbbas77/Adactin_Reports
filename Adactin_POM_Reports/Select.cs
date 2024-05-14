using System;
using OpenQA.Selenium;

namespace Adactin_POM_Reports
{
	public class Select : BaseClass
	{
        By AssertLocator = By.XPath("//*[@id=\"select_form\"]/table/tbody/tr[1]/td");
        By selectRoom = By.XPath("//*[@id=\"radiobutton_0\"]");
        By continueWithRoom = By.XPath("//*[@id=\"continue\"]");

        public void HandleSelectRoom(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Select Room");
            }

            MyAssertion(AssertLocator, "Select Hotel");
            Click(selectRoom, "Selecting available room", report);
            Click(continueWithRoom, "Continuing with selected room", report);

            Thread.Sleep(3000);
        }
    }
}

