using System.Windows;
using CoderCamp18.ViewModel;

namespace CoderCamp18.View
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : ITaskListWindow
    {
        public TaskListWindow()
        {
            InitializeComponent();
            DataContext = new TaskListViewModel(this);
        }

        public Window Window { get { return this; } }
    }
}
