using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class JobPage
	{
		public IWebElement SectionsContainer => driver.FindElement(By.CssSelector("div.entry-content"));

		public ReadOnlyCollection<IWebElement> SectionsTitles => SectionsContainer.FindElements(By.CssSelector("div.content-title"));

		public IWebElement ApplyButton => driver.FindElement(By.CssSelector("input.wpcf7-form-control.wpcf7-submit.btn-join-us.btn-apply"));

		#region Apply Form
		public IWebElement NameField => driver.FindElement(By.Id("cf-1"));

		public IWebElement NameErrorMessage => driver.FindElement(By.XPath("/html/body/div[8]/div/div[9]/div/div/div/form/p[2]/span/span"));

		public IWebElement EmailField => driver.FindElement(By.Id("cf-2"));

		public IWebElement EmailErrorMessage => driver.FindElement(By.XPath("/html/body/div[8]/div/div[9]/div/div/div/form/p[3]/span/span"));

		public IWebElement MobileField => driver.FindElement(By.Id("cf-3"));

		public IWebElement MobileErrorMessage => driver.FindElement(By.XPath("/html/body/div[8]/div/div[9]/div/div/div/form/p[4]/span/span"));

		public IWebElement UploadYuorCVField => driver.FindElement(By.Id("uploadtextfield"));

		public IWebElement LinkedInProfileLinkField => driver.FindElement(By.Id("cf-5"));

		public IWebElement YourMessageField => driver.FindElement(By.Id("cf-6"));

		public IWebElement YourMessageErrorMessage => driver.FindElement(By.XPath("/html/body/div[8]/div/div[9]/div/div/div/form/p[6]/span/span"));

		public IWebElement SendButton => driver.FindElement(By.CssSelector("input.wpcf7-form-control.has-spinner.wpcf7-submit.btn-cf-submit"));

		public IWebElement CloseButton => driver.FindElement(By.CssSelector("button.close-form"));
		#endregion
	}
}
