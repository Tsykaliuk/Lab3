using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Laba3;

internal class Schelude
{
    private static Schelude _instance;

    public string FilePath { get; set; }
    public string FileContent { get; set; }
    public event Action LessonUpdated;
    public ObservableCollection<Lesson> Data { get; set; }
    public ObservableCollection<Lesson> CurrentBuffer { get; set; }
    public int index { get; set; }

    public delegate ObservableCollection<Lesson> SearchDelegate(string value);

    Dictionary<string, SearchDelegate> SearchHelper;
    private Schelude()
    {
        this.index = 0;
        this.Data = new ObservableCollection<Lesson>();
        SearchHelper = new Dictionary<string, SearchDelegate>();
        SearchHelper.Add("Day", findByDay);
        SearchHelper.Add("Teacher", findByTeacher);
        SearchHelper.Add("Discipline", findByDiscipline);
    }

    public static Schelude GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Schelude();
        }
        return _instance;
    }
    public ObservableCollection<Lesson> Search(string searchCriterion, string searchText)
    {
        this.CurrentBuffer = this.Data;
        var resultLessons = SearchHelper[searchCriterion](searchText);
        this.Data = CurrentBuffer;
        return resultLessons;
    }

    public void UpdateDataToBuffer()
    {
        this.Data = this.CurrentBuffer;
    }

    public void AddLesson(string day, string time, string discipline, string teacher, int audience, string faculty)
    {

        this.Data.Add(new Lesson(time, day, discipline, teacher, audience, faculty));
    }


    public void EditLesson(string time, string day, string discipline, string teacher, int audience, string faculty)
    {

        this.Data[this.index] = new Lesson(time, day, discipline, teacher, audience, faculty);
        LessonUpdated?.Invoke();
    }


    public void DeleteArticle()
    {
        this.FindIndex();
        Debug.WriteLine(this.index);
        if (this.index >= 0 && this.index < this.Data.Count)
        {
            this.Data.Remove(this.Data[this.index]);
        }
    }

    public bool IsOpened()
    {
        return this.FilePath != null;
    }

    public void FindIndex()
    {
        for (int i = 0; i < this.Data.Count; i++)
        {
            if (this.Data[i].IsSelected)
            {
                this.index = i;
                break;
            }
        }
    }

    private ObservableCollection<Lesson> findByDay(string value)
    {
        var file = Schelude.GetInstance();
        var filteredData = new ObservableCollection<Lesson>(
                    (from lesson in file.Data
                     where String.IsNullOrEmpty(value)
                           ? lesson?.Day == null
                           : lesson?.Day?.Contains(value, StringComparison.OrdinalIgnoreCase) == true
                     select lesson).ToList());

        return filteredData;
    }

    private ObservableCollection<Lesson> findByTeacher(string value)
    {
        var file = Schelude.GetInstance();
        var filteredData = new ObservableCollection<Lesson>(
                    (from lesson in file.Data
                     where String.IsNullOrEmpty(value)
                           ? lesson?.Teacher == null
                           : lesson?.Teacher?.Contains(value, StringComparison.OrdinalIgnoreCase) == true
                     select lesson).ToList());

        return filteredData;
    }

    private ObservableCollection<Lesson> findByDiscipline(string value)
    {
        var file = Schelude.GetInstance();
        var filteredData = new ObservableCollection<Lesson>(
                    (from lesson in file.Data
                     where String.IsNullOrEmpty(value)
                           ? lesson?.Discipline == null
                           : lesson?.Discipline?.Contains(value, StringComparison.OrdinalIgnoreCase) == true
                     select lesson).ToList());

        return filteredData;
    }

}