using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        protected static Func<BookDto, Object> SortSelect(string sort)
        {
            switch(sort)
            {
                case "AuthorId": return B => B.AuthorId;
                case "AuthorFio": return B => B.AuthorInfo;
                case "BookTitle": return B => B.Title;
                case "BookGenre": return B => B.Genre;
                default: return B => B.Id;
            }
        }
        protected static Func<BookDto, bool> Find(string query) =>
            b => (b.Title + b.Author.ToString() + b.Genre).ToLower().Contains(query);

        /// <summary>
        /// 1.4.1.2 Список всех книг по автору
        /// </summary>
        /// <param name="AuthorId">Автор</param>
        /// <returns>Список книг автора</returns>
        [HttpGet("FiltByAuthor")]
        public IEnumerable<BookDto> GetAll(int AuthorId) => Storage.Books.Where(B => B.AuthorId == AuthorId);

        /// <summary>
        /// 1.4.1.1 Список всех книг
        /// 2.2.2 Запрос на сортировку
        /// </summary>
        /// <param name="query">Поисковая фраза</param>
        /// <param name="sort">Тип сортировки</param>
        /// <returns>Список книг</returns>
        [HttpGet]
        public IEnumerable<BookDto> Search
        (
            [FromHeader(Name = "Sort")] 
            string sort = "", 
            
            string query = ""
        ) 
        => Storage.Books.Where(Find(query.ToLower())).OrderBy(SortSelect(sort));

        /// <summary>
        /// 1.4.2 Добавление книги
        /// </summary>
        /// <param name="B">Новая книга</param>
        [HttpPost]
        public void Add(BookDto B) => Storage.Books.Add(B);

        /// <summary>
        /// 1.4.3 Удаление книги
        /// </summary>
        /// <param name="index">Индекс книги</param>
        [HttpDelete("delete/{index}")]
        public void Delete(int index) => Storage.Books.RemoveAt(index);
    }
}
