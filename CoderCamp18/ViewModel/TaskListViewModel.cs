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
using System.Linq;
using System.Windows.Input;
using CoderCamp18.Annotations;
using CoderCamp18.Commands;
using CoderCamp18.Model;

namespace CoderCamp18.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private BindingList<Task> _tasks;
        private ICommand _completeTaskCommand;
        private ICommand _addTaskCommand;
        private Task _selectedTask;

        public TaskListViewModel()
        {
            Tasks = new BindingList<Task>();
            AddTaskCommand = new RelayCommand( p => AddTask(), p => true );
            CompleteTaskCommand = new RelayCommand(p => CompleteTask(), p => SelectedTask != null && !SelectedTask.Completed );

            using ( var db = new TaskContext( ) )
            {
                var query = from t in db.Tasks select t;
                foreach ( var task in query )
                {
                    Tasks.Add( task );
                }
            }
        }

        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand; }
            set
            {
                if ( Equals( value, _addTaskCommand ) ) return;
                _addTaskCommand = value;
                OnPropertyChanged( "AddTaskCommand" );
            }
        }

        public ICommand CompleteTaskCommand
        {
            get { return _completeTaskCommand; }
            set
            {
                if ( Equals( value, _completeTaskCommand ) ) return;
                _completeTaskCommand = value;
                OnPropertyChanged( "CompleteTaskCommand" );
            }
        }

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if ( Equals( value, _selectedTask ) ) return;
                _selectedTask = value;
                OnPropertyChanged( "SelectedTask" );
            }
        }

        public BindingList<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                if ( Equals( value, _tasks ) ) return;
                _tasks = value;
                OnPropertyChanged( "Tasks" );
            }
        }

        private void AddTask()
        {
            // TODO
        }

        private void CompleteTask()
        {
            // TODO
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if ( handler != null ) handler( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}