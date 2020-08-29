using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhones.Models
{
    public class MobilePhone
    {
        [Key]
        public int MobilePhoneId { get; set; }

        [DisplayName("მოდელი")]
        public string Name { get; set; }

        [DisplayName("მწარმოებელი")]
        public string Manufacturer { get; set; }


        [DisplayName("ფასი")]
        public double Price { get; set; }

        [DisplayName("წონა")]
        public int Weight { get; set; }

        [DisplayName("სიგრძე")]
        public int Height { get; set; }

        [DisplayName("სიგანე")]
        public int Width { get; set; }

        [DisplayName("შიდა მეხსიერება")]
        public int HardDrive { get; set; }

        [DisplayName("ოპერატიული მეხსიერება")]
        public int Ram { get; set; }

        [DisplayName("ოპერაციული სისტემა")]
        public string OperatingSystem { get; set; }

        [DisplayName("პროცესორი")]
        public string Processor { get; set; }

        public string PhotoUrl { get; set; }

        public MobilePhone()
        {
            PhotoUrl = "~/Appfiles/defaultmobilephoto.jpg";
        }




    }
}
