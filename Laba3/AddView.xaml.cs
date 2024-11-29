using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace Laba3;

public partial class AddView : ContentPage
{
    public string Day { get; set; }
    public string Time { get; set; }
    public string Discipline { get; set; }
    public string AuthorText { get; set; }
    public string Teacher { get; set; }
    public string Faculty { get; set; }
    public int Audience { get; set; }

    public ObservableCollection<Lesson> Lessons { get; set; }

    public event EventHandler LessonAdded;

    public AddView()
    {
        InitializeComponent();

        BindingContext = this;
        Lessons = new ObservableCollection<Lesson>();
    }


    private void SubmitClicked(object sender, EventArgs e)
    {
        
        Schelude file = Schelude.GetInstance();
        file.AddLesson(Time, Day, Discipline, Teacher, Audience, Faculty);
        file.index = file.Data.Count - 1;
        LessonAdded?.Invoke(this, EventArgs.Empty);
        Application.Current.CloseWindow(this.Window);
    }
}