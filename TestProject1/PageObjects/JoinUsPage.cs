using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1.PageObjects
{
	public partial class JoinUsPage
	{
		private IWebDriver driver;

		public JoinUsPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public JoinUsPage SelectLocationByText(string text)
		{
			FilterByLocationDropdown.SelectByText(text);

			return new JoinUsPage(driver);
		}

		public JobPage ChooseOpenPositionByName(string name)
		{
			OpenPositionsLinksCollection.FirstOrDefault(element => element.FindElement(By.CssSelector("h2.card-jobsHot__title")).Text == name).Click();

			return new JobPage(driver);
		}

		private Dictionary<string, string> GetAllAvailablePositionsDescriptions()
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			foreach(IWebElement element in OpenPositionsCollection)
			{
				string key = element.FindElement(By.TagName("h2")).Text;
				string value = element.FindElement(By.CssSelector("a.card-jobsHot__link")).GetAttribute("href");
				result.Add(key, value);
			}

			return result;
		}

		public void GetAllPositionsAndPrintInTheConsoleForSelectedLocation(string location)
		{
			SelectLocationByText(location);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			Console.WriteLine(location);
			Dictionary<string, string> positions = GetAllAvailablePositionsDescriptions();
			PrintResultsITheConsole(positions);
		}

		private void PrintResultsITheConsole(Dictionary<string, string> positions)
		{
			foreach (var position in positions)
			{
				Console.WriteLine("Position: " + position.Key);
				Console.WriteLine("More info: " + position.Value);
			}
		}
	}
}
