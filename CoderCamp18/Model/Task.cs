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

using System;

namespace CoderCamp18.Model
{
    public class Task : IEquatable<Task>
    {
        // Simulates an autoincrement column in the db
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public bool Complete { get; set; }

        /// <summary>
        /// Constructs a new empty task
        /// </summary>
        public Task()
        {
            Id = _nextId++;
        }

        /// <summary>
        /// Constructs a new task with a new id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="completed"></param>
        public Task(string name, bool completed = false)
            : this()
        {
            Name = name;
            Complete = completed;
        }

        /// <summary>
        /// Constructs a task from the back-end database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="completed"></param>
        public Task( int id, string name, bool completed = false )
        {
            Id = id;
            Name = name;
            Complete = completed;
        }

        #region Overrides of Object

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals( Task other )
        {
            if ( ( object )other == null )
                return false;

            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals( object obj )
        {
            return Equals( obj as Task );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}