using System;
using OpenQA.Selenium;

namespace Adactin_POM_Reports
{
	public class Search : BaseClass
	{
        By AssertLocator = By.ClassName("login_title");
        By Location = By.XPath("//*[@id=\"location\"]");
        By Hotel = By.XPath("//*[@id=\"hotels\"]");
        By RoomType = By.XPath("//*[@id=\"room_type\"]");
        By NoOfRooms = By.XPath("//*[@id=\"room_nos\"]");
        By OccAdult = By.XPath("//*[@id=\"adult_room\"]");
        By OccChild = By.XPath("//*[@id=\"child_room\"]");
        By searchBtn = By.XPath("//*[@id=\"Submit\"]");

        public void HandleSearchRoom(string report)
        {
            if (report == "Extent")
            {
                exChildTest = exParentTest.CreateNode("Search Room");
            }

            MyAssertion(AssertLocator, "Search Hotel (Fields marked with Red asterix (*) are mandatory)");
            SelectDropdownOption(Location, "Sydney", "Selecting Location", report);
            SelectDropdownOption(Hotel, "Hotel Hervey", "Selecting Hotel", report);
            SelectDropdownOption(RoomType, "Double", "Selecting Room Type", report);
            SelectDropdownOption(NoOfRooms, "3", "Selecting Number of Rooms", report);
            SelectDropdownOption(OccAdult, "2", "Selecting Adult Occupants", report);
            SelectDropdownOption(OccChild, "1", "Selecting Children Occupants", report);
            Click(searchBtn, "Search", report);

            Thread.Sleep(3000);
        }
    }
}

