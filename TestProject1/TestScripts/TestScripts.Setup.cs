using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.TestScripts
{
	[TestFixture]
	public partial class TestScripts
	{
		
		internal ExtentReports report;
		internal static string dataPath = AppDomain.CurrentDomain.BaseDirectory + @"\TestData\IvalidEmailData.txt";

		[OneTimeSetUp]
		public void Setup()
		{
			string reportPath = AppDomain.CurrentDomain.BaseDirectory + @"\Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\Test";
			Directory.CreateDirectory(reportPath);

			ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportPath);
			report = new ExtentReports();
			report.AttachReporter(reporter);

			
		}

		private sealed class TestScope : IDisposable
		{
			public IWebDriver driver;
			string prefferedBrowser = ConfigurationManager.AppSettings["prefferedBrowser"];
			public TestScope()
			{			
				if (prefferedBrowser == Resources.Resources.CHROMEBROWSER)
				{
					driver = new ChromeDriver();
				}
				else if (prefferedBrowser == Resources.Resources.FIREFOXBROWSER)
				{
					driver = new FirefoxDriver();
				}
				else
				{
					throw new Exception("Ivalid preffered browser in the settings.");
				}
			}

			public void Dispose()
			{
				driver.Quit();
			}
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			
			report.Flush();
		}
	}
}
