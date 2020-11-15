using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinhexWebServer.Models;

namespace WinhexWebServer.Interfaces
{
    /// <summary>
    /// Контроллер, получающий логи
    /// </summary>
    interface IFileLogGetter
    {
        IActionResult Post(UserLog file);
    }
}
