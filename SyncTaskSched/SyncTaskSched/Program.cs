using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;

namespace SyncTaskSched
{
    class Program
    {
        private static String EXEPATH = "C:\\Users\\sergi\\Desktop\\Politechnika Lodzka\\INTERNET APPLICATIONS PROGRAMMING\\WCF_SOAP_REST\\git\\newtry\\chocolatefactory\\UpdateService\\UpdateService\\bin\\Release\\UpdateService.exe";
        static void Main(string[] args)
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Updates product stock every 4 hours.";

                var dtrig = new DailyTrigger();
                dtrig.StartBoundary = DateTime.Now;
                dtrig.Repetition.Interval = TimeSpan.FromHours(1);
                td.Triggers.Add(dtrig);

                td.Actions.Add(new ExecAction(EXEPATH));

                ts.RootFolder.RegisterTaskDefinition("StockUpdate", td);
            } 
        }
    }
}
