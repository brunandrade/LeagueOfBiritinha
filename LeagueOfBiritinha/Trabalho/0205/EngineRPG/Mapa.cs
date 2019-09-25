using EngineRPG.MapElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EngineRPG
{
    public abstract class Mapa
    {
        public int l = -1, c = -1;
        public int Idmap = 0;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public MapaElement[,] ponto;
        public bool Colidir(String controle, Personagem cap, Mapa matriz)
        {
            if (controle == "D")
            {
                if (matriz.ponto[l, c + 1].caminhar != 0)
                {
                    //if(matriz.ponto[l, c + 1].caminhar == 2)
                    //{
                    //    cap.pegaritem(matriz, matriz.l, matriz.c+1);
                    //}
                    matriz.ponto[l, c + 1] = cap;
                    matriz.ponto[l, c] = new Caminho();
                    c++;
                    return true;
                }
                else
                {
                    return false;
                }

            }

            else if (controle == "A")
            {
                if (matriz.ponto[l, c - 1].caminhar != 0)
                {
                    //if (matriz.ponto[l, c - 1].caminhar == 2)
                    //{
                    //    cap.pegaritem(matriz, matriz.l, matriz.c -1);
                    //}
                    matriz.ponto[l, c - 1] = cap;
                    matriz.ponto[l, c] = new Caminho();
                    c--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (controle == "S")
            {
                if (matriz.ponto[l + 1, c].caminhar != 0)
                {
                    //if (matriz.ponto[l+1, c].caminhar == 2)
                    //{
                    //    cap.pegaritem(matriz, matriz.l+1, matriz.c);
                    //}
                    matriz.ponto[l + 1, c] = cap;
                    matriz.ponto[l, c] = new Caminho();
                    l++;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (controle == "W")
            {
                if (matriz.ponto[l - 1, c].caminhar != 0)
                {
                    //if (matriz.ponto[l-1, c].caminhar == 2)
                    //{
                    //    cap.pegaritem(matriz, matriz.l-1, matriz.c);
                    //}
                    matriz.ponto[l - 1, c] = cap;
                    matriz.ponto[l, c] = new Caminho();
                    l--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    public class MapaExploracao : Mapa
    {
        public MapaExploracao()
        {
            Idmap = 1;
            l = 2;
            c = 8;
            this.iniciarMapa();
        }
        public async void iniciarMapa()
        {
            this.ponto = new MapaElement[22, 43];
            for (int i = 0; i <= 21; i++)
            {
                for (int j = 0; j <= 42; j++)
                {
                    this.ponto[i, j] = new Barreira();
                }
            }

            //Plota a estrada
            for (int i = 2; i <= 2; i++)
            {
                for (int j = 8; j <= 15; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 15; j <= 15; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 14; i <= 14; i++)
            {
                for (int j = 1; j <= 15; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 7; i <= 14; i++)
            {
                for (int j = 1; j <= 1; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 7; i <= 7; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 2; i <= 7; i++)
            {
                for (int j = 8; j <= 8; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }

            for (int i = 15; i <= 20; i++)
            {
                for (int j = 7; j <= 7; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 20; i <= 20; i++)
            {
                for (int j = 7; j <= 16; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 18; i <= 20; i++)
            {
                for (int j = 16; j <= 16; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 8; i <= 8; i++)
            {
                for (int j = 16; j <= 24; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 18; i <= 18; i++)
            {
                for (int j = 16; j <= 24; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 13; i <= 18; i++)
            {
                for (int j = 24; j <= 24; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 13; i <= 13; i++)
            {
                for (int j = 24; j <= 34; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 3; i <= 20; i++)
            {
                for (int j = 34; j <= 34; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 3; i <= 8; i++)
            {
                for (int j = 24; j <= 24; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 3; i <= 3; i++)
            {
                for (int j = 24; j <= 41; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 20; i <= 20; i++)
            {
                for (int j = 34; j <= 41; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            for (int i = 3; i <= 20; i++)
            {
                for (int j = 41; j <= 41; j++)
                {
                    this.ponto[i, j] = new Caminho();

                }
            }
            this.ponto[2, 39] = new Caminho();
            this.ponto[2, 8] = new Personagem();
            this.ponto[14, 15] = ItemAleatorio(RandomNumber(1, 11));
            await Task.Delay(500);
            this.ponto[1, 39] = ItemAleatorio(RandomNumber(1, 11));
            await Task.Delay(500);
            this.ponto[13, 34] = ItemAleatorio(RandomNumber(1, 11));
            await Task.Delay(500);
            this.ponto[20, 7] = ItemAleatorio(RandomNumber(1, 11));

        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            int numRandom = random.Next(min, max);
            return numRandom;

        }

        public Item ItemAleatorio(int num)
        {
            if (num == 1)
            {
                Biritinha biritinha = new Biritinha();
                return biritinha;

            }


            else if (num == 2)
            {
                CaninhaDaRoça caninhadaroça = new CaninhaDaRoça();
                return caninhadaroça;

            }

            else if (num == 3)
            {
                Pitu pitu = new Pitu();
                return pitu;
            }
            if (num == 4)
            {
                Catuaba catuaba = new Catuaba();
                return catuaba;

            }


            else if (num == 5)
            {
                Cinquentaeum cinquentaeum = new Cinquentaeum();
                return cinquentaeum;

            }

            else if (num == 6)
            {
                Engov engov = new Engov();
                return engov;
            }
            else if (num == 7)
            {
                Warmog warmog = new Warmog();
                return warmog;
            }
            else if (num == 8)
            {
                Reicaido reicaido = new Reicaido();
                return reicaido;
            }
            else if (num == 9)
            {
                Caju caju = new Caju();
                return caju;
            }
            else if (num == 10)
            {
                Limaocommel limaocommel = new Limaocommel();
                return limaocommel;
            }

            else
            {
                return null;
            }

        }

        public MapaElement GetElement(int x, int y)
        {
            MapaElement me = this.ponto[x, y];
            return me;
        }

    }
    public class MapaBatalha:Mapa
    {
        public MapaBatalha()
        {
            l = 12;
            c = 18;
            Idmap = 2;
            this.iniciarMapa();
        }
        public void iniciarMapa()
        {
            this.ponto = new MapaElement[22, 43];
            for (int i = 0; i <= 21; i++)
            {
                for (int j = 0; j <= 42; j++)
                {
                    this.ponto[i, j] = new Barreira();
                }
            }
            for (int i = 4; i <= 17; i++)
            {
                for (int j = 15; j <= 28; j++)
                {
                    this.ponto[i, j] = new Caminho();
                }

            }
            for (int i = 5; i <= 14; i++)
            {
                for (int j = 14; j <= 14; j++)
                {
                    this.ponto[i, j] = new Caminho();
                }

            }
            for (int i = 5; i <= 14; i++)
            {
                for (int j = 29; j <= 29; j++)
                {
                    this.ponto[i, j] = new Caminho();
                }

            }
            this.ponto[12, 18] = new Personagem();
        }
    }

}
