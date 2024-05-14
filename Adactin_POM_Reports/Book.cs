using System;
using OpenQA.Selenium;

namespace Adactin_POM_Reports
{
	public class Book : BaseClass
	{
        By AssertLocator = By.XPath("//*[@id=\"booking_form\"]/table/tbody/tr[1]/td");
        By firstName = By.XPath("//*[@id=\"first_name\"]");
        By lastName = By.XPath("//*[@id=\"last_name\"]");
        By Address = By.XPath("//*[@id=\"address\"]");
        By creditNum = By.XPath("//*[@id=\"cc_num\"]");
        By creditType = By.XPath("//*[@id=\"cc_type\"]");
        By expMonth = By.XPath("//*[@id=\"cc_exp_month\"]");
        By expYear = By.XPath("//*[@id=\"cc_exp_year\"]");
        By cvv = By.XPath("//*[@id=\"cc_cvv\"]");
        By btnBookNow = By.XPath("//*[@id=\"book_now\"]");
        By btnMyItinerary = By.XPath("//*[@id=\"my_itinerary\"]");

        public void HandleBookRoom(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Booking Room");
            }

            Write(firstName, "Alison", "Entering First Name", report);
            Write(lastName, "Burgers", "Entering Last Name", report);
            Write(Address, "Sydney East, Jackman Bay, 287", "Entering Address", report);
            Write(creditNum, "1234567891234567", "Entering Credit Card Number", report);
            SelectDropdownOption(creditType, "VISA", "Selecting Card Type", report);
            SelectDropdownOption(expMonth, "6", "Selecting Card Expiry Month", report);
            SelectDropdownOption(expYear, "2025", "Selecting Card Expiry Year", report);
            Write(cvv, "007", "Entering Card CVV", report);
            Click(btnBookNow, "Clicking Book Now", report);
            Thread.Sleep(6000);

            MyAssertion(AssertLocator, "Booking Confirmation");
            Thread.Sleep(2000);

            Click(btnMyItinerary, "My Itinerary", report);

            Thread.Sleep(3000);
        }
    }
}

