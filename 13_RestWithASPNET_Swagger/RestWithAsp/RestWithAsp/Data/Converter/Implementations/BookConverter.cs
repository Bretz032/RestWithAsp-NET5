
using RestWithAsp.Data.Converter.Contract;
using RestWithAsp.Model;
using RestWithASP.Data.VO;
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
                Id = origin.Id,
                author = origin.Author,
                launch_date = origin.LaunchDate,
                price = (double)origin.Price,
                title = origin.Title
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.author,
                LaunchDate = origin.launch_date,
                Price = (decimal)(double)origin.price,
                Title = origin.title
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
