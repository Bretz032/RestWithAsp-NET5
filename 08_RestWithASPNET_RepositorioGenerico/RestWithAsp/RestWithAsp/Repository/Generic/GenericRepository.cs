using Microsoft.EntityFrameworkCore;
using RestWithAsp.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAsp.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private PostgreSQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(PostgreSQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        // Método responsável por devolver todas as pessoas
        public List<T> FindAll()
        {
            return dataset.ToList();
        }


        // Método responsável por devolver uma pessoa por ID
        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        //Método responsável por Creta uma nova pessoa
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }

        }
        // método responsável pela atualização de uma pessoa
        public T Update(T item)
        {
            // Obtenha o status atual do registro no banco de dados
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    // set changes and save
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }

        }

        // Método responsável por excluir uma pessoa de um id
        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
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


