using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Laba3;

public partial class EditView : ContentPage
{
    public string Day { get; set; }
    public int Audience { get; set; }
    public string Time { get; set; }
    public string Discipline { get; set; }
    public string Teacher { get; set; }
    public string Faculty { get; set; }

    public EditView()
    {
        InitializeComponent();

        Schelude file = Schelude.GetInstance();

        file.FindIndex();

        if (file.Data.Count > 0 && file.index < file.Data.Count)
        {
            this.Day = file.Data[file.index].Day;

            this.Audience = file.Data[file.index].Audience;

            this.Faculty = file.Data[file.index].Faculty;

            this.Discipline = file.Data[file.index].Discipline;

            this.Time = file.Data[file.index].Time;

            this.Teacher = file.Data[file.index].Teacher;
        }
        BindingContext = this;
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Application.Current.CloseWindow(this.Window);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        Schelude file = Schelude.GetInstance();
        file.EditLesson(Time, Day, Discipline, Teacher, Audience, Faculty);
        Application.Current.CloseWindow(this.Window);
    }

}