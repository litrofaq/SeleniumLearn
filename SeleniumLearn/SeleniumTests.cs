using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearn;

public class SeleniumTests
{
    private ChromeDriver driver;
    
    [SetUp]
    public void start()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        driver = new ChromeDriver(options);
    }

    [Test]
    public void ConnectTest()
    {
        driver.Url = "http://google.com/";
        driver.FindElement(By.Name("q")).SendKeys("WebDriver" + Keys.Enter);
    }


    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }
}