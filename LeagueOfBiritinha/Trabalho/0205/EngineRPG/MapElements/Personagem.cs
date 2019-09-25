using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using EngineRPG;
using Windows.UI.Xaml;

namespace EngineRPG.MapElements
{
    public class Personagem : MapaElement
    {
        public String dirpoder = "Direita";
        public int id = 00;
        public int cont = 0;
        public Item[] inventario = new Item[6];
        public ImageBrush ib = new ImageBrush();
        public skill skill = new skill();
        public ImageBrush ibdireita = new ImageBrush();
        public int Vida, Ataque, Defesa;

        public void Atributos(Item item)
        {
            this.Vida += item.Vida;
            this.Defesa += item.Defesa;
            this.Ataque += item.Ataque;


        }

        public Personagem()
        {
            caminhar = 0;
            for (int i = 0; i < 6; i++)
            {
                inventario[i] = new Item();

            }
        }
        public ImageBrush imagemposicao(String x, int id)
        {
            if (id == 03)
            {
                if (x == "D")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/dir.png"));
                    this.dirpoder = "Direita";
                    return ib;
                }
                else if (x == "W")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/back.png"));
                    this.dirpoder = "Cima";
                    return ib;
                }
                else if (x == "S")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/front.png"));
                    this.dirpoder = "Baixo";
                    return ib;
                }
                else if (x == "A")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/esq.png"));
                    this.dirpoder = "Esquerda";
                    return ib;
                }
            }
            if (id == 04)
            {
                if (x == "D")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/ladraoDir.png"));
                    this.dirpoder = "Direita";
                    return ib;
                }
                else if (x == "W")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/ladraoBack.png"));
                    this.dirpoder = "Cima";
                    return ib;
                }
                else if (x == "S")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://League/Assets/ladraoFrente.png"));
                    this.dirpoder = "Baixo";
                    return ib;
                }
                else if (x == "A")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/ladraoEsq.png"));
                    this.dirpoder = "Esquerda";
                    return ib;
                }
            }

            if (id == 01)
            {
                if (x == "D")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/arqueiraDir.png"));
                    this.dirpoder = "Direita";
                    return ib;
                }
                else if (x == "W")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/arqueiraBack.png"));
                    this.dirpoder = "Cima";
                    return ib;
                }
                else if (x == "S")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://League/Assets/arqueiraFrente.png"));
                    this.dirpoder = "Baixo";
                    return ib;
                }
                else if (x == "A")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/arqueiraEsq.png"));
                    this.dirpoder = "Esquerda";
                    return ib;
                }
            }
            if (id == 02)
            {
                if (x == "D")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/guerreiroDir.png"));
                    this.dirpoder = "Direita";
                    return ib;
                }
                else if (x == "W")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/guerreiroBack.png"));
                    this.dirpoder = "Cima";
                    return ib;
                }
                else if (x == "S")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://League/Assets/guerreiroFrente.png"));
                    this.dirpoder = "Baixo";
                    return ib;
                }
                else if (x == "A")
                {
                    ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/guerreiroEsq.png"));
                    this.dirpoder = "Esquerda";
                    return ib;
                }
            }
            return null;
        }
        public bool pegaritem(Mapa Matriz, int l, int c)
        {
            if ((l == 1 && c == 39 || l == 14 && c == 15 || l == 13 && c == 34 || l == 20 && c == 7) && (Matriz.ponto[l, c].caminhar == 2))
            {
                if (Matriz.ponto[l, c].NumItem == 1)
                {
                    this.inventario[cont] = new Biritinha();
                }
                if (Matriz.ponto[l, c].NumItem == 2)
                {
                    this.inventario[cont] = new CaninhaDaRoça();
                }
                if (Matriz.ponto[l, c].NumItem == 3)
                {
                    this.inventario[cont] = new Pitu();
                }
                if (Matriz.ponto[l, c].NumItem == 4)
                {
                    this.inventario[cont] = new Catuaba();
                }
                if (Matriz.ponto[l, c].NumItem == 5)
                {
                    this.inventario[cont] = new Cinquentaeum();
                }
                if (Matriz.ponto[l, c].NumItem == 6)
                {
                    this.inventario[cont] = new Engov();
                }
                if (Matriz.ponto[l, c].NumItem == 7)
                {
                    this.inventario[cont] = new Warmog();
                }
                if (Matriz.ponto[l, c].NumItem == 8)
                {
                    this.inventario[cont] = new Reicaido();
                }
                if (Matriz.ponto[l, c].NumItem == 9)
                {
                    this.inventario[cont] = new Caju();
                }
                if (Matriz.ponto[l, c].NumItem == 10)
                {
                    this.inventario[cont] = new Limaocommel();
                }

                Matriz.ponto[l, c] = new Caminho();

                this.Atributos(inventario[cont]);

                if (cont < 6)
                {
                    cont++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public class ArqueiraP : Personagem
    {
        public ArqueiraP()
        {
            Vida = 150;
            Ataque = 120;
            Defesa = 70;
            id = 01;
            ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/arqueiraFrente.png"));
            ibdireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/arqueiraDir.png"));
            skill.skildireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/flecha.png"));
            skill.skilesquerda.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoEsq.png"));
            skill.skilbaixo.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoBaixo.png"));
            skill.skilcima.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoCima.png"));
        }
    }
        public class GuerreiroP : Personagem
        {
            public GuerreiroP()
            {
                Vida = 200;
                Ataque = 50;
                Defesa = 100;
                id = 02;
                ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/guerreiroFrente.png"));
                ibdireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/guerreiroDir.png"));
                skill.skildireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoDir.png"));
                skill.skilesquerda.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoEsq.png"));
                skill.skilbaixo.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoBaixo.png"));
                skill.skilcima.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoCima.png"));
        }
        }
        public class FeiticeiraP : Personagem
        {
            public FeiticeiraP()
            {
                Vida = 180;
                Ataque = 130;
                Defesa = 40;
                id = 03;
                ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/front.png"));
                ibdireita.ImageSource= new BitmapImage(new Uri("ms-appx://App1/Assets/dir.png"));
                skill.skildireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/magiaDir.png"));
                skill.skilesquerda.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/magiaEsq.png"));
                skill.skilbaixo.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/magiaBaixo.png"));
                skill.skilcima.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/magiaCima.png"));
        }

        }
        public class ZeGotinha : Personagem
        {
            public ZeGotinha()
            {
                dirpoder = "Esquerda";
                id = 05;
                Vida = 1000;
                Defesa = 200;
                Ataque = 100;
                ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/chefao2.png"));
                skill.skilesquerda.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/PoderChefao.png"));
        }
 
        }
        public class LadraoP : Personagem
        {
            public LadraoP()
            {
                Vida = 100;
                Ataque = 200;
                Defesa = 30;
                id = 04;
                ib.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/ladraoFrente.png"));
                ibdireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/ladraoDir.png"));
               skill.skildireita.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/facaEsq.png"));
                skill.skilesquerda.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/facaEsq.png"));
                skill.skilbaixo.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/facaBaixo.png"));
                skill.skilcima.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/facaDir.png"));
        }
        }

}

