using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Reflection;

namespace TakeALot.Reports
{
    public class Reporting
    {
        public static ExtentReports InitializeReport()
        {
            string LocalDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Reports";

            if (!Directory.Exists(LocalDirectory)) Directory.CreateDirectory(LocalDirectory);
            string datestamp = DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            string reportPath = LocalDirectory + "\\  Automation Test Report " + datestamp + "\\testing.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "Test Execution Report";
            htmlReporter.Config.ReportName = "Test Execution Report";
            htmlReporter.Config.DocumentTitle = "Regression Result";
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }

        public static void TearDownReport(ExtentReports extent)
        {
          //  extent.Flush();
        }
    }
}
