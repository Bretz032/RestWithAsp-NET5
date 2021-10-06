using RestWithASP.Data.VO;
using System.Collections.Generic;

namespace RestWithAsp.Negocios
{
    public interface IBookNegocios
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
