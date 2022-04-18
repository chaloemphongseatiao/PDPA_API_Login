using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotnetAPI5.Models
{
    [Table("Account")]
    public class Account
    {

        [Key]
        public int AccID { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? CreateDateTime { get; set; }

        

    }
}
