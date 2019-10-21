using APITestingWithNunit.DTOs;
using APITestingWithNunit.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace APITestingWithNunit.Scenarios
{
    [TestFixture]
    public class DummyRestAPISampleScenarios : APITestScenarioBase
    {
        private string baseURL = "http://dummy.restapiexample.com/api/v1/";

        [OneTimeSetUp]
        public void Intitialize()
        {
            //test= extent.CreateTest(this.GetType().Name);
        }

        [SetUp]
        public void Setup()
        {
            //baseURL = "http://dummy.restapiexample.com/api/v1/";
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory(this.GetType().Name);
            //test.CreateNode(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
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
            string endpoint = "employees";

            HttpResponseMessage response = await client.GetAsync(baseURL + endpoint);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task TestGetDetailValidation()
        {
            string endpoint = "employees";

            string responseContent = await client.GetStringAsync(baseURL + endpoint);

            var retrievedEmployees = JsonConvert.DeserializeObject<List<EmployeeModal>>(responseContent);
            //Assert.That(retrievedEmployees[0].employee_name, Is.EqualTo("Burg"));
        }

        [Test]
        public async Task TestGetWithParamsSuccess()
        {
            string endpoint = "employee / 247";
            string responseContent = await client.GetStringAsync(baseURL + endpoint);
            var employee = JsonConvert.DeserializeObject<EmployeeModal>(responseContent);
            Assert.That(employee.id, Is.EqualTo("247"));
        }

        [Test]
        public async Task TestPostSuccess()
        {
            string endpoint = "create";

            var employee = new CreateOrUpdateEmployeeModal
            {
                name = "doe",
                salary = "456",
                age = "27",
                id = "788"
            };

            var stringContent = CovertToHttpContent(employee);
            HttpResponseMessage response = await client.PostAsync(baseURL + endpoint, stringContent);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            string responseContent = await client.GetStringAsync(baseURL + "employees");
            var employees = JsonConvert.DeserializeObject<List<EmployeeModal>>(responseContent);

            var retrievedEmployee = employees.Find(u => u.employee_name == "john");
        }

        [Test]
        public async Task TestPutSuccess()
        {
            string endpoint = "update/271";

            var employee = new CreateOrUpdateEmployeeModal
            {
                name = "johnUpd",
                salary = "123",
                age = "25",
            };

            var stringContent = CovertToHttpContent(employee);
            HttpResponseMessage response = await client.PutAsync(baseURL + endpoint, stringContent);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task TestDeleteSuccess()
        {
            string endpoint = "delete/757";
            HttpResponseMessage response = await client.DeleteAsync(baseURL + endpoint);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public void TestWarningStatus()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TestIgnoreStatus()
        {
            Assert.Ignore();
        }

    }
}