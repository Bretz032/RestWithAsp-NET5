using RestWithAsp.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithAsp.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
   
        private volatile int count;
 
        public Person Create(Person person)
        {
            return person;
        }
 
        public void Delete(long id)
        {
            // Our exclusion logic would come here
        }
 
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }
 
        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Fernando",
                LastName = "Bretz",
                Address = "Santa Luzia - Minas Gerais - Brasil",
                Gender = "Male"
            };
        }
 
        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Primeiro Nome" + i,
                LastName = "Sobrenome" + i,
                Address = "Endereco" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
