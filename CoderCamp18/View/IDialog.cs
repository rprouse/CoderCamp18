using System.Windows;

namespace CoderCamp18.View
{
    public interface IDialog
    {
        Window Owner { set; }
        bool? ShowDialog();
        bool? DialogResult { get; set; }
        void Close();
    }
}