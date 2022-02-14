using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class CompanyPage
	{
		private IWebDriver driver;
		private WebDriverWait wait;

		public CompanyPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
		}

		public FacebookPage ClickFacebookLink()
		{
			FacebookLink.Click();

			return new FacebookPage(driver);
		}
	}
}
