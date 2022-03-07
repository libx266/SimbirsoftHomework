using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task1.Entities
{
    /// <summary>
    /// 1.1.2.2 Класс книги
    /// </summary>
    public class BookDto
    {
        public int Id => Storage.Books.IndexOf(this);
        public string Title { get; set; }

        [JsonIgnore]
        public HumanDto Author { get; protected set; }
        public string Genre { get; set; }

        public string AuthorInfo => Author ? Author.ToString() : "Nameless";

        public int? AuthorId
        {
            get => Author ? Author.Id : null;
            set
            {
                if (value != null)
                {
                    Author = Storage.Humans[(int)value];
                    Author.Books.Add(this);
                }
            }
        }

        public override string ToString() =>
            $"{Title}  by {AuthorInfo}";
    }
}
