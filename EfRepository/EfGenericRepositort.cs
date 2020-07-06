using Microsoft.EntityFrameworkCore;
using poco;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EfRepository
{
    public class EfGenericRepositort<T> : IDataRepository<T> where T : BookPoco
    {
        private readonly wookiesContext _context;

        public EfGenericRepositort()
        {
            _context = new wookiesContext();
        }
        public void Add(BookPoco poco)
        {

            _context.Entry(poco).State =
                EntityState.Added;

            _context.SaveChanges();
        }

        public BookPoco Get(Guid id)
        {
            return _context.bookPocos.Find(id);
        }

        public BookPoco GetList(string detail)
        {
            return _context.bookPocos.Find(detail);
        }



        public void Remove(Guid id)
        {
            BookPoco book = _context.bookPocos.Find(id);
            if (book != null)
            {
                _context.bookPocos.Remove(book);
            }
            else
            {
                throw new ArgumentOutOfRangeException("your book did not find");
            }
        }



        public void Update(BookPoco poco)
        {
            _context.Entry(poco).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

