using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using System;

namespace RestWithAsp.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
   
        private PostgreSQLContext  _context;
        
        public PersonServiceImplementation(PostgreSQLContext context)
        {
            _context = context;
        }
        // Método responsável por devolver todas as pessoas
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Método responsável por devolver uma pessoa por ID
        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        //Método responsável por Creta uma nova pessoa
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        // método responsável pela atualização de uma pessoa
        public Person Update(Person person)
        {
            // Verificamos se a pessoa existe no banco de dados
            // Se não existe, retornamos uma instância de pessoa vazia
            if (!Exists(person.Id))
            {
                
                return new Person(); 
            
            }

            // Obtenha o status atual do registro no banco de dados
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    // set changes and save
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
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
        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
