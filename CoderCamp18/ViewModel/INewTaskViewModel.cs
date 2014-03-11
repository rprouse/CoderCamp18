using System.Windows;

namespace CoderCamp18.ViewModel
{
    public interface INewTaskViewModel
    {
        Window Owner { set; }
        bool? ShowDialog();
        string Name { get; set; }
    }
}