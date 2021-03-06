﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksManager
{

    class TaskButton : Panel
    {
        public TaskClass taskClass;
        int index;
        TasksManager tasksManager;

        ComboBox importanceComboBox;
        TextBox taskNametextBox;
        TextBox taskDescriptionTextBox;
        Label taskDateAndTime;
        Label taskDateAndTimeLeft;
        Button deleteTaskButton;
        Button editTaskButton;
        PictureBox googlePictureBox;

        public int numOfLines = 0;

        public TaskButton(TaskClass _taskClass, int _index, TasksManager _tasksManager)
        {
            taskClass = _taskClass;
            Text = taskClass.taskName;
            index = _index;
            tasksManager = _tasksManager;
            if(taskClass.taskDescription != null)
            {
                numOfLines = taskClass.taskDescription.Split('\n').Length;
            }

            this.Size = tasksManager.taskButtonSize;
            this.BackColor = System.Drawing.Color.LightGray;

            importanceComboBox = new ComboBox(); //Setum importance combo box
            this.Controls.Add(importanceComboBox);
            importanceComboBox.Location = new System.Drawing.Point(500, 6);
            importanceComboBox.Items.AddRange(new string[4] {"Not important", "Normal", "Important", "Extremely important"});
            importanceComboBox.SelectedIndex = (int)taskClass.taskImportance;
            importanceComboBox.Enabled = false;

            taskDescriptionTextBox = new TextBox(); //Setup description
            this.Controls.Add(taskDescriptionTextBox);
            taskDescriptionTextBox.Location = new System.Drawing.Point(20, 30);
            taskDescriptionTextBox.Text = taskClass.taskDescription;
            taskDescriptionTextBox.Enabled = false;
            taskDescriptionTextBox.Multiline = true;
            taskDescriptionTextBox.Size = new System.Drawing.Size(450, 90);

            taskNametextBox = new TextBox(); //Setup name
            this.Controls.Add(taskNametextBox);
            taskNametextBox.Location = new System.Drawing.Point(20, 6);
            taskNametextBox.Text = taskClass.taskName;
            taskNametextBox.Enabled = false;
            taskNametextBox.Size = new System.Drawing.Size(300, 30);

            taskDateAndTime = new Label(); //Setup deadline text
            this.Controls.Add(taskDateAndTime);
            taskDateAndTime.Location = new System.Drawing.Point(500, 30);
            taskDateAndTime.Text = taskClass.taskDateAndTime.ToString();

            taskDateAndTimeLeft = new Label(); //Setup time left
            this.Controls.Add(taskDateAndTimeLeft);
            taskDateAndTimeLeft.Location = new System.Drawing.Point(330, 9);
            taskDateAndTimeLeft.Size = new System.Drawing.Size(150, 13);
            taskDateAndTimeLeft.Text = (taskClass.taskDateAndTime - DateTime.Now).ToString();
            taskDateAndTimeLeft.Click += TaskDateAndTimeLeftClicked;

            deleteTaskButton = new Button(); //Setup delete button
            this.Controls.Add(deleteTaskButton);
            deleteTaskButton.Location = new System.Drawing.Point(615, 30);
            deleteTaskButton.Size = new System.Drawing.Size(20, 20);
            deleteTaskButton.Text = "X";
            deleteTaskButton.Click += DeleteButtonClicked;

            editTaskButton = new Button(); //Setup edit button
            this.Controls.Add(editTaskButton);
            editTaskButton.Location = new System.Drawing.Point(615, 55);
            editTaskButton.Size = new System.Drawing.Size(20, 20);
            editTaskButton.Text = "E";
            editTaskButton.Click += EditTaskButtonClicked;

            if (taskClass.googleTask)
            {
                googlePictureBox = new PictureBox(); //Setup edit button
                this.Controls.Add(googlePictureBox);
                googlePictureBox.Location = new Point(610, 80);
                googlePictureBox.Size = new Size(30, 30);       
                googlePictureBox.Image = Image.FromFile("google.jpg");
            }
        }

        private void TaskDateAndTimeLeftClicked(object sender, EventArgs e) //text pressed 
        {
            OnClick(e);
        }

        private void EditTaskButtonClicked(object sender, EventArgs e)
        {
            if (importanceComboBox.Enabled) //is changing, save changes
            {
                taskClass.taskImportance = (TaskImportance)importanceComboBox.SelectedIndex;
                taskClass.taskName = taskNametextBox.Text;
                taskClass.taskDescription = taskNametextBox.Text;
                numOfLines = taskClass.taskDescription.Split('\n').Length;

                importanceComboBox.Enabled = false;
                taskNametextBox.Enabled = false;
                taskDescriptionTextBox.Enabled = false;
            }
            else //Start changing
            {
                importanceComboBox.Enabled = true;
                taskNametextBox.Enabled = true;
                taskDescriptionTextBox.Enabled = true;
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            tasksManager.RemoveTask(index);
        }

        protected override void OnClick(EventArgs e)
        {
            //base.OnClick(e);
            if (importanceComboBox.Enabled) //Main button pressed while editing
            {
                EditTaskButtonClicked(null, e);
            }
            tasksManager.TaskButtonPressed(index);
        }

        public void UpdateLeftAmountOfTime()
        {
            taskDateAndTimeLeft.Text = TimeHelper.TimeToString(taskClass.taskTimeLeft);
            if (taskClass.positiveTime)
            {
                taskDateAndTimeLeft.ForeColor = Color.Black;
            }
            else
            {
                taskDateAndTimeLeft.ForeColor = Color.Red;
            }
        }
    }
}
