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

using System.Windows;
using System.Windows.Input;
using CoderCamp18.Commands;
using CoderCamp18.View;

namespace CoderCamp18.ViewModel
{
    public class NewTaskViewModel : BaseViewModel, INewTaskViewModel
    {
        private string _name;
        private ICommand _addTaskCommand;
        private readonly INewTaskDialog _view;

        public NewTaskViewModel()
        {
            AddTaskCommand = new RelayCommand(p => AddTask(), p => CanAddTask());
            _view = new NewTaskWindow(this);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTaskCommand
        {
            get { return _addTaskCommand; }
            set
            {
                if (Equals(value, _addTaskCommand)) return;
                _addTaskCommand = value;
                OnPropertyChanged();
            }
        }

        public Window Owner
        {
            set { _view.Owner = value; }
        }

        public bool? ShowDialog()
        {
            return _view.ShowDialog();
        }

        private void AddTask()
        {
            _view.DialogResult = true;
            _view.Close();
        }

        public bool CanAddTask()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}