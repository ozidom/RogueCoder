using RogueCoder.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models.TileObjects
{
    public class Dice : BaseGameObject, ITile
    {
        public int Size { get; set; }

        public Tile GetTile()
        {
            string filename  = GameImages.DicePrefix + Size.ToString() +".png";
            return new Tile { row = Y, col = X, ID = ID, Description = this.Description, FileName = filename, canMove = false, blocked = false, visible = true };
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