using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class OptionsMenu : Menu
    {
        MenuItem Option1 = new MenuItem();
        public OptionsMenu()
        {
            Axis = "Y";
            Effects = "FadeEffect";

            Option1.Image.Text = "Option1";

            Items.Add(Option1);
        }
    }
}
