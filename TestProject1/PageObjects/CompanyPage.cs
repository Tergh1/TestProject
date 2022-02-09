using OpenQA.Selenium;
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

		public CompanyPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public FacebookPage ClickFacebookLink()
		{
			FacebookLink.Click();

			return new FacebookPage(driver);
		}
	}
}
