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
        }
        [HttpPost]
        public IActionResult Post(UserLog file)
        {
            _logManager.AddUserLog(file);
            return Ok();
        }
    }
}
