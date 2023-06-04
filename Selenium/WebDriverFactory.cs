using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium;

public class WebDriverFactory
{
    public IWebDriver CreateWebDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        
        return new ChromeDriver(options);    
    }
}