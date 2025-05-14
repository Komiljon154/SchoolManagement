using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Entities;

public class TeacherClass
{
    public int TeacherID { get; set; }
    public Teacher Teacher { get; set; }

    public int ClassID { get; set; }
    public Class Class { get; set; }
}
