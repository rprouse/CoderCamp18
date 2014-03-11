// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************

using System.ComponentModel;
using System.Windows.Input;
using CoderCamp18.Commands;
using CoderCamp18.Model;
using CoderCamp18.View;

namespace CoderCamp18.ViewModel
{
    public class TaskListViewModel : BaseViewModel
    {
        private readonly ITaskListWindow _view;
        private BindingList<Task> _tasks;
        private ICommand _completeTaskCommand;
        private ICommand _addTaskCommand;
        private Task _selectedTask;
        private ITaskContext _db;

        public TaskListViewModel(ITaskListWindow view)
        {
            _view = view;
            _view.Closed += (s, e) =>
            {
                if (_db != null)
                    _db.Dispose();
                _db = null;
            };

            Tasks = new BindingList<Task>();
            AddTaskCommand = new RelayCommand( p => AddTask(), p => true );
            CompleteTaskCommand = new RelayCommand(p => CompleteTask(), p => SelectedTask != null && !SelectedTask.Completed );

            _db = new TaskContext();
            foreach ( var task in _db.GetAllTasks() )
                Tasks.Add( task );
        }

        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand; }
            set
            {
                if ( Equals( value, _addTaskCommand ) ) return;
                _addTaskCommand = value;
                OnPropertyChanged();
            }
        }

        public ICommand CompleteTaskCommand
        {
            get { return _completeTaskCommand; }
            set
            {
                if ( Equals( value, _completeTaskCommand ) ) return;
                _completeTaskCommand = value;
                OnPropertyChanged();
            }
        }

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if ( Equals( value, _selectedTask ) ) return;
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        public BindingList<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                if ( Equals( value, _tasks ) ) return;
                _tasks = value;
                OnPropertyChanged();
            }
        }

        private void AddTask()
        {
            INewTaskViewModel viewModel = new NewTaskViewModel();
            viewModel.Owner = _view.Window;
            var result = viewModel.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var newTask = new Task {Name = viewModel.Name};
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
                _tasks.Add(newTask);
            }
        }

        private void CompleteTask()
        {
            SelectedTask.Completed = true;
            _db.SaveChanges();
        }
    }
}