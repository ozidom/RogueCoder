using RogueCoder.Models;
using RogueCoder.Models.GameObjects;
using RogueCoder.Models.TileObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RogueCoder.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult Sync(List<Tile> level)
        {
            Game game = GetGame(level);
            SetGame(game);
            return Json(game);
        }

        [HttpPost]
        public ActionResult Ping(List<Tile> level)
        {
            return null;
        }

        [HttpPost]
        public ActionResult RunCode(List<Tile> level, string code)
        {
            String[] codeLines = ConvertCodeFromText(code);
            Game game = GetGame(level);
            Computer computer = new Computer();
            Compiler compiler = new Compiler();
            string[] compileErrors = new string[10];
            List<string> runTimeErrors = new List<string>();
            List<ComputerAccessibleObject> newCaos = game.caos;
            Dictionary<int, string> compiledCode = compiler.Compile(codeLines, out compileErrors);
            computer.Run(compiledCode, ref newCaos, out runTimeErrors);

            //Process Lights
            LightCAO lights = newCaos.Cast<LightCAO>().FirstOrDefault(c => c.name == "light");
            game.Lights = lights.state;
           
            //Process Doors
            game.Doors = new bool[10];

            //Process Elevator
            game.Elevator = false;

            //Process auto Guns if applicable
            //game.AutoGun = false;

            //Process Message
            //game.message = "";
            
            game.caos = newCaos;

            SetGame(game);
            
            return Json(game);
        }

        private string[] ConvertCodeFromText(string code)
        {
            return code.Replace("\n", "").Split(';');
        }

        [HttpPost]
        public ActionResult NewLevel(List<Tile> level)
        {
            Game game = GetGame(level);
            game.GetNewLevel();
            SetGame(game);
            return Json(game);
        }

        [HttpPost]
        public ActionResult EndGame()
        {
            Session["game"] = null;
            return Json(null);
        }

        private Game GetGame(List<Tile> map)
        {
            Game game;
            if (Session["game"] == null)
            {
                game = new Game(1);
                Session["game"] = game;
            }

            game = (Game)Session["game"];
            if (map != null)
            {
                game.Level = map;
            }
            return game;
        }

        private void SetGame(Game game)
        {
            Session["game"] = game;
        }

    }
}
