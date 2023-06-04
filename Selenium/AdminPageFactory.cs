using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

public class AdminPageFactory
{
    public IAdminPage CreateAdminPage(WebDriverWait wait, IWebDriver driver)
    {
        return new OrangeHrmAdminPage(wait, driver);
    }
}