using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksManager
{
    class GoogleCalendarManager
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Task manager google calendar API";
        UserCredential credential;
        CalendarService service;

        public GoogleCalendarManager(TasksManager tasksManager) //Setup tokens and stuff
        {
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";

                if (File.Exists(credPath))
                {
                    if (new DirectoryInfo(credPath).GetFiles().Length == 0) //Minimize if theres no token
                    {
                        tasksManager.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    }
                }
                else
                {
                    tasksManager.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                }

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
                stream.Close();
            }
            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            tasksManager.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        public void ChangeGoogleAccount()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo("token.json");
                foreach(FileInfo f in di.GetFiles())
                {
                    f.Delete(); //Delete token files to force new google login
                }
                di.Delete();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            credential = null;
            service = null;
        }

        public void deleteGoogleTask(Event newEvent)
        {
            //service.Events.Delete("primary", newEvent.Id).Execute(); Deleting from Google calendar doesnt work for some reason
        }

        public List<TaskClass> getGoogleTasks() //get all google upcoming tasks
        {
            List<TaskClass> googleTasks = new List<TaskClass>();

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string whenString = eventItem.Start.DateTime.ToString(); //Setup time and date of google task
                    if (String.IsNullOrEmpty(whenString))
                    {
                        whenString = eventItem.Start.Date;
                    }
                    DateTime when = DateTime.Parse(whenString);
                    TaskClass newTask = new TaskClass(eventItem.Summary, eventItem.Description, TaskImportance.Normal, when, true, eventItem);
                    googleTasks.Add(newTask);
                }
            }
            return googleTasks;
        }
    }
}
