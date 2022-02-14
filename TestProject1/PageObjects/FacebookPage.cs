using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class FacebookPage
	{
		private IWebDriver driver;
		private WebDriverWait wait;

		public FacebookPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
		}
	}
}
