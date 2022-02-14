using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using TestProject1.Models;
using TestProject1.PageObjects;

namespace TestProject1.TestScripts
{
	[TestFixture]
	public partial class TestScripts
	{
		public static string[] InvalidEmailData()
		{
			return File.ReadAllLines(dataPath);
		}

		[Test, TestCaseSource("InvalidEmailData")]
		public void TestCase1(string email)
		{
			ExtentTest test = report.CreateTest("TestCase1, data: " + email);

			try
			{
				HomePage homePage = new HomePage(driver);
				homePage.NavigateToHomePage();
				test.Info("Step1 completed: Visit http://www.musala.com/ ");

				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
				homePage.ClickContactUsButton();
				test.Info("Step2 completed: Scroll down and go to ‘Contact Us’");

				ContactData contactData = new ContactData();
				contactData.Name = "Dinka Ivanova";
				contactData.Email = email;
				contactData.Subject = "Candidacy";
				contactData.YourMessage = "I am a candidate for your vacant position.";
				homePage.FillContactUsFormAndSubmit(contactData);
				test.Info("Step3, Step 4 and Step5 completed: Fill all required fields except email.Under email field enter string with wrong email format (e.g. test@test).Click ‘Send’ button.");

				Assert.IsTrue(homePage.InvalidEmailErrorMessage.Displayed);
				test.Info("Step6 completed: Verify that error message ‘The e-mail address entered is invalid.’ appears");

				test.Pass("TestCase1, data: " + email + " completed successfully.");
			}
			catch(Exception e)
			{
				test.Fail(e.Message);
				Assert.Fail(e.Message);
			}
		}
		

		[Test]
		public void TestCase2()
		{
			ExtentTest test = report.CreateTest("TestCase2");

			try
			{
				HomePage homePage = new HomePage(driver);
				homePage.NavigateToHomePage();
				test.Info("Step1 completed: Visit http://www.musala.com/ ");
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

				CompanyPage compPage = homePage.ClickCompanyTab();
				test.Info("Step2 completed: Click ‘Company’ tap from the top");
				Thread.Sleep(1000);

				Assert.AreEqual(Resources.Resources.COMPANYURL, driver.Url);
				test.Info("Ste3 completed: Verify that the correct URL (http://www.musala.com/company/) loads");

				Assert.IsTrue(compPage.LeadershipSection.Displayed);
				test.Info("Ste4 completed: Verify that there is ‘Leadership’ section");

				string previousWindowHandle = driver.CurrentWindowHandle;

				FacebookPage fPage = compPage.ClickFacebookLink();
				test.Info("Step5 completed: Click the Facebook link from the footer");

				foreach (string handle in driver.WindowHandles)
				{
					if (handle != previousWindowHandle)
					{
						driver.SwitchTo().Window(handle);
					}
				}

				
				fPage.AllowCookiesButton.Click();

				Thread.Sleep(1000);
				Assert.AreEqual(Resources.Resources.FACEBOOKURL, driver.Url);
				Assert.IsTrue(fPage.ProfilePicture.Displayed);
				test.Info("Step6 completed: Verify that the correct URL (https://www.facebook.com/MusalaSoft?fref=ts) loads and verify if the Musala Soft profile picture appears on the new page");

				test.Pass("TestCase2 completed successfully.");
			}
			catch (Exception e)
			{
				test.Fail(e.Message);
				Assert.Fail(e.Message);
			}
		}

		[Test]
		[TestCase("", "", "", "")]
		[TestCase("test", "test", "test", "test")]
		public void TestCase3(string name, string email, string mobile, string message)
		{
			ExtentTest test = report.CreateTest("TestCase3, name: " + name + " email: " + " mobile: " + mobile + " message: " + message);

			try
			{
				HomePage homePage = new HomePage(driver);
				homePage.NavigateToHomePage();
				test.Info("Step1 completed: Visit http://www.musala.com/ ");
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

				CareersPage careersPage = homePage.ClickCareersTab();
				test.Info("Step2 completed: Navigate to Careers menu (from the top)");

				JoinUsPage juPage = careersPage.ClickCheckOurOpenPositionsButton();
				test.Info("Ste3 completed: Click ‘Check our open positions’ button");

				Assert.AreEqual(Resources.Resources.JOINUSURL, driver.Url);
				test.Info("Ste4 completed: Verify that ‘Join Us’ page is opened");

				juPage = juPage.SelectLocationByText("Anywhere");
				test.Info("Step5 completed: From the dropdown ‘Select location’ select ‘Anywhere’");

				JobPage jobPage = juPage.ChooseOpenPositionByName("Experienced Automation QA Engineer");
				test.Info("Step6 completed: Choose open position by name (e.g. Experienced Automation QA Engineer)");

				Assert.IsTrue(jobPage.CheckIfSectionTitleExists("General description"));
				Assert.IsTrue(jobPage.CheckIfSectionTitleExists("Requirements"));
				Assert.IsTrue(jobPage.CheckIfSectionTitleExists("Responsibilities"));
				Assert.IsTrue(jobPage.CheckIfSectionTitleExists("What we offer"));
				test.Info("Step7 completed: Verify that 4 main sections are shown: General Description, Requirements, Responsibilities, What we offer");

				Assert.IsTrue(jobPage.ApplyButton.Displayed);
				test.Info("Step8 completed: Verify that ‘Apply’ button is present at the bottom)");

				jobPage.ApplyButton.Click();
				test.Info("Step9 completed: Click ‘Apply’ button");

				ApplyData applyData = new ApplyData();
				applyData.Name = name;
				applyData.Email = email;
				applyData.Mobile = mobile;
				applyData.CVPath = dataPath;
				applyData.LinkedInProfileLink = "";
				applyData.YourMessage = message;
				jobPage.FillAndSubmitApplyForm(applyData);
				test.Info("Step10 and Step11 completed: Prepare a few sets of negative data.Upload a CV document, and click ‘Send’ button.");

				if (String.IsNullOrEmpty(name))
				{
					Assert.AreEqual(Resources.Resources.REQUIREDERRORMESSAGE, jobPage.NameErrorMessage.Text);
				}
				if (String.IsNullOrEmpty(email))
				{
					Assert.AreEqual(Resources.Resources.REQUIREDERRORMESSAGE, jobPage.EmailErrorMessage.Text);
				}
				else
				{
					Assert.AreEqual(Resources.Resources.EMAILINVALIDERRORMESSAGE, jobPage.EmailErrorMessage.Text);
				}
				if (String.IsNullOrEmpty(mobile))
				{
					Assert.AreEqual(Resources.Resources.REQUIREDERRORMESSAGE, jobPage.MobileErrorMessage.Text);
				}
				else
				{
					Assert.AreEqual(Resources.Resources.MOBILEINVALIDERRORMESSAGE, jobPage.MobileErrorMessage.Text);
				}
				if (String.IsNullOrEmpty(message))
				{
					Assert.AreEqual(Resources.Resources.REQUIREDERRORMESSAGE, jobPage.YourMessageErrorMessage.Text);
				}
				test.Info("Step12 completed: Verify shown error messages");

				test.Pass("TestCase3 completed successfully.");
			}
			catch (Exception e)
			{
				test.Fail(e.Message);
				Assert.Fail(e.Message);
			}
		}

		[Test]
		public void TestCase4()
		{
			ExtentTest test = report.CreateTest("TestCase4");

			try
			{
				HomePage homePage = new HomePage(driver);
				homePage.NavigateToHomePage();
				test.Info("Step1 completed: Visit http://www.musala.com/ ");

				CareersPage careersPage = homePage.ClickCareersTab();
				test.Info("Step2 completed: Go to Careers");

				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
				JoinUsPage juPage = careersPage.ClickCheckOurOpenPositionsButton();
				test.Info("Ste3 completed: Click ‘Check our open positions’ button");

				juPage.GetAllPositionsAndPrintInTheConsoleForSelectedLocation("Sofia");
				juPage.GetAllPositionsAndPrintInTheConsoleForSelectedLocation("Skopje");
				test.Info("Ste4, 5 and 6 completed: Filter the available positions by available cities in the dropdown ‘Select location’ (Sofia and Skopje). Get the open positions by city. Print in the console the list with available positions by city");

				test.Pass("TestCase4 completed successfully.");
			}
			catch (Exception e)
			{
				test.Fail(e.Message);
				Assert.Fail(e.Message);
			}
		}
	}
}