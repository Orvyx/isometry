namespace client
{
    public class MenuItem
    {
        public string LinkType;
        public string LinkID;
        public Image Image;

        public MenuItem()
        {
            Image = new client.Image();
            Image.AccountForOrigin = true;
            Image.FontName = "menu_1";
        }
    }
}
