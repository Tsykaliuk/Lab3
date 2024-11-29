using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3;

public class Lesson
{
    public bool IsSelected { get; set; }  
    public string Discipline { get; set; }
    public string Teacher { get; set; }
    public int Audience { get; set; }
    public string Faculty { get; set; }
    public string Time { get; set; }
    public string Day { get; set; }
    public Lesson(string time, string day ,string discipline, string teacher, int audience, string faculty)
    {
        Time = time;
        Day = day;
        Discipline = discipline;
        Audience = audience;
        Faculty = faculty;
        Teacher =  teacher;
    }
}