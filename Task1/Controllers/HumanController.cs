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
    public class HumanController : ControllerBase
    {
        /// <summary>
        /// 1.3.1.1 Список всех людей
        /// </summary>
        /// <returns>Список людей, упорядоченных по Id</returns>
        [HttpGet("/byId")]
        public IEnumerable<HumanDto> GetAll() => Storage.Humans;

        /// <summary>
        /// 1.3.1.3 Список людей с поиском
        /// </summary>
        /// <param name="query">Поисковая фраза</param>
        /// <returns>Список людей, отвечающих поисковому запросу и упорядоченный по ФИО</returns>
        [HttpGet("/byFio")]
        public IEnumerable<HumanDto> Search(string query = "") => Storage.Humans.Where(h => h.ToString().Contains(query)).OrderBy(H => H.ToString());

        /// <summary>
        /// 1.3.1.2 Список людей, которые пишут книги
        /// </summary>
        /// <returns>Список авторов</returns>
        [HttpGet("/authors")]
        public IEnumerable<HumanDto> GetAuthors() => Storage.Humans.Where(H => H.Books.Count > 0);

        /// <summary>
        /// 1.3.2 Добавление нового человека
        /// </summary>
        /// <param name="H">Человек</param>
        [HttpPost]
        public void Add(HumanDto H) => Storage.Humans.Add(H);

        [HttpDelete("delete/{id}")]
        public void Delete(int id) => Storage.Humans.RemoveAt(id);
    }
}
