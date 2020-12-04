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
        [HttpGet("{id}/{key}")]
        public UserLog GetUserLog(int id, string key)
        {
            if (key == "ypuruveme")
                return _logManager.GetUserLog(x => x.Id == id) ?? new UserLog();
            return new UserLog();
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
