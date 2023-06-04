using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

public class LoginPageFactory
{
    public ILoginPage CreateLoginPage(WebDriverWait wait, IWebDriver driver)
    {
        return new OrangeHrmLoginPage(wait, driver);
    } 
}