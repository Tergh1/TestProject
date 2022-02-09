using OpenQA.Selenium;
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
		private IJavaScriptExecutor jse;

		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			jse = (IJavaScriptExecutor)driver;
		}

		public void NavigateToHomePage()
		{
			string homePageURL = ConfigurationManager.AppSettings["baseURL"].ToString();
			driver.Url = homePageURL;
		}

		public void ClickContactUsButton()
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
