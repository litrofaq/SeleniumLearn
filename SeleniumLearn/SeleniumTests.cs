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
    
    private string urlRoaming = "https://qa-course.kontur.host/roaming";
    
    private static By titleLocator = By.CssSelector("div.container h1");
    private static string titleText = "Роуминг";
    
    [SetUp]
    public void start()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        chromeDriver = new ChromeDriver(options);
        /*firefoxDriver = new FirefoxDriver();
        edgeDriver = new EdgeDriver();*/
    }

    [Test]
    public void ChromeConnectTest()
    {
        chromeDriver.Url = urlRoaming;
        
        // Ожидать 10 секунд появления заголовка
        WebDriverWait waitVisibleTitle = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
        waitVisibleTitle.Until(e => e.FindElement(titleLocator));
        
        chromeDriver.FindElement(titleLocator);
        Assert.Multiple(() =>
        {
            Assert.IsTrue(chromeDriver.FindElement(titleLocator).Text.Contains(titleText),
            $"\tОжидался заголовок: '{titleText}'\n" + 
            $"Фактический текст заголовка: '{chromeDriver.FindElement(titleLocator).Text}'");
            
        });
    }

    /*[Test]
    public void FirefoxConnectTest()
    {
        firefoxDriver.Url = "http://yandex.ru/";
        firefoxDriver.FindElement(By.ClassName("input__control")).SendKeys("WebDriver" + Keys.Enter);
    }*/

    /*[Test]
    public void EdgeConnectTest()
    {
        edgeDriver.Url = "http://bing.com";
        edgeDriver.FindElement(By.ClassName("sb_form_q")).SendKeys("WebDriver" + Keys.Enter);
    }*/


    [TearDown]
    public void TearDown()
    {
        chromeDriver.Quit();
        chromeDriver = null;
        
        /*firefoxDriver.Quit();
        firefoxDriver = null;*/
        
        /*edgeDriver.Quit();
        edgeDriver = null;*/
    }
}