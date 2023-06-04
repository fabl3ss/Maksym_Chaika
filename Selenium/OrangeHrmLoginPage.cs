using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

public class OrangeHrmLoginPage : ILoginPage
{
    private struct Locators
    {
        public static By UsernameField => By.XPath("//input[@name='username']");
        public static By PasswordField => By.XPath("//input[@name='password']");
        public static By LoginButton => By.XPath("//button[@type='submit']"); 
    }
    
    private readonly WebDriverWait _wait;
    private readonly IWebDriver _driver;

    public OrangeHrmLoginPage(WebDriverWait wait, IWebDriver driver)
    {
        _wait = wait;
        _driver = driver;
    }

    public void LoginWithCredentials(string username, string password)
    {
        _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        
        EnterUsername(username);     
        EnterPassword(password);
        PressLoginButton();
    }
    
    private void EnterUsername(string username)
    {
        var usernameField = _wait.Until(driver => driver.FindElement(Locators.UsernameField));
        usernameField.SendKeys(username);
    }
    
    private void EnterPassword(string password)
    {
        var passwordField = _wait.Until(driver => driver.FindElement(Locators.PasswordField));
        passwordField.SendKeys(password);
    }
    
    private void PressLoginButton()
    {
        var signInButton = _wait.Until(driver => driver.FindElement(Locators.LoginButton));
        signInButton.Click();
    }
}