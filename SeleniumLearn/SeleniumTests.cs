using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearn;

public class SeleniumTests
{
    private ChromeDriver driver;
    private FirefoxDriver firefoxDriver;
    
    [SetUp]
    public void start()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        driver = new ChromeDriver(options);
        firefoxDriver = new FirefoxDriver();
    }

    [Test]
    public void ChromeConnectTest()
    {
        driver.Url = "http://google.com/";
        driver.FindElement(By.Name("q")).SendKeys("WebDriver" + Keys.Enter);
    }

    [Test]
    public void FirefoxConnectTest()
    {
        firefoxDriver.Url = "http://yandex.ru/";
        firefoxDriver.FindElement(By.ClassName("input__control")).SendKeys("WebDriver" + Keys.Enter);
    }


    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
        firefoxDriver.Quit();
        firefoxDriver = null;
    }
}