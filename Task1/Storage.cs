using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1
{
    /// <summary>
    /// 1.2.3 Статичные списки
    /// </summary>
    public static class Storage
    {
        public static List<HumanDto> Humans { get; }
        public static List<BookDto> Books { get; }
        
        static Storage()
        {
            string[]humanData =
            {
                "Wszechobecny Jodladymuzywac Szymankowszczyznowicz 1974-12-14",
                "Кеверборлитова Анна Анатольевна 2001-04-12",
                "Шпак Василий Боргенов 1988-11-17",
                "Шпатель Кирилл Димитриевич 1984-04-18"
            };

            var humans = humanData.Select(s => s.Split(' ')).Select
            (
                data => new HumanDto
                {
                    Name = data[1],
                    Surname = data[0],
                    Patronymic = data[2],
                    Birthday = DateTime.Parse(data[3])
                }
            );
            
            Humans = new List<HumanDto>(UInt16.MaxValue);
            Humans.InsertRange(0, humans);


            string[] bookData =
            {
                "Почему вам никогда не стоит начинать изучать JavaScript;1;Программирование",
                "JavaScript на луне, сфера использования интерпретируемых языков за пределами земной атмосферы;1;Программирование",
                "Чем отличается банановая республика и клан в Minecraft, наглядно;0;Политика",
                "Как отучить человека от игры в Genshin Impact, наглядное пособие с примерами;2;Философия"
            };

            var books = bookData.Select(s => s.Split(';')).Select
            (
                data => new BookDto
                {
                    Title = data[0],
                    AuthorId = Convert.ToInt32(data[1]),
                    Genre = data[2]
                }
            );

            Books = new List<BookDto>(UInt16.MaxValue);
            Books.InsertRange(0, books);
        }


        /// <summary>
        /// 2.1.3 Список библиотечных карточек
        /// </summary>
        public readonly static List<LibraryCard> Libraries = new List<LibraryCard>(UInt16.MaxValue);
    }
}
