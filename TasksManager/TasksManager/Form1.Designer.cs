namespace TasksManager
{
    partial class TasksManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tasksPanel = new System.Windows.Forms.Panel();
            this.TasksManagerLabel = new System.Windows.Forms.Label();
            this.MainTimeLabel = new System.Windows.Forms.Label();
            this.NewTaskButton = new System.Windows.Forms.Button();
            this.CurrentTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.NewTaskPanel = new System.Windows.Forms.Panel();
            this.AddNewTaskButton = new System.Windows.Forms.Button();
            this.NewTaskCancelButton = new System.Windows.Forms.Button();
            this.NewTaskImportanceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewTaskDatePicker = new System.Windows.Forms.DateTimePicker();
            this.newTaskTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NewTaskDescriptiontextBox = new System.Windows.Forms.TextBox();
            this.NewTaskNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.useAnimationsCheckBox = new System.Windows.Forms.CheckBox();
            this.NewTaskPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tasksPanel
            // 
            this.tasksPanel.AutoScroll = true;
            this.tasksPanel.Location = new System.Drawing.Point(56, 113);
            this.tasksPanel.Name = "tasksPanel";
            this.tasksPanel.Size = new System.Drawing.Size(687, 322);
            this.tasksPanel.TabIndex = 1;
            // 
            // TasksManagerLabel
            // 
            this.TasksManagerLabel.AutoSize = true;
            this.TasksManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TasksManagerLabel.Location = new System.Drawing.Point(12, 9);
            this.TasksManagerLabel.Name = "TasksManagerLabel";
            this.TasksManagerLabel.Size = new System.Drawing.Size(148, 25);
            this.TasksManagerLabel.TabIndex = 2;
            this.TasksManagerLabel.Text = "Tasks manager";
            // 
            // MainTimeLabel
            // 
            this.MainTimeLabel.AutoSize = true;
            this.MainTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.MainTimeLabel.Location = new System.Drawing.Point(315, 24);
            this.MainTimeLabel.Name = "MainTimeLabel";
            this.MainTimeLabel.Size = new System.Drawing.Size(118, 25);
            this.MainTimeLabel.TabIndex = 3;
            this.MainTimeLabel.Text = "Current time";
            // 
            // NewTaskButton
            // 
            this.NewTaskButton.Location = new System.Drawing.Point(65, 74);
            this.NewTaskButton.Name = "NewTaskButton";
            this.NewTaskButton.Size = new System.Drawing.Size(131, 30);
            this.NewTaskButton.TabIndex = 5;
            this.NewTaskButton.Text = "New task";
            this.NewTaskButton.UseVisualStyleBackColor = true;
            this.NewTaskButton.Click += new System.EventHandler(this.NewTaskButton_Click);
            // 
            // CurrentTimeTimer
            // 
            this.CurrentTimeTimer.Tick += new System.EventHandler(this.CurrentTimeTimer_Tick);
            // 
            // NewTaskPanel
            // 
            this.NewTaskPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NewTaskPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewTaskPanel.Controls.Add(this.AddNewTaskButton);
            this.NewTaskPanel.Controls.Add(this.NewTaskCancelButton);
            this.NewTaskPanel.Controls.Add(this.NewTaskImportanceComboBox);
            this.NewTaskPanel.Controls.Add(this.label3);
            this.NewTaskPanel.Controls.Add(this.NewTaskDatePicker);
            this.NewTaskPanel.Controls.Add(this.newTaskTimePicker);
            this.NewTaskPanel.Controls.Add(this.NewTaskDescriptiontextBox);
            this.NewTaskPanel.Controls.Add(this.NewTaskNameTextBox);
            this.NewTaskPanel.Controls.Add(this.label2);
            this.NewTaskPanel.Controls.Add(this.label1);
            this.NewTaskPanel.Location = new System.Drawing.Point(159, 101);
            this.NewTaskPanel.Name = "NewTaskPanel";
            this.NewTaskPanel.Size = new System.Drawing.Size(541, 331);
            this.NewTaskPanel.TabIndex = 6;
            // 
            // AddNewTaskButton
            // 
            this.AddNewTaskButton.Location = new System.Drawing.Point(418, 281);
            this.AddNewTaskButton.Name = "AddNewTaskButton";
            this.AddNewTaskButton.Size = new System.Drawing.Size(120, 47);
            this.AddNewTaskButton.TabIndex = 9;
            this.AddNewTaskButton.Text = "Add task";
            this.AddNewTaskButton.UseVisualStyleBackColor = true;
            this.AddNewTaskButton.Click += new System.EventHandler(this.AddNewTaskButton_Click);
            // 
            // NewTaskCancelButton
            // 
            this.NewTaskCancelButton.Location = new System.Drawing.Point(509, 3);
            this.NewTaskCancelButton.Name = "NewTaskCancelButton";
            this.NewTaskCancelButton.Size = new System.Drawing.Size(29, 23);
            this.NewTaskCancelButton.TabIndex = 8;
            this.NewTaskCancelButton.Text = "X";
            this.NewTaskCancelButton.UseVisualStyleBackColor = true;
            this.NewTaskCancelButton.Click += new System.EventHandler(this.NewTaskCancelButton_Click);
            // 
            // NewTaskImportanceComboBox
            // 
            this.NewTaskImportanceComboBox.FormattingEnabled = true;
            this.NewTaskImportanceComboBox.Items.AddRange(new object[] {
            "Not important",
            "Normal",
            "Important",
            "Extremely important"});
            this.NewTaskImportanceComboBox.Location = new System.Drawing.Point(400, 50);
            this.NewTaskImportanceComboBox.Name = "NewTaskImportanceComboBox";
            this.NewTaskImportanceComboBox.Size = new System.Drawing.Size(121, 21);
            this.NewTaskImportanceComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(213, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Task deadline";
            // 
            // NewTaskDatePicker
            // 
            this.NewTaskDatePicker.Location = new System.Drawing.Point(48, 223);
            this.NewTaskDatePicker.Name = "NewTaskDatePicker";
            this.NewTaskDatePicker.Size = new System.Drawing.Size(200, 20);
            this.NewTaskDatePicker.TabIndex = 5;
            // 
            // newTaskTimePicker
            // 
            this.newTaskTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.newTaskTimePicker.Location = new System.Drawing.Point(264, 223);
            this.newTaskTimePicker.Name = "newTaskTimePicker";
            this.newTaskTimePicker.ShowUpDown = true;
            this.newTaskTimePicker.Size = new System.Drawing.Size(200, 20);
            this.newTaskTimePicker.TabIndex = 4;
            // 
            // NewTaskDescriptiontextBox
            // 
            this.NewTaskDescriptiontextBox.Location = new System.Drawing.Point(118, 74);
            this.NewTaskDescriptiontextBox.Multiline = true;
            this.NewTaskDescriptiontextBox.Name = "NewTaskDescriptiontextBox";
            this.NewTaskDescriptiontextBox.Size = new System.Drawing.Size(270, 116);
            this.NewTaskDescriptiontextBox.TabIndex = 3;
            // 
            // NewTaskNameTextBox
            // 
            this.NewTaskNameTextBox.Location = new System.Drawing.Point(180, 35);
            this.NewTaskNameTextBox.Name = "NewTaskNameTextBox";
            this.NewTaskNameTextBox.Size = new System.Drawing.Size(154, 20);
            this.NewTaskNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(395, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Task importance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(223, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "New task\r\n";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "Default",
            "Time",
            "Importance"});
            this.SortByComboBox.Location = new System.Drawing.Point(622, 74);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(121, 21);
            this.SortByComboBox.TabIndex = 7;
            this.SortByComboBox.SelectedIndexChanged += new System.EventHandler(this.SortByComboBox_SelectedIndexChanged);
            // 
            // useAnimationsCheckBox
            // 
            this.useAnimationsCheckBox.AutoSize = true;
            this.useAnimationsCheckBox.Checked = true;
            this.useAnimationsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAnimationsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.useAnimationsCheckBox.Location = new System.Drawing.Point(662, 456);
            this.useAnimationsCheckBox.Name = "useAnimationsCheckBox";
            this.useAnimationsCheckBox.Size = new System.Drawing.Size(124, 21);
            this.useAnimationsCheckBox.TabIndex = 8;
            this.useAnimationsCheckBox.Text = "Use animations";
            this.useAnimationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // TasksManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 489);
            this.Controls.Add(this.useAnimationsCheckBox);
            this.Controls.Add(this.SortByComboBox);
            this.Controls.Add(this.NewTaskPanel);
            this.Controls.Add(this.NewTaskButton);
            this.Controls.Add(this.MainTimeLabel);
            this.Controls.Add(this.TasksManagerLabel);
            this.Controls.Add(this.tasksPanel);
            this.Name = "TasksManager";
            this.Text = "Tasks manager";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TasksManager_FormClosing);
            this.Load += new System.EventHandler(this.TasksManager_Load);
            this.NewTaskPanel.ResumeLayout(false);
            this.NewTaskPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tasksPanel;
        private System.Windows.Forms.Label TasksManagerLabel;
        private System.Windows.Forms.Label MainTimeLabel;
        private System.Windows.Forms.Button NewTaskButton;
        private System.Windows.Forms.Timer CurrentTimeTimer;
        private System.Windows.Forms.Panel NewTaskPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker newTaskTimePicker;
        private System.Windows.Forms.TextBox NewTaskDescriptiontextBox;
        private System.Windows.Forms.TextBox NewTaskNameTextBox;
        private System.Windows.Forms.ComboBox NewTaskImportanceComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker NewTaskDatePicker;
        private System.Windows.Forms.Button NewTaskCancelButton;
        private System.Windows.Forms.Button AddNewTaskButton;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.CheckBox useAnimationsCheckBox;
    }
}

