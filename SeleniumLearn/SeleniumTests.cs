using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearn;

public class SeleniumTests
{
    private ChromeDriver chromeDriver;
    private FirefoxDriver firefoxDriver;
    private EdgeDriver edgeDriver;
    
    [SetUp]
    public void start()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        chromeDriver = new ChromeDriver(options);
        firefoxDriver = new FirefoxDriver();
        edgeDriver = new EdgeDriver();
    }

    [Test]
    public void ChromeConnectTest()
    {
        chromeDriver.Url = "http://google.com/";
        chromeDriver.FindElement(By.Name("q")).SendKeys("WebDriver" + Keys.Enter);
    }

    [Test]
    public void FirefoxConnectTest()
    {
        firefoxDriver.Url = "http://yandex.ru/";
        firefoxDriver.FindElement(By.ClassName("input__control")).SendKeys("WebDriver" + Keys.Enter);
    }

    [Test]
    public void EdgeConnectTest()
    {
        edgeDriver.Url = "http://bing.com";
        edgeDriver.FindElement(By.ClassName("sb_form_q")).SendKeys("WebDriver" + Keys.Enter);
    }


    [TearDown]
    public void TearDown()
    {
        chromeDriver.Quit();
        chromeDriver = null;
        
        firefoxDriver.Quit();
        firefoxDriver = null;
        
        edgeDriver.Quit();
        edgeDriver = null;
    }
}