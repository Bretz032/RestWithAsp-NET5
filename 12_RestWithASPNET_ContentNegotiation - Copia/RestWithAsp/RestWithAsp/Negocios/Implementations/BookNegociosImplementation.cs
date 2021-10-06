using RestWithAsp.Data.Converter;
using RestWithAsp.Data;
using RestWithAsp.Model;
using RestWithAsp.Repository;
 
using System.Collections.Generic;
using RestWithAsp.Data.Converter.Implementations;
using RestWithASP.Data.VO;

namespace RestWithAsp.Negocios.Implementations
{
    public class BookNegociosImplementation : IBookNegocios
    {

        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookNegociosImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        // Method responsible for returning all people,
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Method responsible for returning one person by ID
        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new person
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        // Method responsible for updating one person
        public BookVO Update(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

     
    }
}

