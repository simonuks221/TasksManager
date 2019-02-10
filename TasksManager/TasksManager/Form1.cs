using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;




namespace TasksManager
{
    public partial class TasksManager : Form
    {
        List<TaskClass> allTasks = new List<TaskClass>();
        int currentlySelectedIndex;
        List<TaskButton> allPlayControlls = new List<TaskButton>();

        public Size taskButtonSize = new Size(650, 30);

        public TasksManager()
        {
            InitializeComponent();
        }

        private void TasksManager_Load(object sender, EventArgs e)
        {
            CurrentTimeTimer.Start();
            NewTaskPanel.Visible = false;
            currentlySelectedIndex = -1;
            OpenTasksFromFile();
            SortByTime();
            SortByComboBox.SelectedIndex = 1;
        }

        private void NewTaskButton_Click(object sender, EventArgs e) //Add new task
        {
            NewTaskDescriptiontextBox.Text = ""; //Reset info fields
            NewTaskNameTextBox.Text = "";
            NewTaskImportanceComboBox.SelectedIndex = 0;
            NewTaskDatePicker.Value = DateTime.Now;
            newTaskTimePicker.Value = DateTime.Now;
            NewTaskPanel.Visible = true;

            NewTaskNameTextBox.Select();
        }

        private void SortByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortTaskList();
        }

        private void TasksManager_FormClosing(object sender, FormClosingEventArgs e) //Save on form close
        {
            SaveTasksToFile();
        }

        private void AddNewTaskButton_Click(object sender, EventArgs e) //Add task completed
        {
            if (NewTaskImportanceComboBox.SelectedIndex != -1 && NewTaskNameTextBox.Text != "")
            {
                TaskImportance taskImportance = (TaskImportance)NewTaskImportanceComboBox.SelectedIndex;
                DateTime taskDateTime = TimeHelper.ChangeTime(NewTaskDatePicker.Value, newTaskTimePicker.Value.Hour, newTaskTimePicker.Value.Minute, newTaskTimePicker.Value.Second, newTaskTimePicker.Value.Millisecond);

                TaskClass newTask = new TaskClass(NewTaskNameTextBox.Text, NewTaskDescriptiontextBox.Text, taskImportance, taskDateTime);
                allTasks.Add(newTask);

                SortTaskList();

                NewTaskPanel.Visible = false;
                SaveTasksToFile();
            }
        }

        void SortTaskList()
        {
            switch (SortByComboBox.SelectedIndex)
            {
                case 1: //Time
                    SortByTime();
                    break;
                case 2: //Importance
                    SortByImportance();
                    break;
            }
            DisplayAllTasks();
        }

        void SortByImportance()
        {
            bool repeat = true;
            while (repeat)
            {
                repeat = false;
                for (int i = 0; i < allTasks.Count - 1; i++)
                {
                    if(allTasks[i + 1].taskImportance > allTasks[i].taskImportance) //Swap by importance
                    {
                        TaskClass t = allTasks[i + 1];
                        allTasks[i + 1] = allTasks[i];
                        allTasks[i] = t;
                        repeat = true;
                    }
                }
            }
        }

        void SortByTime()
        {
            bool repeat = true;
            while (repeat)
            {
                repeat = false;
                for(int i = 0; i < allTasks.Count - 1; i++)
                {
                    if(allTasks[i].taskDateAndTime > allTasks[i + 1].taskDateAndTime)
                    {
                        TaskClass taskClass = allTasks[i + 1];
                        allTasks[i + 1] = allTasks[i];
                        allTasks[i] = taskClass;
                        repeat = true;
                    }
                }
            }
        }

        void DisplayAllTasks()
        {
            foreach (Control c in allPlayControlls) //Remove all tasks first
            {
                c.Dispose();
            }
            allPlayControlls.Clear();

            for (int i = 0; i < allTasks.Count; i++)
            {
                TaskButton taskButton = new TaskButton(allTasks[i], i, this);
                tasksPanel.Controls.Add(taskButton);
                taskButton.Location = new Point(0, i * 30 + i * 5);
                allPlayControlls.Add(taskButton);
            }
        }

        private void CurrentTimeTimer_Tick(object sender, EventArgs e) //Display and update current time
        {
            MainTimeLabel.Text = DateTime.Now.ToString();

            foreach(TaskButton t in allPlayControlls)
            {
                t.UpdateLeftAmountOfTime();
            }
        }

        public void TaskButtonPressed(int _index) //Task selected
        {
            if(_index == currentlySelectedIndex) //Same task selected
            {
                allPlayControlls[currentlySelectedIndex].Size = taskButtonSize;
                for(int i = currentlySelectedIndex; i < allPlayControlls.Count; i++)
                {
                    allPlayControlls[i].Location = new Point(0, i * 30 + i * 5);
                }

                currentlySelectedIndex = -1;
            }
            else //Different task selected
            {
                if(currentlySelectedIndex != -1)
                {
                    allPlayControlls[currentlySelectedIndex].Size = taskButtonSize;
                }
                currentlySelectedIndex = _index;
                allPlayControlls[currentlySelectedIndex].Size = new Size(650, 100);
                allPlayControlls[currentlySelectedIndex].Location = new Point(0, currentlySelectedIndex * 30 + currentlySelectedIndex * 5);
                for (int i = currentlySelectedIndex + 1; i < allPlayControlls.Count; i++)
                {
                    allPlayControlls[i].Location = new Point(0, i * 30 + i * 5 + 75);
                }
            }
        }

        private void NewTaskCancelButton_Click(object sender, EventArgs e) //Hide new new task panel
        {
            NewTaskPanel.Visible = false;
        }

        public void RemoveTask(int index)
        {
            allTasks.RemoveAt(index);
            DisplayAllTasks();
            SaveTasksToFile();
        }

        void SaveTasksToFile()
        {
            Stream stream = File.Open("tasksData.dat", FileMode.Create); //if doesnt exist, create
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, allTasks);
            stream.Close();
        }

        void OpenTasksFromFile()
        {
            if (File.Exists("tasksData.dat")) //Check if file exists
            {
                using (Stream stream = File.Open("tasksData.dat", FileMode.Open))
                {
                    var bformatter = new BinaryFormatter();
                    try
                    {
                        allTasks = (List<TaskClass>)bformatter.Deserialize(stream);
                    }
                    catch (SerializationException) //File is corrupted, delete it and create a new one
                    {
                        stream.Close();
                        File.Delete("tasksData.dat");
                        SaveTasksToFile();
                    }
                    stream.Close();
                }
            }
            else //File doesnt exist, create new
            {
                SaveTasksToFile();
            }
        }
    }

    public static class TimeHelper //Helps to set time
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        public static string TimeToString(DateTime _dateTime, out bool positive) //Convert time to readable string
        {
            TimeSpan timeSpan = _dateTime - DateTime.Now;
            bool newPositive = false;
            string timeString = "";
            if (timeSpan > TimeSpan.Zero) { timeString += "Time left: "; newPositive = true; } else { timeString += "Time behind: "; newPositive = false; }
            timeSpan = timeSpan.Duration();
            if (timeSpan.Days != 0) timeString += timeSpan.Days + "d ";
            if (timeSpan.Hours != 0) timeString += timeSpan.Hours + "h ";
            if (timeSpan.Minutes != 0) timeString += timeSpan.Minutes + "min ";
            if (timeSpan.Seconds != 0) timeString += timeSpan.Seconds + "s ";

            positive = newPositive;
            return timeString;
        }
    }
}
