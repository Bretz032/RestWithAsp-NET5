using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model.Context;
using System.Linq;
using System;
using RestWithAsp.Repository;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithAsp.Negocios.Implementations
{
    public class PersonNegociosImplementation : IPersonNegocios
    {

        private IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonNegociosImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        // Método responsável por devolver todas as pessoas
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Método responsável por devolver uma pessoa por ID
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        //Método responsável por Creta uma nova pessoa
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }
        // método responsável pela atualização de uma pessoa
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        // Método responsável por excluir uma pessoa de um id
        public void Delete(long id)
        {
           _repository.Delete(id);

        }
    
    }
}
