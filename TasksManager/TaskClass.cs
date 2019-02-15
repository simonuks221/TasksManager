using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace TasksManager
{
    public enum TaskImportance {NotImportant, Normal, Important, ExtremelyImportant}

    [Serializable]
    class TaskClass : ISerializable
    {
        public string taskName;
        public string taskDescription;

        public DateTime taskDateAndTime;
        public bool positiveTime;
        public TimeSpan taskTimeLeft;

        public TaskImportance taskImportance;

        public TaskClass(string _taskName, string _taskDescription, TaskImportance _taskImportance, DateTime _taskDateAndTime)
        {
            taskName = _taskName;
            taskDescription = _taskDescription;
            taskImportance = _taskImportance;
            taskDateAndTime = _taskDateAndTime;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) //Serialize data
        {
            info.AddValue("Name", taskName);
            info.AddValue("Description", taskDescription);
            info.AddValue("DateAndTime", taskDateAndTime);
            info.AddValue("Importance", taskImportance);
        }

        public TaskClass(SerializationInfo info, StreamingContext context) //Deserialization
        {
            taskName = (string)info.GetValue("Name", typeof(string));
            taskDescription = (string)info.GetValue("Description", typeof(string));
            taskDateAndTime = (DateTime)info.GetValue("DateAndTime", typeof(DateTime));
            taskImportance = (TaskImportance)info.GetValue("Importance", typeof(TaskImportance));
        }
    }
}
