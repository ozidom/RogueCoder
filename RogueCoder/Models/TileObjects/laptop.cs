using RogueCoder.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models.TileObjects
{
    public class laptop : BaseGameObject
    {
        public Tile GetTile()
        {
            string filename = GameImages.LapTop;
            return new Tile { row = Y, col = X, ID = ID, Description = this.Description, FileName = filename, canMove = false, blocked = false, visible = true,directionImage=new string[2],HasLaptop=false };
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }
    }
}