﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repitition_Task.DataAccess.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
