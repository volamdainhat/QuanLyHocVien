using StudentManagementApp.Core.Interfaces.Services;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ReportListForm : Form
    {
        private readonly IReportService _reportService;
        private readonly IValidationService _validationService;
        //private DataGridView? dataGridView;
        private TabControl tabControl1;
        private TabPage tabMisconduct;
        private TabPage tabPracticePoint;
        private TabPage tabRollCall;
        private ComboBox cbTimeRange;
        private DateTimePicker dtpReportDate;
        private Button btnGenerate;
        private DataGridView dgvMisconductDetail;
        private DataGridView dgvMisconductSummary;
        private DataGridView dgvPracticePointDetail;
        private DataGridView dgvPracticePointSummary;
        private DataGridView dgvRollCallDetail;
        private DataGridView dgvRollCallSummary;
        private Label lblSummary;
        private Label lblDetail;

        public ReportListForm(
            IReportService reportService,
            IValidationService validationService)
        {
            _reportService = reportService;
            _validationService = validationService;
            InitializeComponent();
            InitializeReportList();
            ImproveDataGridViewAppearance();
        }

        private void InitializeReportList()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new TabControl();
            this.tabMisconduct = new TabPage();
            this.tabPracticePoint = new TabPage();
            this.tabRollCall = new TabPage();
            this.cbTimeRange = new ComboBox();
            this.dtpReportDate = new DateTimePicker();
            this.btnGenerate = new Button();

            // Misconduct Tab
            this.dgvMisconductDetail = new DataGridView();
            this.dgvMisconductSummary = new DataGridView();

            // PracticePoint Tab
            this.dgvPracticePointDetail = new DataGridView();
            this.dgvPracticePointSummary = new DataGridView();

            // RollCall Tab
            this.dgvRollCallDetail = new DataGridView();
            this.dgvRollCallSummary = new DataGridView();

            this.lblDetail = new Label();
            this.lblSummary = new Label();

            this.SuspendLayout();

            // Main Form
            this.Text = "Hệ thống Báo cáo";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Controls Panel
            var panel = new Panel { Dock = DockStyle.Top, Height = 60 };
            panel.Controls.Add(new Label { Text = "Thời gian:", Location = new Point(20, 20), AutoSize = true });
            panel.Controls.Add(this.cbTimeRange);
            panel.Controls.Add(this.dtpReportDate);
            panel.Controls.Add(this.btnGenerate);

            // Time Range ComboBox
            this.cbTimeRange.Location = new Point(100, 17);
            this.cbTimeRange.Size = new Size(120, 25);
            this.cbTimeRange.Items.AddRange(new[] { "Ngày", "Tuần", "Tháng" });
            this.cbTimeRange.SelectedIndex = 0;

            // Date Picker
            this.dtpReportDate.Location = new Point(240, 17);
            this.dtpReportDate.Size = new Size(200, 25);
            this.dtpReportDate.Value = DateTime.Now;

            // Generate Button
            this.btnGenerate.Location = new Point(460, 17);
            this.btnGenerate.Size = new Size(100, 25);
            this.btnGenerate.Text = "Tạo báo cáo";
            this.btnGenerate.Click += new EventHandler(this.btnGenerate_Click);

            // Tab Control
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 60);
            this.tabControl1.Size = new Size(1184, 601);

            this.InitializeMisconductTab();
            this.InitializePracticePointTab();
            this.InitializeRollCallTab();

            this.tabControl1.TabPages.AddRange(new TabPage[] {
                this.tabMisconduct, this.tabPracticePoint, this.tabRollCall
            });

            this.Controls.Add(this.tabControl1);
            this.Controls.Add(panel);
            this.ResumeLayout(false);
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedDate = dtpReportDate.Value;
                var timeRange = cbTimeRange.SelectedItem.ToString() switch
                {
                    "Ngày" => "day",
                    "Tuần" => "week",
                    "Tháng" => "month",
                    _ => "day"
                };

                await GenerateMisconductReports(selectedDate, timeRange);
                await GeneratePracticePointReports(selectedDate, timeRange);
                await GenerateRollCallReports(selectedDate, timeRange);

                MessageBox.Show("Đã tạo báo cáo thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GenerateMisconductReports(DateTime date, string timeRange)
        {
            // Chi tiết vi phạm
            var misconductDetail = await _reportService.GetMisconductDetailReportAsync(date, timeRange);
            dgvMisconductDetail.DataSource = misconductDetail.Select(m => new
            {
                m.Id,
                Học_viên = m.TraineeName,
                Loại_vi_phạm = m.Type,
                Thời_gian = m.Time.ToString("dd/MM/yyyy HH:mm"),
                Mô_tả = m.Description
            }).ToList();

            // Tổng hợp vi phạm
            var misconductSummary = await _reportService.GetMisconductSummaryReportAsync(date, timeRange);
            dgvMisconductSummary.DataSource = misconductSummary.Select(m => new
            {
                Loại_vi_phạm = m.Type,
                Số_lượng = m.Count,
                Thời_gian = m.Period.ToString("dd/MM/yyyy")
            }).ToList();
        }

        private async Task GeneratePracticePointReports(DateTime date, string timeRange)
        {
            // Chi tiết điểm thực hành
            var practicePointDetail = await _reportService.GetPracticePointDetailReportAsync(date, timeRange);
            dgvPracticePointDetail.DataSource = practicePointDetail.Select(p => new
            {
                p.Id,
                Học_viên = p.TraineeName,
                Nội_dung = p.Content,
                Điểm = p.Point,
                Thời_gian = p.Time.ToString("dd/MM/yyyy HH:mm"),
                Mô_tả = p.Description
            }).ToList();

            // Tổng hợp điểm thực hành
            var practicePointSummary = await _reportService.GetPracticePointSummaryReportAsync(date, timeRange);
            dgvPracticePointSummary.DataSource = practicePointSummary.Select(p => new
            {
                Nội_dung = p.Content,
                Tổng_điểm = p.TotalPoints,
                Thời_gian = p.Period.ToString("dd/MM/yyyy")
            }).ToList();
        }

        private async Task GenerateRollCallReports(DateTime date, string timeRange)
        {
            // Chi tiết điểm danh
            var rollCallDetail = await _reportService.GetRollCallDetailReportAsync(date, timeRange);
            dgvRollCallDetail.DataSource = rollCallDetail.Select(r => new
            {
                r.Id,
                Ngày = r.Date.ToString("dd/MM/yyyy"),
                Người_điểm_danh = r.RollCaller,
                Tổng_số = r.TotalStudents,
                Có_mặt = r.Present,
                Vắng_mặt = r.Absent,
                Tỷ_lệ = $"{((double)r.Present / r.TotalStudents * 100):0.00}%",
                Ghi_chú = r.Notes
            }).ToList();

            // Tổng hợp điểm danh
            var rollCallSummary = await _reportService.GetRollCallSummaryReportAsync(date, timeRange);
            dgvRollCallSummary.DataSource = new[]
            {
            new
            {
                Thời_gian = rollCallSummary.Period.ToString("dd/MM/yyyy"),
                Tổng_số_buổi = rollCallSummary.TotalSessions,
                Tỷ_lệ_điểm_danh_TB = $"{rollCallSummary.AverageAttendanceRate:0.00}%",
                Số_vắng_cao_nhất = rollCallSummary.MaxAbsent
            }
        }.ToList();
        }

        private void InitializeMisconductTab()
        {
            this.tabMisconduct.Text = "Vi phạm";

            // Detail Label
            var lblDetail = new Label { Text = "Chi tiết vi phạm", Location = new Point(10, 10), AutoSize = true };

            // Detail Grid
            this.dgvMisconductDetail.Location = new Point(10, 40);
            this.dgvMisconductDetail.Size = new Size(1150, 200);
            this.dgvMisconductDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisconductDetail.ReadOnly = true;

            // Summary Label
            var lblSummary = new Label { Text = "Tổng hợp vi phạm", Location = new Point(10, 250), AutoSize = true };

            // Summary Grid
            this.dgvMisconductSummary.Location = new Point(10, 280);
            this.dgvMisconductSummary.Size = new Size(1150, 200);
            this.dgvMisconductSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisconductSummary.ReadOnly = true;

            this.tabMisconduct.Controls.AddRange(new Control[] {
            lblDetail, this.dgvMisconductDetail, lblSummary, this.dgvMisconductSummary
        });
        }

        private void InitializePracticePointTab()
        {
            this.tabPracticePoint.Text = "Điểm thực hành";

            var lblDetail = new Label { Text = "Chi tiết điểm thực hành", Location = new Point(10, 10), AutoSize = true };

            this.dgvPracticePointDetail.Location = new Point(10, 40);
            this.dgvPracticePointDetail.Size = new Size(1150, 200);
            this.dgvPracticePointDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPracticePointDetail.ReadOnly = true;

            var lblSummary = new Label { Text = "Tổng hợp điểm thực hành", Location = new Point(10, 250), AutoSize = true };

            this.dgvPracticePointSummary.Location = new Point(10, 280);
            this.dgvPracticePointSummary.Size = new Size(1150, 200);
            this.dgvPracticePointSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPracticePointSummary.ReadOnly = true;

            this.tabPracticePoint.Controls.AddRange(new Control[] {
            lblDetail, this.dgvPracticePointDetail, lblSummary, this.dgvPracticePointSummary
        });
        }

        private void InitializeRollCallTab()
        {
            this.tabRollCall.Text = "Điểm danh";

            var lblDetail = new Label { Text = "Chi tiết điểm danh", Location = new Point(10, 10), AutoSize = true };

            this.dgvRollCallDetail.Location = new Point(10, 40);
            this.dgvRollCallDetail.Size = new Size(1150, 200);
            this.dgvRollCallDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRollCallDetail.ReadOnly = true;

            var lblSummary = new Label { Text = "Tổng hợp điểm danh", Location = new Point(10, 250), AutoSize = true };

            this.dgvRollCallSummary.Location = new Point(10, 280);
            this.dgvRollCallSummary.Size = new Size(1150, 200);
            this.dgvRollCallSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRollCallSummary.ReadOnly = true;

            this.tabRollCall.Controls.AddRange(new Control[] {
                lblDetail, this.dgvRollCallDetail, lblSummary, this.dgvRollCallSummary
            });
        }

        private void ImproveDataGridViewAppearance()
        {
            var allGrids = new[] {
                dgvMisconductDetail, dgvMisconductSummary,
                dgvPracticePointDetail, dgvPracticePointSummary,
                dgvRollCallDetail, dgvRollCallSummary
            };

            foreach (var grid in allGrids)
            {
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                grid.RowHeadersVisible = false;
            }
        }
    }
}
