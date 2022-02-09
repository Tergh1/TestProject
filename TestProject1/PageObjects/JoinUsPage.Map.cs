using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class JoinUsPage
	{
		SelectElement FilterByLocationDropdown => new SelectElement(driver.FindElement(By.Id("get_location")));

		IWebElement OpenPositionsContainer => driver.FindElement(By.CssSelector("div.inner-wraper"));

		ReadOnlyCollection<IWebElement> OpenPositionsCollection => OpenPositionsContainer.FindElements(By.CssSelector("div.card-container"));

		ReadOnlyCollection<IWebElement> OpenPositionsLinksCollection => OpenPositionsContainer.FindElements(By.CssSelector("a.card-jobsHot__link"));
	}
}
