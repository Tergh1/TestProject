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
		public IWebElement CheckOurOpenPositionsButton => driver.FindElement(By.XPath("/html/body/main/div/div/div[1]/div/div[1]/div/section/div/a/button"));
	}
}
