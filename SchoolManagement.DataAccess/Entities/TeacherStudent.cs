using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Entities;

public class TeacherStudent
{
    public int? TeacherID { get; set; }
    public Teacher Teacher { get; set; }

    public int? StudentID { get; set; }
    public Student Student { get; set; }
}
