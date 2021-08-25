using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using System;

namespace RestWithAsp.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
   
        private PostgreSQLContext  _context;
        
        public BookRepositoryImplementation(PostgreSQLContext context)
        {
            _context = context;
        }
        // Método responsável por devolver todas as pessoas
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        // Método responsável por devolver uma pessoa por ID
        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        //Método responsável por Creta uma nova pessoa
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }
        // método responsável pela atualização de uma pessoa
        public Book Update(Book book)
        {
            // Verificamos se a pessoa existe no banco de dados
            // Se não existe, retornamos uma instância de pessoa vazia
            if (!Exists(book.Id))
            {
                
                return new Book(); 
            
            }

            // Obtenha o status atual do registro no banco de dados
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    // set changes and save
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        // Método responsável por excluir uma pessoa de um id
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
