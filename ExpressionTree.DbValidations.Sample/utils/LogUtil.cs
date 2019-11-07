using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressionTree.DbValidations.Sample.utils
{
   public static class LogUtil
    {
        public static LogLevel logLevel = LogLevel.Information;
       public static Stopwatch StartStopWatch(ILogger logger, string className, string methodName)
        {
            if(logger.IsEnabled(logLevel))
            {
                var logData = new LogSchema { ClassName = className, MethodName = GetMethodName(methodName), IsEnd = false };
                logger.LogInformation(JsonConvert.SerializeObject(logData));
                return Stopwatch.StartNew();
            }
            return null;
        }
        public static void EndStopStopWatch(Stopwatch watch, ILogger logger, string className, string methodName)
        {
            if (logger.IsEnabled(logLevel))
            {
                watch.Stop();
                TimeSpan ts = watch.Elapsed;
                var logData = new LogSchema { ClassName = className, MethodName = GetMethodName(methodName), IsEnd = true, TimeTaken= String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10)
                };
                logger.LogInformation(JsonConvert.SerializeObject(logData));                
            }            
        }


        private static string GetMethodName(string methodName)
        {
            Regex regex = new Regex("");
            return regex.Match(methodName).Value;
        }

        public static async Task RunLogsAsync(ILogger logger, Func<Task> methodToRun)
        {
            var watch = StartStopWatch(logger, methodToRun.Target.ToString(), methodToRun.Method.Name);
            await methodToRun();
            EndStopStopWatch(watch, logger, methodToRun.Target.ToString(), methodToRun.Method.Name);
        }
    }
}
