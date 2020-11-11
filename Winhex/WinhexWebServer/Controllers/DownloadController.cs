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
    [Route("download")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private ILogManager _logManager;
        public DownloadController(ILogManager logManager)
        {
            _logManager = logManager;
        }
        [HttpGet("{id}")]
        public UserLog GetUserLog(int id)
        {
            return _logManager.GetUserLog(x => x.Id == id) ?? new UserLog();
        }
        [HttpGet]
        public UserLog[] GetUsers()
        {
            return _logManager.GetUsers();
        }

        [HttpPost]
        public IActionResult SetCustomNote(UserLog note)
        {
            if (_logManager.SetNote(note.Id, note.CustomNote)) return Ok();
            return BadRequest();
        }
    }
}
