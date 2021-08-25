using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using System;
using RestWithAsp.Repository;

namespace RestWithAsp.Negocios.Implementations
{
    public class BookNegociosImplementation : IBookNegocios
    {
   
        private IRepository<Book> _repository;
        
        public BookNegociosImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }
        // Método responsável por devolver todas as pessoas
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por devolver uma pessoa por ID
        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        //Método responsável por Creta uma nova pessoa
        public Book Create(Book book)
        {

            return _repository.Create(book);  
        }
        // método responsável pela atualização de uma pessoa
        public Book Update(Book book)
        {
          return  _repository.Update(book);
        }

        // Método responsável por excluir uma pessoa de um id
        public void Delete(long id)
        {
            _repository.Delete(id);

        }
    
    }
}
