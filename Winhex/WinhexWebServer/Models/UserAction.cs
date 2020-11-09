using System;
using System.ComponentModel.DataAnnotations;

namespace WinhexWebServer.Models
{
    public class UserAction
    {
        [Key]
        public int Id { get; set; }
        public DateTime ActionDateTime { get; set; }
        public string AppTitle { get; set; }
        public string TextLog { get; set; }
    }
}