using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Adactin_POM_Reports;

[AllureNUnit]
[TestFixture]
public class Tests : BaseClass
{
    public string report = "Extent";

    [SetUp]
    public void Setup()
    {
        if (report == "Extent")
        {
            LogReport("Extent Report");
            exParentTest = extentReports.CreateTest("Hotel Adactin");
        }
    }

    [TearDown]
    public void Teardown()
    {
        if (report == "Extent")
        {
            extentReports.Flush();
        }
    }

    [Test]
    [AllureStep]
    public void Test1()
    {
        seleniumInt("https://adactinhotelapp.com/HotelAppBuild2/index.php");

        Login login = new ();
        login.HandleLogin(report);

        Search searchRoom = new ();
        searchRoom.HandleSearchRoom(report);

        Select selectRoom = new ();
        selectRoom.HandleSelectRoom(report);

        Book bookRoom = new ();
        bookRoom.HandleBookRoom(report);

        Cancel cancelRoom = new ();
        cancelRoom.HandleCancelRoom(report);
        cancelRoom.HandleUserLogout(report);

        Thread.Sleep(3000);

        seleniumClose();
    }
}
