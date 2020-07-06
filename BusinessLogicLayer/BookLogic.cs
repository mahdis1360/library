using poco;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class BookLogic


    {
        protected IDataRepository<BookPoco> _repository;
        public BookLogic(IDataRepository<BookPoco> repository)
        {
            _repository = repository;
        }


        protected void Verify(BookPoco poco)
        {
            List<ValidationException> exceptions = new List<ValidationException>();


            if (string.IsNullOrEmpty(poco.Description))
            {
                exceptions.Add(new ValidationException("Description is Null"));

            }
            if (string.IsNullOrEmpty(poco.Title))
            {
                exceptions.Add(new ValidationException(" your Book needs Title"));
            }

            if (poco.Price <= 0)
            {
                exceptions.Add(new ValidationException(" the price could not be zero or negative"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }


        }

        public void Add(BookPoco poco)
        {
            _repository.Add(poco);
        }

        public void Update(BookPoco poco)
        {
            _repository.Update(poco);
        }

        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }


        public BookPoco Search(string detail)
        {
            return _repository.GetList(detail);
        }

        public BookPoco Get(Guid id)
        {
            return _repository.Get(id);
        }


    }
}
