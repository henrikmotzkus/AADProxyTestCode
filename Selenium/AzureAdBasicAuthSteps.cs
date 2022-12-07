using System.Net;
using OpenQA.Selenium;

namespace SeleniumAzureAdBasicAuth;

public static class AzureAdBasicAuthSteps
{
    public static IWebDriver GoToApplication(this IWebDriver driver, string url)
    {
        driver
            .Navigate()
            .GoToUrl(url);
        return driver;
    }

    public static IWebDriver ClickLogon(this IWebDriver driver, string loginId)
    {
        var loginButton = driver.FindElement(By.Id(loginId));
        loginButton.Click();
        return driver;
    }

    public static IWebDriver SetAzureAdLoginDetails(this IWebDriver driver, string userName, string adLoginButtonId = "idSIButton9", string userNameTextBoxId = "i0116")
    {
        var adLoginButton = driver.FindElement(By.Id(adLoginButtonId));
        var userNameTextBox = driver.FindElement(By.Id(userNameTextBoxId));
        userNameTextBox.SendKeys(userName);
        adLoginButton.Click();
        return driver;
    }

    public static IWebDriver AzureAdPassword(this IWebDriver driver, string password)
    {
        Thread.Sleep(TimeSpan.FromSeconds(1));
        string adLoginButtonId = "idSIButton9";
        string userPasswordId = "i0118";
        var adLoginButton = driver.FindElement(By.Id(adLoginButtonId));
        var userPassword = driver.FindElement(By.Id(userPasswordId));
        userPassword.SendKeys(password);
        adLoginButton.Click();
        return driver;
    }

    public static IWebDriver AzureAdClickContinue(this IWebDriver driver)
    {
        string adLoginButtonId = "idSIButton9";
        var adLoginButton = driver.FindElement(By.Id(adLoginButtonId));
        adLoginButton.Click();
        return driver;
    }
}