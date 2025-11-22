using OfficeOpenXml;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Reports;
using System.Windows.Forms;

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
        private Button btnExport;
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
            this.btnExport = new Button();

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
            panel.Controls.Add(this.btnExport);

            // Time Range ComboBox
            this.cbTimeRange.Location = new Point(120, 17);
            this.cbTimeRange.Size = new Size(120, 25);
            this.cbTimeRange.Items.AddRange(new[] { "Ngày", "Tuần", "Tháng" });
            this.cbTimeRange.SelectedIndex = 0;

            // Date Picker
            this.dtpReportDate.Location = new Point(260, 17);
            this.dtpReportDate.Size = new Size(200, 25);
            this.dtpReportDate.Value = DateTime.Now;
            this.dtpReportDate.Format = DateTimePickerFormat.Custom;
            this.dtpReportDate.CustomFormat = "dd/MM/yyyy";

            // Generate Button
            this.btnGenerate.Location = new Point(480, 17);
            this.btnGenerate.Size = new Size(120, 34);
            this.btnGenerate.Text = "Tạo báo cáo";
            this.btnGenerate.Click += new EventHandler(this.btnGenerate_Click);

            // Export Button
            this.btnExport.Location = new Point(620, 17);
            this.btnExport.Size = new Size(130, 34);
            this.btnExport.Text = "Xuất báo cáo";
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

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

        private async void btnExport_Click(object sender, EventArgs e)
        {
            var dataGridViews = new Dictionary<string, DataGridView>
            {
                { "Tổng hợp Kỷ luật", dgvMisconductSummary },
                { "Chi tiết Kỷ luật", dgvMisconductDetail },
                { "Tổng hợp Thực hành", dgvPracticePointSummary },
                { "Chi tiết Thực hành", dgvPracticePointDetail },
                { "Tổng hợp Điểm danh", dgvRollCallSummary },
                { "Chi tiết Điểm danh", dgvRollCallDetail },
            };

            ExportMultipleWithProgress(dataGridViews);
        }

        private async Task GenerateMisconductReports(DateTime date, string timeRange)
        {
            // Chi tiết vi phạm
            var misconductDetail = await _reportService.GetMisconductDetailReportAsync(date, timeRange);
            dgvMisconductDetail.DataSource = misconductDetail;
            dgvMisconductDetail.Columns["Time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Tổng hợp vi phạm
            var misconductSummary = await _reportService.GetMisconductSummaryReportAsync(date, timeRange);
            dgvMisconductSummary.DataSource = misconductSummary;
            dgvMisconductSummary.Columns["Period"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private async Task GeneratePracticePointReports(DateTime date, string timeRange)
        {
            // Chi tiết điểm thực hành
            var practicePointDetail = await _reportService.GetPracticePointDetailReportAsync(date, timeRange);
            dgvPracticePointDetail.DataSource = practicePointDetail;
            dgvPracticePointDetail.Columns["Time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Tổng hợp điểm thực hành
            var practicePointSummary = await _reportService.GetPracticePointSummaryReportAsync(date, timeRange);
            dgvPracticePointSummary.DataSource = practicePointSummary;
            dgvPracticePointSummary.Columns["Period"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private async Task GenerateRollCallReports(DateTime date, string timeRange)
        {
            // Chi tiết điểm danh
            var rollCallDetail = await _reportService.GetRollCallDetailReportAsync(date, timeRange);
            dgvRollCallDetail.DataSource = rollCallDetail;
            dgvRollCallDetail.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Tổng hợp điểm danh
            var rollCallSummary = await _reportService.GetRollCallSummaryReportAsync(date, timeRange);
            dgvRollCallSummary.DataSource = rollCallSummary;
            dgvRollCallSummary.Columns["FromDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRollCallSummary.Columns["ToDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void InitializeMisconductTab()
        {
            this.tabMisconduct.Text = "Vi phạm";

            var tblLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10),
            };

            // Summary Label
            var lblSummary = new Label
            {
                Text = "Tổng hợp vi phạm",
                Location = new Point(10, 10),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            // Summary Grid
            this.dgvMisconductSummary.Location = new Point(10, 40);
            this.dgvMisconductSummary.Size = new Size(1150, 200);
            this.dgvMisconductSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisconductSummary.ReadOnly = true;
            this.dgvMisconductSummary.Dock = DockStyle.Fill;

            // Detail Label
            var lblDetail = new Label
            {
                Text = "Chi tiết vi phạm",
                Location = new Point(10, 250),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            // Detail Grid
            this.dgvMisconductDetail.Location = new Point(10, 280);
            this.dgvMisconductDetail.Size = new Size(1150, 200);
            this.dgvMisconductDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisconductDetail.ReadOnly = true;
            this.dgvMisconductDetail.Dock = DockStyle.Fill;

            tblLayout.Controls.Add(lblSummary, 0, 0);
            tblLayout.Controls.Add(dgvMisconductSummary, 0, 1);
            tblLayout.Controls.Add(lblDetail, 0, 2);
            tblLayout.Controls.Add(dgvMisconductDetail, 0, 3);

            this.tabMisconduct.Controls.Add(tblLayout);
        }

        private void InitializePracticePointTab()
        {
            this.tabPracticePoint.Text = "Điểm thực hành";

            var tblLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10),
            };

            var lblSummary = new Label
            {
                Text = "Tổng hợp điểm thực hành",
                Location = new Point(10, 250),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            this.dgvPracticePointSummary.Location = new Point(10, 280);
            this.dgvPracticePointSummary.Size = new Size(1150, 200);
            this.dgvPracticePointSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPracticePointSummary.ReadOnly = true;
            this.dgvPracticePointSummary.Dock = DockStyle.Fill;

            var lblDetail = new Label
            {
                Text = "Chi tiết điểm thực hành",
                Location = new Point(10, 10),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            this.dgvPracticePointDetail.Location = new Point(10, 40);
            this.dgvPracticePointDetail.Size = new Size(1150, 200);
            this.dgvPracticePointDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPracticePointDetail.ReadOnly = true;
            this.dgvPracticePointDetail.Dock = DockStyle.Fill;

            tblLayout.Controls.Add(lblSummary, 0, 0);
            tblLayout.Controls.Add(dgvPracticePointSummary, 0, 1);
            tblLayout.Controls.Add(lblDetail, 0, 2);
            tblLayout.Controls.Add(dgvPracticePointDetail, 0, 3);

            this.tabPracticePoint.Controls.Add(tblLayout);
        }

        private void InitializeRollCallTab()
        {
            this.tabRollCall.Text = "Điểm danh";

            var tblLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10),
            };

            var lblSummary = new Label
            {
                Text = "Tổng hợp điểm danh",
                Location = new Point(10, 250),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            this.dgvRollCallSummary.Location = new Point(10, 280);
            this.dgvRollCallSummary.Size = new Size(1150, 200);
            this.dgvRollCallSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRollCallSummary.ReadOnly = true;
            this.dgvRollCallSummary.Dock = DockStyle.Fill;

            var lblDetail = new Label
            {
                Text = "Chi tiết điểm danh",
                Location = new Point(10, 10),
                AutoSize = true,
                Dock = DockStyle.Fill,
            };

            this.dgvRollCallDetail.Location = new Point(10, 40);
            this.dgvRollCallDetail.Size = new Size(1150, 200);
            this.dgvRollCallDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRollCallDetail.ReadOnly = true;
            this.dgvRollCallDetail.Dock = DockStyle.Fill;

            tblLayout.Controls.Add(lblSummary, 0, 0);
            tblLayout.Controls.Add(dgvRollCallSummary, 0, 1);
            tblLayout.Controls.Add(lblDetail, 0, 2);
            tblLayout.Controls.Add(dgvRollCallDetail, 0, 3);

            this.tabRollCall.Controls.Add(tblLayout);
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

        private async void ExportMultipleWithProgress(Dictionary<string, DataGridView> dataGridViews)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file báo cáo Excel";
                saveFileDialog.FileName = "SM_Report.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ProgressBar
                    ProgressForm progressForm = new ProgressForm();
                    progressForm.Show();

                    try
                    {
                        await Task.Run(() =>
                        {
                            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");

                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                int totalSheets = dataGridViews.Count;
                                int currentSheet = 0;

                                foreach (var item in dataGridViews)
                                {
                                    currentSheet++;
                                    string sheetName = item.Key;
                                    DataGridView dgv = item.Value;

                                    // Cập nhật tiến trình
                                    progressForm.UpdateProgress($"Đang xuất sheet: {sheetName}",
                                                               (currentSheet * 100) / totalSheets);

                                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                                    // Xuất dữ liệu (giống code trên)
                                    ExportDataGridViewToWorksheet(dgv, worksheet);
                                }

                                // Lưu file
                                FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                                excelPackage.SaveAs(excelFile);
                            }
                        });

                        progressForm.Close();
                        MessageBox.Show("Xuất Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        progressForm.Close();
                        MessageBox.Show($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        // Hàm phụ trợ xuất DataGridView vào Worksheet
        private void ExportDataGridViewToWorksheet(DataGridView dgv, ExcelWorksheet worksheet)
        {
            // Xuất tiêu đề
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            }

            // Xuất dữ liệu
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }
    }
}
