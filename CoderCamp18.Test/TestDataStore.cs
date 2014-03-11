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

#region Using Directives

using System.Linq;
using CoderCamp18.Model;
using CoderCamp18.Test.Mocks;
using NUnit.Framework;

#endregion

namespace CoderCamp18.Test
{
    [TestFixture]
    public class TestDataStore
    {
        private TestTaskContext _data;

        [SetUp]
        public void SetUp()
        {
            _data = new TestTaskContext();
        }

        [TearDown]
        public void TearDown()
        {
            _data = null;
        }

        [Test]
        public void CanAddTask()
        {
            var task = new Task { Name = "New task" };
            Assert.That( task, Is.Not.Null );
            _data.Tasks.Add(task);
            _data.SaveChanges();
            var query = from t in _data.Tasks
                        where t.Name == "New task"
                        select t;
            Task fetched = query.First();
            Assert.That( fetched, Is.Not.Null );
            Assert.That( fetched, Is.EqualTo( task ) );
        }
    }
}