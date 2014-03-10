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

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoderCamp18.Model
{
    public class DataStore
    {
        private static IDictionary<int, Task> _tasks;

        // Pretend we are a real database with real data
        static DataStore()
        {
            _tasks = new Dictionary<int, Task>();

            var data = new DataStore();
            data.Add("Come up with idea for CoderCamp", true);
            data.Add("Find a better idea");
            data.Add("Write a demo app");
            data.Add("Prepare presentation");
            data.Add("Get nervous...");
            data.Add("Drink beer");
        }

        /// <summary>
        /// Adds a task with the given name
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="completed">If true, the task has been completed. Defaults to false.</param>
        /// <returns>The newly added task</returns>
        public Task Add( string name, bool completed = false )
        {
            var task = new Task( name, completed );
            _tasks.Add( task.Id, task );
            return task;
        }

        /// <summary>
        /// Fetches the task with the given database id
        /// </summary>
        /// <param name="id">The id of the task.</param>
        /// <returns></returns>
        public Task Fetch( int id )
        {
            return _tasks.ContainsKey( id ) ? _tasks[id] : null;
        }

        /// <summary>
        /// Fetches all tasks from our imaginary database
        /// </summary>
        /// <returns>A list of all tasks</returns>
        public ICollection<Task> FetchAll()
        {
            return _tasks.Values;
        }
    }
}