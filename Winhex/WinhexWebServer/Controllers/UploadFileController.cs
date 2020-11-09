using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinhexWebServer.Interfaces;
using WinhexWebServer.Models;

namespace WinhexWebServer.Controllers
{
    [Route("upload")]
    [ApiController]
    public class UploadFileController : ControllerBase, IFileLogGetter
    {
        private readonly ILogManager _logManager;
        public UploadFileController(ILogManager logManager)
        {
            _logManager = logManager;
            _logManager.AddUserLog(new UserLog{ CompName = "comp", SendingDateTime = DateTime.Now});
        }
        [HttpPost]
        public IActionResult Post(UserLog file)
        {
            _logManager.AddUserLog(file);
            return Ok();
        }

        [HttpGet]
        public List<UserLog> GetUserLogs()
        {
            return _logManager.GetUserLogs();
        }
    }
}
