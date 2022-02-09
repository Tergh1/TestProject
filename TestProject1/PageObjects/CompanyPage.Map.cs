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
		public IWebElement LeadershipSection => driver.FindElement(By.ClassName("company-members"));

		public IWebElement FacebookLink => driver.FindElement(By.XPath("/html/body/footer/div/div/a[4]"));
	}
}
