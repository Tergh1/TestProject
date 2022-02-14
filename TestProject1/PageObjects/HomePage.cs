using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.PageObjects
{
	public partial class HomePage
	{
		private IWebDriver driver;
		private WebDriverWait wait;
		private IJavaScriptExecutor jse;

		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
			jse = (IJavaScriptExecutor)driver;
		}

		public void NavigateToHomePage()
		{
			string homePageURL = ConfigurationManager.AppSettings["baseURL"].ToString();
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
			driver.Url = homePageURL;
		}

		public void ScrollAndClickContactUsButton()
		{
			jse.ExecuteScript("arguments[0].scrollIntoView();", ContactUsButton);
			ContactUsButton.Click();


		}

		public CompanyPage ClickCompanyTab()
		{
			ClickTab(CompanyTab);

			return new CompanyPage(driver);
		}

		private void ClickTab(IWebElement element)
		{
			jse.ExecuteScript("arguments[0].click();", element);
		}

		public CareersPage ClickCareersTab()
		{
			ClickTab(CareersTab);

			return new CareersPage(driver);
		}

		public void FillContactUsFormAndSubmit(ContactData contactData)
		{
			NameField.Clear();
			NameField.SendKeys(contactData.Name);

			EmailField.Clear();
			EmailField.SendKeys(contactData.Email);

			//Mobile is skipped due to optional

			SubjectField.Clear();
			SubjectField.SendKeys(contactData.Subject);

			YourMessageField.Clear();
			YourMessageField.SendKeys(contactData.YourMessage);

			SendButton.Submit();
		}
	}
}
