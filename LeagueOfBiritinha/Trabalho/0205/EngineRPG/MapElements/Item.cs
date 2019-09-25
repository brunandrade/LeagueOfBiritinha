using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace EngineRPG.MapElements
{
    public class Item : MapaElement
    {
        public string nomeItem;
        public string ataqueItem;
        public string defesaItem;
        public string vidaItem;

        public int Id = 0;
        public ImageBrush itemImg = new ImageBrush();

        public int Vida, Defesa, Ataque;

        public Item()
        {
            caminhar = 2;
            NumItem = 0;
        }
    }

    
    
    public class Biritinha : Item
    {
        public Biritinha()
        {
            Vida = 300;
            Ataque = 200;
            Defesa = 100; 

            nomeItem = "Item Biritinha";

            vidaItem = "Vida = 300";
            ataqueItem = "Ataque = 200";
            defesaItem = "Defesa = 200";


            NumItem = 1;
            caminhar = 2;
            Id = 1;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemBiritinha.png"));

        }
    }

    public class CaninhaDaRoça : Item
    {

        public CaninhaDaRoça()
        {
            Vida = 250;
            Ataque = 150;
            Defesa = 50;

            nomeItem = "Item Caninha da Roça";

            vidaItem = "Vida = 250";
            ataqueItem = "Ataque = 150";
            defesaItem = "Defesa = 50";

            NumItem = 2;
            caminhar = 2;
            Id = 2;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemCaninha.png"));
        }

      
    }
    public class Pitu : Item
    {
        public Pitu()
        {
            Vida = 200;
            Ataque = 100;
            Defesa = 50;

            nomeItem = "Item Pitu";

            vidaItem = "Vida = 200";
            ataqueItem = "Ataque = 100";
            defesaItem = "Defesa = 50";

            NumItem = 3;
            caminhar = 2;
            Id = 3;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemPitu.png"));
        }
        
    }
    public class Catuaba : Item
    {
        public Catuaba(){

            Vida = 80;
            Ataque = 300;
            Defesa = 50;

            nomeItem = "Item Catuaba";

            vidaItem = "Vida = 80";
            ataqueItem = "Ataque = 300";
            defesaItem = "Defesa = 50";

            NumItem = 4;
            Id = 4;
            caminhar = 2;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemCatuaba.png"));
        }

    }
    public class Cinquentaeum:Item
    {
       public Cinquentaeum()
        {
            Vida = 50;
            Ataque = 40;
            Defesa = 0;

            nomeItem = "Item 51";

            vidaItem = "Vida = 50";
            ataqueItem = "Ataque = 40";
            defesaItem = "Defesa =  0";

            NumItem = 5;
            caminhar = 2;
            Id = 5;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/item51.png"));
        }
    }
    public class Engov : Item{
        public Engov()
        {
            Vida = 100;
            Ataque = 20;
            Defesa = 200;

            nomeItem = "Item Engov";

            vidaItem = "Vida = 100";
            ataqueItem = "Ataque = 20";
            defesaItem = "Defesa = 200";

            NumItem = 6;
            caminhar = 2;
            Id = 6;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemEngov.png"));

        }
    }
    public class Warmog : Item
    {
        public Warmog()
        {
            Vida = 100;
            Ataque = 0;
            Defesa = 0;

            nomeItem = "Item Warmog";

            vidaItem = "Vida = 100";
            ataqueItem = "Ataque = 0";
            defesaItem = "Defesa = 0";

            NumItem = 7;
            caminhar = 2;
            Id = 7;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemWarmog.png"));

        }
    }
    public class Reicaido : Item
    {
        public Reicaido()
        {
            Vida = 0;
            Ataque = 100;
            Defesa = 0;

            nomeItem = "Item Reicaido";

            vidaItem = "Vida = 0";
            ataqueItem = "Ataque = 100";
            defesaItem = "Defesa = 0";

            NumItem = 8;
            caminhar = 2;
            Id = 8;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemReicaido.png"));

        }
    }
    public class Caju : Item
    {
        public Caju()
        {
            Vida = 0;
            Ataque = 0;
            Defesa = 0;

            nomeItem = "Item Caju";

            vidaItem = "Vida = 0";
            ataqueItem = "Ataque = 0";
            defesaItem = "Defesa = 0";

            NumItem = 9;
            caminhar = 2;
            Id = 9;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemCaju.png"));
        }
    }
    public class Limaocommel : Item
    {
        public Limaocommel()
        {
            Vida = 100;
            Ataque = 20;
            Defesa = 50;

            nomeItem = "Item Limao Com Mel";

            vidaItem = "Vida = 100";
            ataqueItem = "Ataque = 20";
            defesaItem = "Defesa = 50";

            NumItem = 10;
            caminhar = 2;
            Id = 10;
            itemImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/itemLimaoComMEel.png"));
        }
    }
}
