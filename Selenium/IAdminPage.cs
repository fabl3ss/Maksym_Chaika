using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium;

public interface IAdminPage
{
    void AddJob(string title, string description, string note);
    void DeleteJob(string title);
    ReadOnlyCollection<IWebElement> GetAllJobs();
}