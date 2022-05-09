﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name: "Activity State")]
    public class ActivityState
    {
        [Key]
        public int ActivityState_Id { get; set; }
        [Required, MaxLength(50)]
        public string State { get; set; }
    }
}
