using RogueCoder.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models.TileObjects
{
    public class Step :BaseGameObject,ITile
    {
        public Tile GetTile()
        {
            Tile t = new Tile { row = Y, col = X, ID = ID, Description = this.Description, FileName = GameImages.Steps, canMove = false, blocked = false,visible = true };
            return t;
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