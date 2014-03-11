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
using System.Collections.Generic; 
using System.Collections.ObjectModel; 
using System.Data.Entity; 
using System.Data.Entity.Infrastructure; 
using System.Linq; 
using System.Linq.Expressions; 
using System.Threading; 
using System.Threading.Tasks; 
using CoderCamp18.Model;
using Task = System.Threading.Tasks.Task;

namespace CoderCamp18.Test.Mocks
{
    public class TestTaskContext : ITaskContext
    {
        // Pretend we are a real database with real data
        public TestTaskContext()
        {
            Tasks = new TestDbSet<Model.Task>();
        }

        public void Dispose()
        {
        }

        public DbSet<Model.Task> Tasks { get; set; }

        public IEnumerable<Model.Task> GetAllTasks()
        {
            return Tasks;
        }

        public int SaveChanges()
        {
            return 1;
        }
    }

        public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity> 
        where TEntity : class 
    { 
        ObservableCollection<TEntity> _data; 
        IQueryable _query; 
 
        public TestDbSet() 
        { 
            _data = new ObservableCollection<TEntity>(); 
            _query = _data.AsQueryable(); 
        } 
 
        public override TEntity Add(TEntity item) 
        { 
            _data.Add(item); 
            return item; 
        } 
 
        public override TEntity Remove(TEntity item) 
        { 
            _data.Remove(item); 
            return item; 
        } 
 
        public override TEntity Attach(TEntity item) 
        { 
            _data.Add(item); 
            return item; 
        } 
 
        public override TEntity Create() 
        { 
            return Activator.CreateInstance<TEntity>(); 
        } 
 
        public override TDerivedEntity Create<TDerivedEntity>() 
        { 
            return Activator.CreateInstance<TDerivedEntity>(); 
        } 
 
        public override ObservableCollection<TEntity> Local 
        { 
            get { return _data; } 
        } 
 
        Type IQueryable.ElementType 
        { 
            get { return _query.ElementType; } 
        } 
 
        Expression IQueryable.Expression 
        { 
            get { return _query.Expression; } 
        } 
 
        IQueryProvider IQueryable.Provider 
        { 
            get { return new TestDbAsyncQueryProvider<TEntity>(_query.Provider); } 
        } 
 
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        { 
            return _data.GetEnumerator(); 
        } 
 
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() 
        { 
            return _data.GetEnumerator(); 
        } 
 
        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator() 
        { 
            return new TestDbAsyncEnumerator<TEntity>(_data.GetEnumerator()); 
        } 
    } 
 
    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider 
    { 
        private readonly IQueryProvider _inner; 
 
        internal TestDbAsyncQueryProvider(IQueryProvider inner) 
        { 
            _inner = inner; 
        } 
 
        public IQueryable CreateQuery(Expression expression) 
        { 
            return new TestDbAsyncEnumerable<TEntity>(expression); 
        } 
 
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) 
        { 
            return new TestDbAsyncEnumerable<TElement>(expression); 
        } 
 
        public object Execute(Expression expression) 
        { 
            return _inner.Execute(expression); 
        } 
 
        public TResult Execute<TResult>(Expression expression) 
        { 
            return _inner.Execute<TResult>(expression); 
        } 
 
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) 
        { 
            return Task.FromResult(Execute(expression)); 
        } 
 
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) 
        { 
            return Task.FromResult(Execute<TResult>(expression)); 
        } 
    } 
 
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T> 
    { 
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable) 
            : base(enumerable) 
        { } 
 
        public TestDbAsyncEnumerable(Expression expression) 
            : base(expression) 
        { } 
 
        public IDbAsyncEnumerator<T> GetAsyncEnumerator() 
        { 
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator()); 
        } 
 
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() 
        { 
            return GetAsyncEnumerator(); 
        } 
 
        public IQueryProvider Provider 
        { 
            get { return new TestDbAsyncQueryProvider<T>(this); } 
        } 
    } 
 
    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T> 
    { 
        private readonly IEnumerator<T> _inner; 
 
        public TestDbAsyncEnumerator(IEnumerator<T> inner) 
        { 
            _inner = inner; 
        } 
 
        public void Dispose() 
        { 
            _inner.Dispose(); 
        } 
 
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken) 
        { 
            return Task.FromResult(_inner.MoveNext()); 
        } 
 
        public T Current 
        { 
            get { return _inner.Current; } 
        } 
 
        object IDbAsyncEnumerator.Current 
        { 
            get { return Current; } 
        } 
    } 
}