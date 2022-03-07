using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1.Controllers
{
    /// <summary>
    /// 2.1.2 Контроллер библиотечных карточек
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LibraryCard> GetAll() => Storage.Libraries;

        /// <summary>
        /// 2.1.4 Взятие карточки читателем
        /// </summary>
        /// <param name="LC">Выше описанный объект</param>
        [HttpPost]
        public void Add(LibraryCard LC) => Storage.Libraries.Add(LC);
    }
}
