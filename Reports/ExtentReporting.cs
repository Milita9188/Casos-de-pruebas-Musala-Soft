using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Casos_de_prueba_Musala_Soft.Reports
{    
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if (extentReports == null)
            { 
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlRporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htmlRporter);
            }
            return extentReports;
        }

        public static void CreateTest(string testName) 
        {
            extentTest = StartReporting().CreateTest(testName);        
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }

        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
