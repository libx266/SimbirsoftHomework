using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Entities
{
    /// <summary>
    /// 1.1.2.1 Класс человека
    /// </summary>
    public class HumanDto
    {
        public int Id => Storage.Humans.IndexOf(this);
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<BookDto> Books { get; }
        public HumanDto() => Books = new HashSet<BookDto>();

        public override string ToString() =>
            $"{Surname} {Name} {Patronymic}";

        public static implicit operator bool (HumanDto human) => human != null;
    }
}
