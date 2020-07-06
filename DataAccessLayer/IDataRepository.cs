using poco;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public interface IDataRepository<T>
    {

        BookPoco Get(Guid id);
        BookPoco GetList(string detail);
        void Add(BookPoco poco);
        void Update(BookPoco poco);
        void Remove(Guid id);
        protected virtual void Verify(BookPoco poco)
        {
            return;
        }


    }
}
