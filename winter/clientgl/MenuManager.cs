using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace client
{
    public class MenuManager
    {
        Menu menu;
        bool isTransitioning;
        string currentID = string.Empty;
        Stack<String> depth = new Stack<String>();
        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }
        void menu_OnMenuChange(object sendert, EventArgs e)
        {
            menu.UnloadContent();
            currentID = menu.ID;
            menu = (Menu)Activator.CreateInstance(Type.GetType("client." + menu.ID));
            menu.LoadContent();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        public void LoadContent(string menuPath)
        {
            if(menuPath != String.Empty)
            {
                menu.ID = menuPath;
            }
        }
        public void UnloadContent()
        {
            menu.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
            if(InputManager.Instance.KeyPressed(Keys.Enter, Keys.Space) && !isTransitioning)
            {
                isTransitioning = true;
                if (menu.Items[menu.ItemNumber].LinkType == "Quit")
                {
                    menu.UnloadContent();
                    ScreenManager.Instance.Quit = true;
                }
                else if (menu.Items[menu.ItemNumber].LinkType == "Screen")
                    ScreenManager.Instance.ChangeScreen(menu.Items[menu.ItemNumber].LinkID);
                else if (menu.Items[menu.ItemNumber].LinkType == "Menu")
                {
                    depth.Push(currentID);
                    menu.ID = menu.Items[menu.ItemNumber].LinkID;
                }
                isTransitioning = false;
            }
            else if (InputManager.Instance.KeyPressed(Keys.Escape) && !isTransitioning)
            {
                if(depth.Count > 0)
                {
                    menu.ID = depth.Pop();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
