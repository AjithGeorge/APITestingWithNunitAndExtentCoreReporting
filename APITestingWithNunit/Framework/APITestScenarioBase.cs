using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.IO;

namespace APITestingWithNunit.Framework
{
    [SetUpFixture]
    [Parallelizable]
    public abstract class APITestScenarioBase
    {
        public HttpClient client;
        public static AventStack.ExtentReports.ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public Task InitScenario()
        {
            client = new HttpClient();

            var dir = TestContext.CurrentContext.TestDirectory + "\\";

            var reporter = new ExtentHtmlReporter(dir);

            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(reporter);
            extent.AddSystemInfo(Environment.UserName, Environment.OSVersion.ToString());

            reporter.Config.DocumentTitle = "ApiTestWithNunitAndExtentReport.Core";
            reporter.Config.Theme = Theme.Standard;
            reporter.Config.ReportName = "SampleTestRun";
            return Task.CompletedTask;
        }

        [OneTimeTearDown]
        public Task Clean()
        {
            extent.Flush();
            return Task.CompletedTask;
        }

        public HttpContent CovertToHttpContent(object arg, string contentType = "application/json")
        {
            var json = JsonConvert.SerializeObject(arg);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, contentType);
            return stringContent;
        }
    }

}

