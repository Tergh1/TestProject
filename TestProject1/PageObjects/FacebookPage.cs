using OpenQA.Selenium;
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

		public FacebookPage(IWebDriver driver)
		{
			this.driver = driver;
		}
	}
}
