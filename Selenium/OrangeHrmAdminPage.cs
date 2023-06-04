using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Selenium;

public class OrangeHrmAdminPage : IAdminPage
{
    private struct Locators
    {
        public static By AdminButton => By.XPath("//a[@class=\"oxd-main-menu-item\" and contains(@href, \"/admin/viewAdminModule\")]");
        public static By JobDropDownMenu => By.XPath("//li[@class=\"oxd-topbar-body-nav-tab --parent\" and contains(span/text(), \"Job\")]");
        public static By JobTitlesButton => By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[1]/a");
        public static By JobTitleAddButton => By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[1]/div/button");
        public static By JobTitleField => By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/input");
        public static By JobTitleDescriptionField => By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/textarea");
        public static By JobTitleNoteField => By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[4]/div/div[2]/textarea");
        public static By JobTitleSaveButton => By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[5]/button[2]");
        public static By DeleteJobTitle => By.XPath(".//i[@class=\"oxd-icon bi-trash\"]/ancestor::button");
        public static By DeleteButton => By.XPath("/html/body/div/div[3]/div/div/div/div[3]/button[2]");
    }

    private readonly WebDriverWait _wait;
    private readonly IWebDriver _driver;

    public OrangeHrmAdminPage(WebDriverWait wait, IWebDriver driver)
    {
        _wait = wait;
        _driver = driver;
    }

    public void AddJob(string title, string description, string note)
    {
        ClickAdminButton();
        ClickJobDropBackMenu();
        ClickJobTitleButton();
        ClickJobAddTitleButton();
        
        EnterJobTitle(title);
        EnterJobDescription(description);
        EnterJobNote(note);
        ClickSaveJobTitleButton();
    }

    public void DeleteJob(string title)
    {
        var collection = FindJobTitle(title);
            
        var deleteJobTitle = collection[0].FindElement(Locators.DeleteJobTitle);
        deleteJobTitle.Click();
        
        var deleteConfirmButton = _wait.Until(_ => _driver.FindElement(Locators.DeleteButton));
        deleteConfirmButton.Click();
    }
    
    public ReadOnlyCollection<IWebElement> GetAllJobs()
    {
        var elements = new List<IWebElement>();
        
        try
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            
            wait.Until(driver =>
            {
                elements = driver.FindElements(By.XPath("//div[@class='oxd-table-card']")).ToList();
                return elements.Count > 0;
            });
        }
        catch (WebDriverTimeoutException)
        {
            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }
        
        return new ReadOnlyCollection<IWebElement>(elements.ToList());
    }
        
    private void ClickAdminButton()
    {
        var adminButton = _wait.Until(_ => _driver.FindElement(Locators.AdminButton));
        adminButton.Click();
    }
    
    private void ClickJobDropBackMenu()
    {
        var jobDropDownMenu = _wait.Until(_ => _driver.FindElement(Locators.JobDropDownMenu));
        jobDropDownMenu.Click();

    }
    
    private void ClickJobTitleButton()
    {
        var jobTitlesButton = _wait.Until(_ => _driver.FindElement(Locators.JobTitlesButton));
        jobTitlesButton.Click();
    }

    private void ClickJobAddTitleButton()
    {
        var addJobTitleButton = _wait.Until(_ => _driver.FindElement(Locators.JobTitleAddButton));
        addJobTitleButton.Click();
    }
    
    private void EnterJobTitle(string title)
    {
        var jobTitleField = _wait.Until(_ => _driver.FindElement(Locators.JobTitleField));
        jobTitleField.SendKeys(title);
    }
    
    private void EnterJobDescription(string description)
    {
        var jobTitleDescription = _wait.Until(_ => _driver.FindElement(Locators.JobTitleDescriptionField));
        jobTitleDescription.SendKeys(description);
    }
    
    private void EnterJobNote(string note)
    {
        var jobTitleNote = _wait.Until(_ => _driver.FindElement(Locators.JobTitleNoteField));
        jobTitleNote.SendKeys(note);
    }
    
    private void ClickSaveJobTitleButton()
    {
        var jobTitleSave = _wait.Until(_ => _driver.FindElement(Locators.JobTitleSaveButton));
        jobTitleSave.Click();
    }
    
    private ReadOnlyCollection<IWebElement> FindJobTitle(string title)
    {
        var elements = new List<IWebElement>();
        
        try
        {
            var jobTitleRowXPath = $"//div[contains(text(), '{title}')]/ancestor::div[@class='oxd-table-card']";
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            
            wait.Until(driver =>
            {
                elements = driver.FindElements(By.XPath(jobTitleRowXPath)).ToList();
                return elements.Count > 0;
            });
        }
        catch (WebDriverTimeoutException)
        {
            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }
        
        return new ReadOnlyCollection<IWebElement>(elements.Where(row => row.Text.Contains(title)).ToList());
    }
}