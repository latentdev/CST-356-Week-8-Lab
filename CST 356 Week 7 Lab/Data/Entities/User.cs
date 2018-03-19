using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST_356_Week_7_Lab.Data.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int YearsInSchool { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}