# APITestingWithNunitAndExtentCoreReporting

.Net Core (2.2) based api framework for creating automated api tests.

## Areas Covered:
Create Tests using [Nunit-v3](https://github.com/nunit/docs/wiki)
Generate Report using [ExtentReports.Core-1.0.2](https://www.nuget.org/packages/ExtentReports.Core) 
Create Tests using HttpClient Class [System.Net.Http](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8)


## Overview:
The solution tests APIs from,

1. [DummyRestApiExample](http://dummy.restapiexample.com)
2. [PostmanEcho](https://postman-echo.com)

Currently available extent reports package is not compatible with .Net Core applications.
Alternative solution identified was to use ExtentReports.Core 1.0.2 [https://www.nuget.org/packages/ExtentReports.Core]
Test framework used is nunit3 - Test were parallelized for efficient performance.

## Prerequisites:
Visual Studio 2019 with the ASP.NET and web development workload
.NET Core 3.0 SDK or later
