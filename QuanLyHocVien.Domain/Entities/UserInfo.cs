﻿namespace QuanLyHocVien.Domain.Entities
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
