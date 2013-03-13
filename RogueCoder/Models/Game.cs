using RogueCoder.Models;
using RogueCoder.Models.GameObjects;
using RogueCoder.Models.TileObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueCoder.Models
{
    public class Game
    {
        public List<Tile> Level { get; set; }
        public int CurrentLevel { get { return level; } }
        public List<ComputerAccessibleObject> caos { get; set; }
 
        public bool Lights { get; set; }
        private int level;
        
        public Game(int level)
        {
            level = 0;
            GetNewLevel();
        }


        public void GetNewLevel()
        {
            //todo rue 3
            //workout the level challenge
            //1. doors no password weapon keyboard - simple connect code
            //2. doors password weapon mouse  - detect pwd code
            //3. hidden guards - detect pwd connect lights and turn off
            //4. guns - detect pwd connect guns and shoot guards
            //5. hidden guards - diconnect trap - need to detect messages hero will disconnect door 
            level++;
            Level = new List<Tile>();
            Lights = true;

            //Add our player
            Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.human, 50, 50,8,6).GetTile());

            //Now add the items
            LoadItemsForLevel();

            //Now add the creatures
            LoadCreaturesForLevel(level);
            
            //Load Prisoners
            LoadHighSecurityPrisonersForLevel(level);

            //Load Prisoners
            LoadPrisonersForLevel(level);

            LoadWallsForLevel();

            //LoadCellsForLevel();

            //todo tue 2
            //putprisoners in cell

            //Add the code tile
            //Level.Add(new Tile { row = 0, col = 0, canMove = false, visible = false, Description = "Code" });

            //Add the CAOs
            caos = new List<ComputerAccessibleObject>();
            caos.Add(new LightCAO{name="light",password="123"});


        }

        private void LoadWallsForLevel()
        {
            //topwall
            for (int i = 0; i < 380; i += 20)
                Level.Add(new Tile { row = 0, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i,visible=true });

            //midwalls
            for (int i = 0; i < 480; i += 20)
            {
                Level.Add(new Tile { row = i, col = 0, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
                Level.Add(new Tile { row = i, col = 380, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
            }
/*
            for (int i = 0; i < 400; i += 40)
                Level.Add(new Tile { row = 440, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
            for (int i = 0; i < 400; i += 40)
                Level.Add(new Tile { row = 460, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
           
*/
            
                //Level.Add(new Tile { row = 440, col = i, FileName = GameImages.BlueTile, Description = "Door", canMove = false, ID = i, visible = true, HasLaptop=false,blocked=false,directionImage=null });
           

            //bottomwall
            for (int i = 0; i < 400; i += 20)
                Level.Add(new Tile { row = 480, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
               
            //ad below
            //int doorCount = 1;
            //for (int i = 20; i < 360; i += 40)
            //    Level.Add(new Tile { row = 460, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
           
            
        }

        private void LoadCreaturesForLevel(int levelNumber)
        {
            Random r = new Random();
            switch(levelNumber)
            {
                case 1:
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel1, 200,250,4,3).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel1, 130, 270, 4, 3).GetTile());
                    break;
                case 2:
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel2, 180, 160, 4,4).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel2, 160, 260, 5,4).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel2, 190, 160, 4,4).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel2, 160, 360, 5,4).GetTile());
                   
                    break;
                case 3:
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel3, 190, 160, 4,10).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel3, 280, 380, 5,6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel3, 160, 260, 6, 6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel3, 190, 160, 4, 6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel3, 280, 380, 5, 8).GetTile());
                    break;
                case 4:
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 190, 160, 4,6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 280, 380, 5, 8).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 160, 260, 5, 10).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 160, 260, 5, 10).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 280, 380, 5, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel4, 160, 260, 12, 12).GetTile());
                 
                    break;
                case 5:
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 190, 160, 6, 6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 280, 380, 5, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 160, 260, 12, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 190, 160, 6, 6).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 280, 380, 5, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 160, 260, 12, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 280, 380, 12, 12).GetTile());
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel5, 160, 260, 20, 20).GetTile());
                
                    
                    break;

            }

        }

        private void LoadPrisonersForLevel(int levelNumber)
        {
            Random r = new Random();
            switch (levelNumber)
            {
                case 1:
                    string[] co = new string[2];
                    co[0] = "hi";
                    co[1] = "bi";
                    Level.Add(new Creature(999, "Programmer X", GameImages.Prisoner, 200, 200, 2, 2, false, co).GetTile());
                    break;
                case 2:
                     
                    break;
                case 3:

                    break;
                case 4:
                   
                    break;
                case 5:
                   
                    break;

            }

        }

        private void LoadHighSecurityPrisonersForLevel(int levelNumber)
        {
            Random r = new Random();
            switch (levelNumber)
            {
                case 1:
                    string[] co = new string[2];
                    co[0] = "I am in prison";
                    co[1] = "bi";
                    Level.Add(new Creature(999, "Programmer Y(High Security Prisoner)", GameImages.Prisoner, 20, 460, 2, 2, false, co).GetTile());
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;

            }

        }

        private void LoadItemsForLevel()
        {
          
            Random r = new Random();
            int randomX = r.Next(300)+40;
            int randomY = r.Next(300)+40;

            switch (CurrentLevel)
            {
                case 1:
                    //Level.Add(new Dice { Size = 6, Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    Level.Add(new laptop { Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    break;
                case 2:
                    // Level.Add(new Dice { Size = 8, Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    Level.Add(new laptop { Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    break;
                case 3:
                    // Level.Add(new Dice { Size = 10, Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    Level.Add(new laptop { Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    break;
                case 4:
                    //Level.Add(new Dice { Size = 12, Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    Level.Add(new laptop { Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    break;
                case 5:
                    //Level.Add(new Dice { Size = 20, Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    Level.Add(new laptop { Description = "LAPTOP", ID = 1, X = randomX, Y = randomY }.GetTile());
                    break;
            }

            //place the elevator
           Level.Add(new Tile { row = 420, col = 340, FileName = GameImages.Elevator, Description = "Elevator", canMove = false, ID = 0, visible = true });
     
        }


        public bool Elevator { get; set; }

        public bool[] Doors { get; set; }
    }
}
