﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllBuyMyself.Models.Common.Table
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Cellphone { get; set; } = null;

        public string? Email { get; set; } = null;

        public string? Address { get; set; } = null;
    }
}
