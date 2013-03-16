using RogueCoder.Models.GameObjects;
using RogueCoder.Models.TileObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models
{
    public class CreatureFactory
    {
        public static Creature CreateCreature(int id, RogueCoder.Models.GameEnums.CreatureType type,int x,int y,int power,int dice)
        {
            string description, imageFileName;
            CreateCreatureProperties(type, out description, out imageFileName);
            string[] conv = new string[2];
            Creature c = new Creature(id, description, imageFileName,x,y,power,dice,true,conv);
            return c;
        }

        private static void CreateCreatureProperties(RogueCoder.Models.GameEnums.CreatureType type, out string description, out string imageFileName)
        {
            switch (type)
            {
                case GameEnums.CreatureType.human:
                    description = "Hero";
                    imageFileName = GameImages.Hero;
                    break;
                case GameEnums.CreatureType.guardlevel1:
                    description = "Guard";
                    imageFileName = GameImages.LevelOneGuard;
                    break;
                case GameEnums.CreatureType.guardlevel2:
                    description = "Guard";
                    imageFileName = GameImages.LevelTwoGuard;
                    break;
                case GameEnums.CreatureType.guardlevel3:
                    description = "Guard";
                    imageFileName = GameImages.LevelThreeGuard;
                    break;
                case GameEnums.CreatureType.guardlevel4:
                    description = "Guard";
                    imageFileName = GameImages.LevelFourGuard;
                    break;
                case GameEnums.CreatureType.guardlevel5:
                    description = "Guard";
                    imageFileName = GameImages.LevelFiveGuard;
                    break;
                case GameEnums.CreatureType.Prisoner:
                    description = "Prisoner";
                    imageFileName = GameImages.Prisoner;
                    break;
                default:
                    description = "Nothing";
                    imageFileName = GameImages.BlueTile;
                    break;
            }
        }


    }
}