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
            level = 1;
            GetNewLevel();
        }


        public void GetNewLevel()
        {
            level++;
            Level = null;
            Level = new List<Tile>();
            Lights = true;

            //Add our player
            Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.human, 50, 50,8,6).GetTile());

            //Now add the items
            LoadItemsForLevel();

            //Now add the guards
            LoadGuardsForLevel(level);

            //Load Prisoners
            LoadPrisonersForLevel(level);
            //var prisoners = GetRandomProgrammers(level);
            //prisoners.ToList().ForEach(p => Level.Add(p));
           

            LoadWallsForLevel();

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

            //bottomwall
            for (int i = 0; i <= 400; i += 20)
                Level.Add(new Tile { row = 480, col = i, FileName = GameImages.BlueTile, Description = "Wall", canMove = false, ID = i, visible = true });
                    
              
        }

        private void LoadGuardsForLevel(int levelNumber)
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
                    Level.Add(new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile());
                    break;
                case 2:
                    Level.Add(new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile());
                 
                    break;
                case 3:
                     Level.Add(new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile());
                   break;
                case 4:
                     Level.Add(new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile());
                 
                    break;
                case 5:
                    Level.Add(new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile());
                   break;

            }

        }



        private Tile[] GetRandomProgrammers(int level)
        {
            Tile[] allPrisoners = new Tile[27];

            GetAllPrisoners(allPrisoners);
            //var prisonersSelected = allPrisoners.ToList().Skip((level - 1) * 5).Take(5);

            var prisonersSelected = allPrisoners.ToList().Take(5);
            return prisonersSelected.ToArray();
        }

        private static void GetAllPrisoners(Tile[] prisoners)
        {
            //1
            prisoners[0] = new Creature(999, "Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile();
            prisoners[1] = new Creature(999, "Dom", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Programming - Iterate or perish" }).GetTile();
            prisoners[2] = new Creature(999, "Weird Al", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Help -  my favourite command is HELP", "Helper Classes - I love helper classes and HELP", "Try to find a mouse - its actually a good weapon" }).GetTile();
            prisoners[3] = new Creature(999, "Grisha", GameImages.Prisoner, 240, 280, 2, 2, false,
                              new string[3] { "Advice - You need to connect to a device before you can do anything - some devices have passwords - just use CONNECT [DEVICE NAME]", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[4] = new Creature(999, "Fingers", GameImages.Prisoner, 290, 300, 2, 2, false,
                              new string[3] { "Good Code - Comments need two dashes, Every line needs to finish with a ; derrrrrrrrr", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[5] = new Creature(999, "Tigger", GameImages.Prisoner, 150, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile();
            //2
            prisoners[6] = new Creature(999, "Gigantour", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - If you need to loop then remember ", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[7] = new Creature(999, "G Man", GameImages.Prisoner, 100, 100, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[8] = new Creature(999, "Yaa", GameImages.Prisoner, 150, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[9] = new Creature(999, "Masters", GameImages.Prisoner, 290, 340, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[10] = new Creature(999, "Farty", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();

            //3
            prisoners[11] = new Creature(999, "West Ham Stan", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[12] = new Creature(999, "Damo", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[13] = new Creature(999, "XXXXXX", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[14] = new Creature(999, "Little Boris", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[15] = new Creature(999, "Richmond", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();

            //4
            prisoners[16] = new Creature(999, "Paul", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[17] = new Creature(999, "XXXXX", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[18] = new Creature(999, "Yogi Bear", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Level 5- I hear that the guards can not be touched" }).GetTile();
            prisoners[19] = new Creature(999, "DJ", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Command - " }).GetTile();
            prisoners[20] = new Creature(999, "TreeBeard", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();

            //5
            prisoners[21] = new Creature(999, "XXXXXX", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[22] = new Creature(999, "Cranky", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[23] = new Creature(999, "Kevin Home Alone", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[25] = new Creature(999, "Microsoft Cameron", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
            prisoners[26] = new Creature(999, "Uncle John", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Good Code - You want the good code, you can't handle good code", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile();
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

        public string Output { get; set; }
    }
}
