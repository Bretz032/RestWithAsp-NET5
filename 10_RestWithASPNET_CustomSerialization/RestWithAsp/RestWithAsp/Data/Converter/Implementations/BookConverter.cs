
using RestWithAsp.Data.Converter.Contract;
using RestWithAsp.Model;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAsp.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.id,
                author = origin.author,
                launch_date = origin.launchDate,
                price = (double)origin.price,
                title = origin.title
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                id = origin.Id,
                author = origin.author,
                launchDate = origin.launch_date,
                price = (decimal)origin.price,
                title = origin.title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
