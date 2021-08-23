using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using System;
using RestWithAsp.Repository;

namespace RestWithAsp.Negocios.Implementations
{
    public class PersonNegociosImplementation : IPersonNegocios
    {
   
        private IPersonRepository _repository;
        
        public PersonNegociosImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }
        // Método responsável por devolver todas as pessoas
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por devolver uma pessoa por ID
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        //Método responsável por Creta uma nova pessoa
        public Person Create(Person person)
        {

            return _repository.Create(person);  
        }
        // método responsável pela atualização de uma pessoa
        public Person Update(Person person)
        {
          return  _repository.Update(person);
        }

        // Método responsável por excluir uma pessoa de um id
        public void Delete(long id)
        {
            _repository.Delete(id);

        }
    
    }
}
