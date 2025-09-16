namespace StudentManagementSystem.UI.UserControls
{
    partial class ucStudentMonitoring
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
            groupBox1 = new GroupBox();
            splitContainer1 = new SplitContainer();
            cbClass = new ComboBox();
            groupBox3 = new GroupBox();
            label20 = new Label();
            cbResearchGrade = new ComboBox();
            label19 = new Label();
            cbStudyGrade = new ComboBox();
            label18 = new Label();
            cbDisciplineGrade = new ComboBox();
            label17 = new Label();
            cbLifestyleGrade = new ComboBox();
            label16 = new Label();
            cbStudyMovGrade = new ComboBox();
            label15 = new Label();
            cbPoliticalGrade = new ComboBox();
            cbResearchActivity = new ComboBox();
            cbAcademicResult = new ComboBox();
            cbDisciplineAwareness = new ComboBox();
            cbEthicsLifestyle = new ComboBox();
            cbStudyMotivation = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            cbPoliticalAttitude = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tpMisconduct = new TabPage();
            dgvMisconduct = new DataGridView();
            tpWeeklyCritique = new TabPage();
            dgvWeeklyCritique = new DataGridView();
            panel1 = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tpMisconduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMisconduct).BeginInit();
            tpWeeklyCritique.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWeeklyCritique).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1493, 914);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Theo dõi tình trang học tập - Vi phạm kỉ luật";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 17);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(cbClass);
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1487, 894);
            splitContainer1.SplitterDistance = 469;
            splitContainer1.TabIndex = 0;
            // 
            // cbClass
            // 
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(122, 20);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(198, 23);
            cbClass.TabIndex = 10;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(cbResearchGrade);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(cbStudyGrade);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(cbDisciplineGrade);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(cbLifestyleGrade);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(cbStudyMovGrade);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(cbPoliticalGrade);
            groupBox3.Controls.Add(cbResearchActivity);
            groupBox3.Controls.Add(cbAcademicResult);
            groupBox3.Controls.Add(cbDisciplineAwareness);
            groupBox3.Controls.Add(cbEthicsLifestyle);
            groupBox3.Controls.Add(cbStudyMotivation);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(cbPoliticalAttitude);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(681, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(712, 431);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bình rèn tuần ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(592, 377);
            label20.Name = "label20";
            label20.Size = new Size(37, 15);
            label20.TabIndex = 26;
            label20.Text = "Điểm";
            // 
            // cbResearchGrade
            // 
            cbResearchGrade.FormattingEnabled = true;
            cbResearchGrade.Location = new Point(635, 374);
            cbResearchGrade.Name = "cbResearchGrade";
            cbResearchGrade.Size = new Size(71, 23);
            cbResearchGrade.TabIndex = 25;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(592, 348);
            label19.Name = "label19";
            label19.Size = new Size(37, 15);
            label19.TabIndex = 24;
            label19.Text = "Điểm";
            // 
            // cbStudyGrade
            // 
            cbStudyGrade.FormattingEnabled = true;
            cbStudyGrade.Location = new Point(635, 345);
            cbStudyGrade.Name = "cbStudyGrade";
            cbStudyGrade.Size = new Size(71, 23);
            cbStudyGrade.TabIndex = 23;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(592, 237);
            label18.Name = "label18";
            label18.Size = new Size(37, 15);
            label18.TabIndex = 22;
            label18.Text = "Điểm";
            // 
            // cbDisciplineGrade
            // 
            cbDisciplineGrade.FormattingEnabled = true;
            cbDisciplineGrade.Location = new Point(635, 234);
            cbDisciplineGrade.Name = "cbDisciplineGrade";
            cbDisciplineGrade.Size = new Size(71, 23);
            cbDisciplineGrade.TabIndex = 21;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(592, 205);
            label17.Name = "label17";
            label17.Size = new Size(37, 15);
            label17.TabIndex = 20;
            label17.Text = "Điểm";
            // 
            // cbLifestyleGrade
            // 
            cbLifestyleGrade.FormattingEnabled = true;
            cbLifestyleGrade.Location = new Point(635, 202);
            cbLifestyleGrade.Name = "cbLifestyleGrade";
            cbLifestyleGrade.Size = new Size(71, 23);
            cbLifestyleGrade.TabIndex = 19;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(592, 104);
            label16.Name = "label16";
            label16.Size = new Size(37, 15);
            label16.TabIndex = 18;
            label16.Text = "Điểm";
            // 
            // cbStudyMovGrade
            // 
            cbStudyMovGrade.FormattingEnabled = true;
            cbStudyMovGrade.Location = new Point(635, 101);
            cbStudyMovGrade.Name = "cbStudyMovGrade";
            cbStudyMovGrade.Size = new Size(71, 23);
            cbStudyMovGrade.TabIndex = 17;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(592, 69);
            label15.Name = "label15";
            label15.Size = new Size(37, 15);
            label15.TabIndex = 16;
            label15.Text = "Điểm";
            // 
            // cbPoliticalGrade
            // 
            cbPoliticalGrade.FormattingEnabled = true;
            cbPoliticalGrade.Location = new Point(635, 66);
            cbPoliticalGrade.Name = "cbPoliticalGrade";
            cbPoliticalGrade.Size = new Size(71, 23);
            cbPoliticalGrade.TabIndex = 15;
            // 
            // cbResearchActivity
            // 
            cbResearchActivity.FormattingEnabled = true;
            cbResearchActivity.Location = new Point(203, 374);
            cbResearchActivity.Name = "cbResearchActivity";
            cbResearchActivity.Size = new Size(344, 23);
            cbResearchActivity.TabIndex = 14;
            // 
            // cbAcademicResult
            // 
            cbAcademicResult.FormattingEnabled = true;
            cbAcademicResult.Location = new Point(203, 345);
            cbAcademicResult.Name = "cbAcademicResult";
            cbAcademicResult.Size = new Size(344, 23);
            cbAcademicResult.TabIndex = 13;
            // 
            // cbDisciplineAwareness
            // 
            cbDisciplineAwareness.FormattingEnabled = true;
            cbDisciplineAwareness.Location = new Point(203, 234);
            cbDisciplineAwareness.Name = "cbDisciplineAwareness";
            cbDisciplineAwareness.Size = new Size(344, 23);
            cbDisciplineAwareness.TabIndex = 12;
            // 
            // cbEthicsLifestyle
            // 
            cbEthicsLifestyle.FormattingEnabled = true;
            cbEthicsLifestyle.Location = new Point(203, 205);
            cbEthicsLifestyle.Name = "cbEthicsLifestyle";
            cbEthicsLifestyle.Size = new Size(344, 23);
            cbEthicsLifestyle.TabIndex = 11;
            // 
            // cbStudyMotivation
            // 
            cbStudyMotivation.FormattingEnabled = true;
            cbStudyMotivation.Location = new Point(203, 96);
            cbStudyMotivation.Name = "cbStudyMotivation";
            cbStudyMotivation.Size = new Size(344, 23);
            cbStudyMotivation.TabIndex = 10;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(29, 382);
            label14.Name = "label14";
            label14.Size = new Size(127, 15);
            label14.TabIndex = 9;
            label14.Text = "Nghiên cứu khoa học ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(29, 350);
            label13.Name = "label13";
            label13.Size = new Size(92, 15);
            label13.TabIndex = 8;
            label13.Text = "Kết quả học tập";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(29, 242);
            label12.Name = "label12";
            label12.Size = new Size(137, 15);
            label12.TabIndex = 7;
            label12.Text = "Ý thức chấp hành kỉ luật";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 213);
            label11.Name = "label11";
            label11.Size = new Size(164, 15);
            label11.TabIndex = 6;
            label11.Text = "Phẩm chất đạo đức, lối sống";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 104);
            label10.Name = "label10";
            label10.Size = new Size(140, 15);
            label10.TabIndex = 5;
            label10.Text = "Động cơ, thái độ học tập";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 69);
            label9.Name = "label9";
            label9.Size = new Size(147, 15);
            label9.TabIndex = 4;
            label9.Text = "Thái độ chính trị, tư tưởng";
            // 
            // cbPoliticalAttitude
            // 
            cbPoliticalAttitude.FormattingEnabled = true;
            cbPoliticalAttitude.Location = new Point(203, 66);
            cbPoliticalAttitude.Name = "cbPoliticalAttitude";
            cbPoliticalAttitude.Size = new Size(344, 23);
            cbPoliticalAttitude.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 322);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 2;
            label8.Text = "Tiêu chí 3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 176);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 1;
            label7.Text = "Tiêu chí 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 31);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 0;
            label6.Text = "Tiêu chí 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(18, 206);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(426, 248);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Vi phạm";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 124);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 90);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 127);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 9;
            label5.Text = "Mô tả vi phạm";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(117, 86);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 21);
            dateTimePicker1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 86);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 7;
            label3.Text = "Ngày vi phạm";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(117, 34);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 37);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 5;
            label4.Text = "Loại vi phạm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 23);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Lớp";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(122, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 71);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Học viên";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpMisconduct);
            tabControl1.Controls.Add(tpWeeklyCritique);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1487, 392);
            tabControl1.TabIndex = 2;
            // 
            // tpMisconduct
            // 
            tpMisconduct.Controls.Add(dgvMisconduct);
            tpMisconduct.Location = new Point(4, 24);
            tpMisconduct.Name = "tpMisconduct";
            tpMisconduct.Padding = new Padding(3);
            tpMisconduct.Size = new Size(1479, 364);
            tpMisconduct.TabIndex = 0;
            tpMisconduct.Text = "Vi phạm";
            tpMisconduct.UseVisualStyleBackColor = true;
            // 
            // dgvMisconduct
            // 
            dgvMisconduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMisconduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisconduct.Dock = DockStyle.Fill;
            dgvMisconduct.Location = new Point(3, 3);
            dgvMisconduct.Name = "dgvMisconduct";
            dgvMisconduct.Size = new Size(1473, 358);
            dgvMisconduct.TabIndex = 0;
            // 
            // tpWeeklyCritique
            // 
            tpWeeklyCritique.Controls.Add(dgvWeeklyCritique);
            tpWeeklyCritique.Location = new Point(4, 24);
            tpWeeklyCritique.Name = "tpWeeklyCritique";
            tpWeeklyCritique.Padding = new Padding(3);
            tpWeeklyCritique.Size = new Size(1479, 364);
            tpWeeklyCritique.TabIndex = 1;
            tpWeeklyCritique.Text = "Bình rèn";
            tpWeeklyCritique.UseVisualStyleBackColor = true;
            // 
            // dgvWeeklyCritique
            // 
            dgvWeeklyCritique.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWeeklyCritique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWeeklyCritique.Dock = DockStyle.Fill;
            dgvWeeklyCritique.Location = new Point(3, 3);
            dgvWeeklyCritique.Name = "dgvWeeklyCritique";
            dgvWeeklyCritique.Size = new Size(1473, 358);
            dgvWeeklyCritique.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 392);
            panel1.Name = "panel1";
            panel1.Size = new Size(1487, 29);
            panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(234, 0);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(156, 0);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Location = new Point(78, 0);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(78, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Left;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(78, 29);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ucStudentMonitoring
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucStudentMonitoring";
            Size = new Size(1493, 914);
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpMisconduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMisconduct).EndInit();
            tpWeeklyCritique.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWeeklyCritique).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Label label4;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAdd;
        private Button btnRefresh;
        private GroupBox groupBox3;
        private Label label8;
        private Label label7;
        private Label label6;
        private ComboBox cbResearchActivity;
        private ComboBox cbAcademicResult;
        private ComboBox cbDisciplineAwareness;
        private ComboBox cbEthicsLifestyle;
        private ComboBox cbStudyMotivation;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private ComboBox cbPoliticalAttitude;
        private Label label20;
        private ComboBox cbResearchGrade;
        private Label label19;
        private ComboBox cbStudyGrade;
        private Label label18;
        private ComboBox cbDisciplineGrade;
        private Label label17;
        private ComboBox cbLifestyleGrade;
        private Label label16;
        private ComboBox cbStudyMovGrade;
        private Label label15;
        private ComboBox cbPoliticalGrade;
        private TabControl tabControl1;
        private TabPage tpMisconduct;
        private TabPage tpWeeklyCritique;
        private DataGridView dgvMisconduct;
        private DataGridView dgvWeeklyCritique;
        private ComboBox cbClass;
    }
}
