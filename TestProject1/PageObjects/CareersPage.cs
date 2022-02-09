using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class CareersPage
	{
		private IWebDriver driver;

		public CareersPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public JoinUsPage ClickCheckOurOpenPositionsButton()
		{
			CheckOurOpenPositionsButton.Click();

			return new JoinUsPage(driver);
		}
	}
}
