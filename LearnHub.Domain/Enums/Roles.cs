using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Enums
{
    public enum Roles
    {
        [Description("Administrator")]
        Admin = 1,

        [Description("Teacher")]
        Teacher = 2,

        [Description("Student")]
        Student = 3,
    }
}
