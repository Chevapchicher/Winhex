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
        [HttpGet("{comp}")]
        public UserLog GetUserLog(string comp)
        {
            return _logManager.GetUserLog(x => x.CompName == comp) ?? new UserLog();
        }
        [HttpGet]
        public UserLog[] GetUserLogs()
        {
            return _logManager.GetUserLogs();
        }
    }
}
