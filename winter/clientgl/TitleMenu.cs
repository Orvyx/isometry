using System;
using System.Collections.Generic;
using System.Linq;
namespace client
{
    public class TitleMenu : Menu
    {
        MenuItem NewGame = new MenuItem();
        MenuItem LoadGame = new MenuItem();
        MenuItem Options = new MenuItem();
        MenuItem Quit = new MenuItem();
        public TitleMenu()
        {
            Axis = "Y";
            Effects = "FadeEffect";

            NewGame.Image.Text = "New Game";
            NewGame.LinkType = "Screen";
            NewGame.LinkID = "GameplayScreen";

            LoadGame.Image.Text = "Load Game";

            Options.Image.Text = "Options";
            Options.LinkType = "Menu";
            Options.LinkID = "OptionsMenu";

            Quit.Image.Text = "Quit";
            Quit.LinkType = "Quit";

            Items.Add(NewGame);
            Items.Add(LoadGame);
            Items.Add(Options);
            Items.Add(Quit);
        }
    }
}
