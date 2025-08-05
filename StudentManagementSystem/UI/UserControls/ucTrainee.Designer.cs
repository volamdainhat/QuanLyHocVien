namespace StudentManagementSystem.UI.UserControls
{
    partial class ucTrainee
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnInformation = new Panel();
            groupBox = new GroupBox();
            tableLayoutPanel = new TableLayoutPanel();
            tabControl = new TabControl();
            tabTrainees = new TabPage();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dayOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rankingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enlistmentDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            averageScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fatherFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fatherPhoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            motherFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            motherPhoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            avatarBase64StringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            traineeBindingSource = new BindingSource(components);
            pnInformation.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabTrainees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)traineeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // pnInformation
            // 
            pnInformation.Controls.Add(groupBox);
            pnInformation.Dock = DockStyle.Fill;
            pnInformation.Location = new Point(3, 3);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(1274, 354);
            pnInformation.TabIndex = 0;
            // 
            // groupBox
            // 
            groupBox.Dock = DockStyle.Fill;
            groupBox.Location = new Point(0, 0);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(1274, 354);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Thông tin học viên";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Controls.Add(pnInformation, 0, 0);
            tableLayoutPanel.Controls.Add(tabControl, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(1280, 720);
            tableLayoutPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTrainees);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 363);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1274, 354);
            tabControl.TabIndex = 1;
            // 
            // tabTrainees
            // 
            tabTrainees.Controls.Add(dataGridView1);
            tabTrainees.Location = new Point(4, 34);
            tabTrainees.Name = "tabTrainees";
            tabTrainees.Padding = new Padding(3);
            tabTrainees.Size = new Size(1266, 316);
            tabTrainees.TabIndex = 0;
            tabTrainees.Text = "Danh sách";
            tabTrainees.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, classIdDataGridViewTextBoxColumn, classDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, dayOfBirthDataGridViewTextBoxColumn, rankingDataGridViewTextBoxColumn, enlistmentDateDataGridViewTextBoxColumn, averageScoreDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, fatherFullNameDataGridViewTextBoxColumn, fatherPhoneNumberDataGridViewTextBoxColumn, motherFullNameDataGridViewTextBoxColumn, motherPhoneNumberDataGridViewTextBoxColumn, avatarBase64StringDataGridViewTextBoxColumn });
            dataGridView1.DataSource = traineeBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1260, 310);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 150;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            classIdDataGridViewTextBoxColumn.HeaderText = "ClassId";
            classIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            classIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // classDataGridViewTextBoxColumn
            // 
            classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            classDataGridViewTextBoxColumn.HeaderText = "Class";
            classDataGridViewTextBoxColumn.MinimumWidth = 8;
            classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            classDataGridViewTextBoxColumn.Width = 150;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // dayOfBirthDataGridViewTextBoxColumn
            // 
            dayOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.HeaderText = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.MinimumWidth = 8;
            dayOfBirthDataGridViewTextBoxColumn.Name = "dayOfBirthDataGridViewTextBoxColumn";
            dayOfBirthDataGridViewTextBoxColumn.Width = 150;
            // 
            // rankingDataGridViewTextBoxColumn
            // 
            rankingDataGridViewTextBoxColumn.DataPropertyName = "Ranking";
            rankingDataGridViewTextBoxColumn.HeaderText = "Ranking";
            rankingDataGridViewTextBoxColumn.MinimumWidth = 8;
            rankingDataGridViewTextBoxColumn.Name = "rankingDataGridViewTextBoxColumn";
            rankingDataGridViewTextBoxColumn.Width = 150;
            // 
            // enlistmentDateDataGridViewTextBoxColumn
            // 
            enlistmentDateDataGridViewTextBoxColumn.DataPropertyName = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.HeaderText = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            enlistmentDateDataGridViewTextBoxColumn.Name = "enlistmentDateDataGridViewTextBoxColumn";
            enlistmentDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // averageScoreDataGridViewTextBoxColumn
            // 
            averageScoreDataGridViewTextBoxColumn.DataPropertyName = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.HeaderText = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            averageScoreDataGridViewTextBoxColumn.Name = "averageScoreDataGridViewTextBoxColumn";
            averageScoreDataGridViewTextBoxColumn.Width = 150;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.MinimumWidth = 8;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.Width = 150;
            // 
            // fatherFullNameDataGridViewTextBoxColumn
            // 
            fatherFullNameDataGridViewTextBoxColumn.DataPropertyName = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.HeaderText = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherFullNameDataGridViewTextBoxColumn.Name = "fatherFullNameDataGridViewTextBoxColumn";
            fatherFullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // fatherPhoneNumberDataGridViewTextBoxColumn
            // 
            fatherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherPhoneNumberDataGridViewTextBoxColumn.Name = "fatherPhoneNumberDataGridViewTextBoxColumn";
            fatherPhoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // motherFullNameDataGridViewTextBoxColumn
            // 
            motherFullNameDataGridViewTextBoxColumn.DataPropertyName = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.HeaderText = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherFullNameDataGridViewTextBoxColumn.Name = "motherFullNameDataGridViewTextBoxColumn";
            motherFullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // motherPhoneNumberDataGridViewTextBoxColumn
            // 
            motherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherPhoneNumberDataGridViewTextBoxColumn.Name = "motherPhoneNumberDataGridViewTextBoxColumn";
            motherPhoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // avatarBase64StringDataGridViewTextBoxColumn
            // 
            avatarBase64StringDataGridViewTextBoxColumn.DataPropertyName = "AvatarBase64String";
            avatarBase64StringDataGridViewTextBoxColumn.HeaderText = "AvatarBase64String";
            avatarBase64StringDataGridViewTextBoxColumn.MinimumWidth = 8;
            avatarBase64StringDataGridViewTextBoxColumn.Name = "avatarBase64StringDataGridViewTextBoxColumn";
            avatarBase64StringDataGridViewTextBoxColumn.Width = 150;
            // 
            // traineeBindingSource
            // 
            traineeBindingSource.DataSource = typeof(Domain.Entities.Trainee);
            // 
            // ucTrainee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "ucTrainee";
            Size = new Size(1280, 720);
            Load += ucTrainee_Load;
            pnInformation.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabTrainees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)traineeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnInformation;
        private TableLayoutPanel tableLayoutPanel;
        private TabControl tabControl;
        private TabPage tabTrainees;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dayOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rankingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enlistmentDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn averageScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fatherFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fatherPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motherFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motherPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn avatarBase64StringDataGridViewTextBoxColumn;
        private BindingSource traineeBindingSource;
        private GroupBox groupBox;
    }
}
