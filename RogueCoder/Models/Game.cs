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
        public bool Hatch { get; set; }
        
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

            if (level == 1)
            {
                caos.Add(new LightCAO { name = "light", password = "123" });
            }

            if (level == 2)
            {
                
                caos.Add(new ElevatorLockCAO { name = "Elevator Lock", password = "123" });
            }

            if (level == 4)
            {
                Random r = new Random();
                int randomNumber = r.Next(1000);
                caos.Add(new HatchCAO { name = "Hatch", password =randomNumber.ToString() });
            }

       


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
                    Level.Add(CreatureFactory.CreateCreature(0, GameEnums.CreatureType.guardlevel2, 220, 160, 4,4).GetTile());
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
                    Level.Add(new Creature(999, "Prisoner:Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - I really like pizza, hey we should have pizza one day", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - You need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Turnstyles", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Advice - there is a laptop hidden in the corner - the guards will kill me if I go near it ", "Help -  my favourite command is HELP" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Another", GameImages.Prisoner, 300, 300, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com - if only you had access to a browser  ", "Advice - there is a laptop hidden in the corner - the guards will kill me if I go near it ", "Help -  my favourite command is HELP" }).GetTile());
                  
                              
                    break;
                case 2:
                    Level.Add(new Creature(999, "Prisoner:Masters", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Help -  my favourite command is HELP", "Helper Classes - I love helper classes and HELP", "Cool Command - not sure its common knowlege but LISTOBJECTS is very useful" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Grisha", GameImages.Prisoner, 240, 280, 2, 2, false,
                              new string[3] { "Advice - You need to connect to a device before you can do anything - some devices have passwords - just use CONNECT [DEVICE NAME]", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile());
                    break;
                case 3:
                    Level.Add(new Creature(999, "Prisoner:Fingers", GameImages.Prisoner, 290, 300, 2, 2, false,
                              new string[3] { "Good Code - Comments need two dashes, Every line needs to finish with a ; derrrrrrrrr", "Helper Classes - I hate helper classes,helper classes are for dummies", "Static - I hate static freakin methods, you'd have to be mad to use statics" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Cranky", GameImages.Prisoner, 150, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
            break;
                case 4:
            Level.Add(new Creature(999, "Prisoner:Treebeard", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "Pizza - Try to get the pizza on level 2 it will give you a boost", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - YOu need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
            Level.Add(new Creature(999, "Prisoner:Snarler", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Ghost - in the bottom left corner I think there is ghost, he just keeps moaning during the night maybe it's just a project manager, he certainly moans enough to be a project manager", "Code Generation - there is nothing wrong with wrting your own code generator, Actually I have written one for for dominicscript - I have a copy around here, hey did you see my keys...", "Programming - check out domscode for advive on writing dominicscript" }).GetTile());
           /* Level.Add(new Creature(999, "Ghost", GameImages.Prisoner,30, 440, 2, 2, false,
                            new string[3] { "Advice - don't anoy me ", "Code Generation - there is nothing wrong with wrting your own code generator, Actually I have written one for for dominicscript - I have a copy around here, hey did you see my keys...", "Escape - try this code on level 5 connect to the HATCH and then EXECUTE HATCH OPEN" },false).GetTile());

                    Level.Add(new Creature(999, "Prisoner:Scott Hanselman", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - You should check out Hanselman.com, Hanselminutes.com, thisdeveloperslife.com, have I forgotten anything else, oh but you won't be able to see them from here because we don't get the internet in jail, bummer ", "Me - You should come and see me when I get out of prison at one of my presentations, check Hanselman.com for details, I thats right we don't get the  internet here, bummer ", "Escape - Ok so they say there's no way to escape but I have heard of a ghost on level 4 who might know how to do it." }).GetTile());
                */   break;

            }

        }

        private void LoadItemsForLevel()
        {
          
            Random r = new Random();
            int randomX = r.Next(300)+40;
            int randomY = r.Next(300)+40;
            bool isElevatorVisible = level < 5;
            //place the elevator
           Level.Add(new Tile { row = 420, col = 340, FileName = GameImages.Elevator, Description = "Elevator", canMove = false, ID = 0, visible = isElevatorVisible });
     
        }


        public bool Elevator { get; set; }

        public bool[] Doors { get; set; }

        public string Output { get; set; }
    }
}
