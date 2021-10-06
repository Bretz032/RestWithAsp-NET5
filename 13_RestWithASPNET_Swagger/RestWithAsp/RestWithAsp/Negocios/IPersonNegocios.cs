
using RestWithASP.Data.VO;
using System.Collections.Generic;

namespace RestWithAsp.Negocios
{
    public interface IPersonNegocios
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
