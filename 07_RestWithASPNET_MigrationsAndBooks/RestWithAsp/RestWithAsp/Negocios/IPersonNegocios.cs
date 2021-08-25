using RestWithAsp.Model;
using System.Collections.Generic;

namespace RestWithAsp.Negocios
{
    public interface IPersonNegocios
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
