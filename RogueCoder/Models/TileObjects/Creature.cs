using RogueCoder.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models.TileObjects
{
    public class Creature : BaseGameObject, ITile
    {
        string fileName;
        public int Power { get; set; }
        bool HasComputer { get; set; }
        bool CanMove { get; set; }
        string[] Conversation { get; set; }
        public Creature(int id,string description,string fileName,int x, int y,int power,int dice,bool canMove,string[] conversation)
        {
            ID = id;
            Description = description;
            X = x;
            Y = y;
            this.fileName = fileName;
            this.Power = power;
            this.dice = dice;
            CanMove = canMove;
            Conversation = conversation;

            HasComputer = false;
            
        }

        public Tile GetTile()
        {
            string[] conversation = new string[3];

            Tile t = new Tile { row = Y, col = X, ID = ID, Description = this.Description, FileName = fileName, canMove = CanMove, blocked = false, visible = true,directionImage=Conversation,HasLaptop=false };
            return t;
        }

        public int X { get;set;}
        public int Y { get;set;}
        public int dice { get; set; } 
    }
}