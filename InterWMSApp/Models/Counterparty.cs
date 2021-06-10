﻿using InterWMSApp.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InterWMSApp.Models
{
    [Table("counterpartyes", Schema = "public")]
    public class Counterparty : BaseModel
    {
        [Column("userid"), Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("account"), Required]
        public int Account { get; set; }

        [Column("inn"), Required]
        public int INN { get; set; }

        [JsonIgnore]
        public List<Contract> Contracts { get; set; }
    }
}