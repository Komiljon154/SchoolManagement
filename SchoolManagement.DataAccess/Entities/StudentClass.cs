using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Entities;

public class StudentClass
{
    public int? StudentID { get; set; }
    public Student Student { get; set; }

    public int? ClassID { get; set; }
    public Class Class { get; set; }
}

