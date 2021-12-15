using System;
using System.Collections.Generic;
using System.Text;

namespace BingoApp.Models
{
    public class User
    {
        public string playcard_token { get; set; }
        public BCard card { get; set; }
    }
}
