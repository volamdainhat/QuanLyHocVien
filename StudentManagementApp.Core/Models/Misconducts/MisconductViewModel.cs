﻿using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Misconducts
{
    public class MisconductViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Vi phạm")]
        public string? Type { get; set; }
        [DisplayName("Thời điểm")]
        public DateTime Time { get; set; }
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
    }
}
