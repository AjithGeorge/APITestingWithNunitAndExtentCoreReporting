# APITestingWithNunitAndExtentCoreReporting

.Net Core (2.2) based api framework for creating automated api tests.

## Areas Covered:
- Create Tests using [Nunit-v3](https://github.com/nunit/docs/wiki)
- Generate Report using [ExtentReports.Core-1.0.2](https://www.nuget.org/packages/ExtentReports.Core) 
- Create Tests using HttpClient Class [System.Net.Http](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8)


## Overview:
The solution tests APIs from,

1. [DummyRestApiExample](http://dummy.restapiexample.com)
2. [PostmanEcho](https://postman-echo.com)

<br>Currently available extent reports package is not compatible with .Net Core applications.
<br>Alternative solution identified was to use ExtentReports.Core.
<br>Test framework used is nunit3 - Tests were parallelized for improved performance.

## Prerequisites:
1. Visual Studio 2019 with the ASP.NET and web development workload
2. .NET Core 3.0 SDK or later

## Execution Steps:
1. Clone/Download the repo.
2. Run the tests through any means.
3. Report will get generated in TestDirectory. [bin\netcoreapp2.2\..]

### Sample Report
<a href="https://github.com/AjithGeorge/APITestingWithNunitAndExtentCoreReporting/blob/master/Sample%20Report/dashboard.html">SampleReport</a>
