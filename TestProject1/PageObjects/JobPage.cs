using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.PageObjects
{
	public partial class JobPage
	{
		private IWebDriver driver;

		public JobPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public bool CheckIfSectionTitleExists(string title)
		{
			return SectionsTitles.Any(element => element.FindElement(By.TagName("h2")).Text == title);
		}

		public void FillAndSubmitApplyForm(ApplyData applyData)
		{
			NameField.Clear();
			NameField.SendKeys(applyData.Name);

			EmailField.Clear();
			EmailField.SendKeys(applyData.Email);

			MobileField.Clear();
			MobileField.SendKeys(applyData.Mobile);

			UploadYuorCVField.Clear();
			UploadYuorCVField.SendKeys(applyData.CVPath);

			LinkedInProfileLinkField.Clear();
			LinkedInProfileLinkField.SendKeys(applyData.LinkedInProfileLink);

			YourMessageField.Clear();
			YourMessageField.SendKeys(applyData.YourMessage);

			SendButton.Submit();

			IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
			jse.ExecuteScript("arguments[0].click();", CloseButton);
		}
	}
}
