﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InExRecordApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "varchar(11)")]
        [Required]
        public string ContactNo { get; set; }

        [Column(TypeName = "text")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Designation { get; set; }
    }
}