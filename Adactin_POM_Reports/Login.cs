using System;
using OpenQA.Selenium;

namespace Adactin_POM_Reports
{
	public class Login : BaseClass
	{
        By Username = By.XPath("//*[@id=\"username\"]");
        By Password = By.XPath("//*[@id=\"password\"]");
        By loginBtn = By.ClassName("login_button");

        public void HandleLogin(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Login");
            }
            
            Write(Username, "MehdiR122", "Enter Username", report);
            Write(Password, "12345Abc", "Enter Password", report);
            Click(loginBtn, "Click Login", report);

            Thread.Sleep(2000);
        }
    }
}

