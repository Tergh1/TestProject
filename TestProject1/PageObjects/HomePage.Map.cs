using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.PageObjects
{
	public partial class HomePage
	{
		public IWebElement ContactUsButton => driver.FindElement(By.CssSelector("button.contact-label.btn.btn-1b"));

		#region ContactUsForm
		public IWebElement NameField => driver.FindElement(By.Id("cf-1"));

		public IWebElement EmailField => driver.FindElement(By.Id("cf-2"));

		public IWebElement SubjectField => driver.FindElement(By.Id("cf-4"));

		public IWebElement YourMessageField => driver.FindElement(By.Id("cf-5"));

		public IWebElement SendButton => driver.FindElement(By.CssSelector("input.wpcf7-form-control.has-spinner.wpcf7-submit.btn-cf-submit"));

		public IWebElement InvalidEmailErrorMessage => driver.FindElement(By.CssSelector("span.wpcf7-not-valid-tip"));
		#endregion

		#region Tabs
		public IWebElement CompanyTab => driver.FindElement(By.XPath("/html/body/header/nav[2]/div/div/ul/li[1]/a"));

		public IWebElement CareersTab => driver.FindElement(By.XPath("/html/body/header/nav[2]/div/div/ul/li[5]/a"));
		#endregion
	}
}
