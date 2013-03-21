﻿using RogueCoder.Models;
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
        private int hatchCode;
        
        public Game(int level)
        {
            level = 1;
            GetNewLevel();
            Random r = new Random();
            hatchCode = r.Next(500);
            Utility.Utility.SendNotificationEmail("RogueCoder - Notification - start game", "Just a note to say someones starting game " + DateTime.Now.ToLongDateString());
        
        }


        public void GetNewLevel()
        {
            level++;
            Utility.Utility.SendNotificationEmail("RogueCoder - Notification new level", "Just a note to say someones climbing level onto lv: " + level.ToString() + " on" + DateTime.Now.ToLongDateString());
         
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
           
            LoadWallsForLevel();

            //Add the CAOs
            caos = new List<ComputerAccessibleObject>();
            caos.Add(new LightCAO{name="light",password="123"});

        
            caos.Add(new LightCAO { name = "light", password = "123" });
            Elevator = true;
          

            if (level == 2)
            {
                
                caos.Add(new ElevatorLockCAO { name = "ElevatorLock", password = "123",state=false });
                Elevator = false;
            }

            if (level == 3)
            {
                Random r = new Random();
                int  code = r.Next(500);
                caos.Add(new ElevatorLockCAO { name = "ElevatorLock", password = code.ToString(), state = false });
                Elevator = false;
            }

            if (level == 4)
            {
               
                caos.Add(new HatchCAO { name = "Hatch", password =hatchCode.ToString() });
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

            }

        }

        private void LoadPrisonersForLevel(int levelNumber)
        {
            Random r = new Random();
            switch (levelNumber)
            {
                case 1:
                    Level.Add(new Creature(999, "Prisoner:Tigger", GameImages.Prisoner, 100, 40, 2, 2, false,
                              new string[3] { "CONNECT - Connect to any device by typing 'CONNECT [OBJECT] [PASSWORD]", "Tigger - they call me tigger because I get excited, so what who doesn't get excited about code", "Masters - You need to find a guy called Masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Turnstyles", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Advice - you can find lots of advice for this game on my blog domscode.com, if only you had access to a browser  ", "DominicScript -I actually wrote dominic scipt when I worked here in this prison years ago, its the language used for all prison computers to talk to various devices and objects, remember to finish lines with a ; ", "Help -  my favourite command is HELP" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Fingers", GameImages.Prisoner, 300, 300, 2, 2, false,
                              new string[3] { "DominicScript - Each line processed is 1 process step, a max of 10000 process steps for each program  ", "Samples - remember the sample code, don't re move the two dashes for the actual comments lines and make sure that the comment lines have ;  to end ", "Passwords - I think passwords for any device is a number < 500" }).GetTile());  
                    break;
                case 2:
                    Level.Add(new Creature(999, "Prisoner:Masters", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Prime Numbers - So have you heard my theory about prime numbers, I think all the passwords are based on prime numbers", "Book - You know I wrote a great book a few years ago, its about a alternatate universe with Men and Women on opposite sides...", "Cool Command - not sure its common knowlege but LISTOBJECTS is very useful" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Pants", GameImages.Prisoner, 240, 280, 2, 2, false,
                              new string[3] { "Advice - You need to connect to a device before you can do anything, some devices have passwords, just use CONNECT [DEVICE NAME]", "Passwords - all passwords used here are numbers and I think a lot have a default of 123, Masters idea about prime numbers is rubbish, ignore that!!!", "Favourite command - you can use VARINT [VARNAME];, VARBOOL [VARNAME]; and VARSTRING [VARNAME]; to create variables then to display one of them use DISPLAYVAR [VARNAME]  " }).GetTile());
                    break;
                case 3:
                    Level.Add(new Creature(999, "Prisoner:Fingers", GameImages.Prisoner, 290, 300, 2, 2, false,
                              new string[3] { "Good Code - Comments need two dashes, Every line needs to finish with a ; derrrrrrrrr", "Escape - I think there is a hidden hatch on level 4", "Fingers - I got the name cause I like to stick my code fingers everywhere" }).GetTile());
                    Level.Add(new Creature(999, "Prisoner:Cranky", GameImages.Prisoner, 150, 40, 2, 2, false,
                              new string[3] { "Masters - don't listen to Masters particularly anything to do with Bukeroo Banzai or Prime Numbers ", "LOOPS - You use LOOPSTART n; to start a a loop for n times, then add your code lines below then finalise the loop with a LOOPEND;", "Masters - You need to find masters on level 2, if he's not there today come back later on, seriously you need him" }).GetTile());
            break;
                case 4:
            Level.Add(new Creature(999, "Prisoner:Ghost", GameImages.BlackTile, 370, 40, 2, 2, false,
                              new string[3] { "Ghost - Yes thats me - I am just a friendly programmer ghost ", "Death - I couldn't live without coding, I was lost, I was .... what is that you have ... is it a keyboard ... I haven't seen one of those for a while, my precious!!!", "Escape - you need to connect to the hatch don't know the password but you should be able to create a loop to detect it" },false).GetTile());
            Level.Add(new Creature(999, "Prisoner:Scott Hanselman", GameImages.Prisoner, 200, 200, 2, 2, false,
                              new string[3] { "Ghost - in the bottom left corner I think there is ghost, he just keeps moaning during the night maybe it's just a project manager, he certainly moans enough to be a project manager", "Websites - Hanselman.com, Hanselminutes.com, thisdeveloperslife.com and lots more, come visit next time you get an internet connection...", "Programming - check out Uncle Bob's interviews on Hanselman.com and DotNetRocks, that guy can code" }).GetTile());
                   break;
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
