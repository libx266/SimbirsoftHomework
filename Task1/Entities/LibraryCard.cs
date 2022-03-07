using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Entities
{
    /// <summary>
    /// 2.1.1 Карточка библиотеки
    /// </summary>
    public class LibraryCard
    {
        public HumanDto Reader { get; protected set; }
        public int ReaderId {
            set => Reader = Storage.Humans[value];
        }
        
        public BookDto Book { get; protected set; }
        public int BookId {
            set => Book = Storage.Books[value];
        }

        public DateTime StartTime { protected get; set; }

        /// <summary>
        /// 2.1.5
        /// </summary>
        public string DateTimeOffset => $"{StartTime:O}";
    }
}
