using RestWithAsp.Model;
using System.Collections.Generic;

namespace RestWithAsp.Negocios
{
    public interface IBookNegocios
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
