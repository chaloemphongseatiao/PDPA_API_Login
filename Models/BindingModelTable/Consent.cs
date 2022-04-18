using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;

namespace DotnetAPI5.Models
{
    [Table("Consent")]
    public class Consent
    {
        [Key]
        public int DPId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Period { get; set; }
        public string Favorites { get; set; }
        public string DesiredBranch { get; set; }
        public string IPAddress { get; set; }
        public string CardNumber { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string PostComment { get; set; }
        public string CarRegistration { get; set; }
        public string ChassisNumber { get; set; }
        public string ServiceBranch { get; set; }
        public string ContactAgency { get; set; }
        [NotMapped]
        public string Fullname
        {
            get
            {
                return String.Concat(this.FirstName, " ", this.LastName);
            }
        }

        public string CreateDateThaiFormat
        {
            get
            {
                System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
                DateTime dateThai = Convert.ToDateTime(this.CreateDateTime, _cultureTHInfo);
                return  dateThai.ToString("dd/MM/yyyy HH:mm", _cultureTHInfo);
            }
        }




    }
}

