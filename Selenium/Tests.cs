using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

[TestFixture]
public class Test
{
    private IWebDriver _driver = null!;
    
    private ILoginPage _loginPage = null!;
    private IAdminPage _adminPage = null!;

    [SetUp]
    public void SetUp()
    {
        var driverFactory = new WebDriverFactory();
        _driver = driverFactory.CreateWebDriver();

        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); 
        
        var loginPageFactory = new LoginPageFactory();
        _loginPage = loginPageFactory.CreateLoginPage(wait, _driver);

        var adminPageFactory = new AdminPageFactory();
        _adminPage = adminPageFactory.CreateAdminPage(wait, _driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    [Test]
    public void AdminJobWorkflowTest()
    {
        _loginPage.LoginWithCredentials("Admin", "admin123");
        
        const string jobTitle = "Student";
        _adminPage.AddJob(jobTitle, "Study hard, be responsible", "Be patient with mistakes"); 

        var jobsCollection = _adminPage.GetAllJobs();
        if (jobsCollection.Where(row => row.Text.Contains(jobTitle)).ToList().Count == 0)
        {
            Assert.Fail("Job was not created");
        }
        
        _adminPage.DeleteJob(jobTitle); 
        
        jobsCollection = _adminPage.GetAllJobs();
        if (jobsCollection.Where(row => row.Text.Contains(jobTitle)).ToList().Count != 0)
        {
            Assert.Fail("Job was not deleted");
        }
        
        Assert.Pass(); 
    }
}