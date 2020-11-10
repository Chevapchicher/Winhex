using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winhex.Models
{
    [Serializable]
    public class UserLog
    {
        public int Id { get; set; }
        public DateTime SendingDateTime { get; set; }
        public string CompName { get; set; }
        public List<UserAction> Logs { get; set; }

        public UserLog()
        {
            Logs = new List<UserAction>();
            CompName = "";
        }
    }
}
