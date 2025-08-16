namespace StudentManagementSystem.UI
{
    public partial class SmoothPanel : Panel
    {
        public SmoothPanel()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
