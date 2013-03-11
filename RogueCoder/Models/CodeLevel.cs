using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models
{
    [Serializable]
    public class CodeLevel
    {
        public String code { get; set; }
        public List<Tile> level { get; set; }
    }
}