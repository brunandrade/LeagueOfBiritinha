using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace EngineRPG.MapElements
{
    public class skill:MapaElement
    {
        public ImageBrush skilcima = new ImageBrush();
        public ImageBrush skilbaixo = new ImageBrush();
        public ImageBrush skildireita = new ImageBrush();
        public ImageBrush skilesquerda = new ImageBrush();
        public int coluna = 0;
        public void skillmatriz(Mapa MAtriz, skill skill)
    {
            skill.coluna = MAtriz.c + 1;
            while (MAtriz.ponto[MAtriz.l, skill.coluna + 1].caminhar != 0)
            {
                MAtriz.ponto[MAtriz.l, skill.coluna] = new Caminho();
                MAtriz.ponto[MAtriz.l, skill.coluna + 1] = skill;
                skill.coluna++;
            }
            MAtriz.ponto[MAtriz.l, skill.coluna] = new Caminho();
        }
        public ImageBrush Anim(Personagem personagem,Personagem inimigo)
        {
            if (personagem.dirpoder == "Direita")
            {
                if (personagem.Ataque - inimigo.Defesa / 2 > 0)
                {
                    inimigo.Vida -= personagem.Ataque - inimigo.Defesa / 2;
                }
                if (inimigo.Vida < 0)
                {
                    inimigo.Vida = 0;
                }
                return personagem.skill.skildireita;
            }
            else if (personagem.dirpoder == "Esquerda")
            {
                if (personagem.Ataque - inimigo.Defesa / 2 > 0)
                {
                    inimigo.Vida -= personagem.Ataque - inimigo.Defesa / 2;
                }
                if (inimigo.Vida < 0)
                {
                    inimigo.Vida = 0;
                }
                return personagem.skill.skilesquerda;

            }
            else if (personagem.dirpoder == "Baixo")
            {
                inimigo.Vida -= personagem.Ataque - inimigo.Defesa / 2;
                if (inimigo.Vida < 0)
                {
                    inimigo.Vida = 0;
                }
                return personagem.skill.skilbaixo;

            }
            else if (personagem.dirpoder == "Cima")
            {
                inimigo.Vida -= personagem.Ataque - inimigo.Defesa / 2;
                if (inimigo.Vida < 0)
                {
                    inimigo.Vida = 0;
                }
                return personagem.skill.skilcima;
            }
            else
            {
                return null;
            }
        }
    }
    }


