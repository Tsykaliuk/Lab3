namespace Laba3;

public partial class AddComment : ContentPage
{
    public event EventHandler<string> InputValuesSubmitted;
    public AddComment()
    {
        InitializeComponent();
    }

    public EditView EditView
    {
        get => default;
        set
        {
        }
    }

    public AddView AddView
    {
        get => default;
        set
        {
        }
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        InputValuesSubmitted?.Invoke(this, $"{author.Text},{content.Text}");
        Application.Current.CloseWindow(this.Window);
    }
}