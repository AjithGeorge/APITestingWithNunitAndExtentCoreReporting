using APITestingWithNunit.Framework;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APITestingWithNunit.Scenarios
{
    [TestFixture]
    public class PostmanEchoScenario : APITestScenarioBase
    {
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            baseURL = "https://postman-echo.com/";
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory(this.GetType().Name);
        }

        [TearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //extent.Flush();
        }

        [Test]
        public async Task TestGetSuccess()
        {
            string endpoint = "get?foo1=bar1&foo2=bar2";

            HttpResponseMessage response = await client.GetAsync(baseURL + endpoint);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task TestPostSuccess()
        {
            string endpoint = "post";
            string body = "This is expected to be sent back as part of response body.";
            var json = JsonConvert.SerializeObject(body);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await client.PostAsync(baseURL + endpoint, stringContent);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }
    }
}
