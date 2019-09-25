using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using EngineRPG;
using EngineRPG.MapElements;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        Player[] p;
        MapaExploracao matriz = new MapaExploracao();
        Canvas Bau = new Canvas();
        Canvas Bau2 = new Canvas();
        Canvas Bau3 = new Canvas();
        Canvas Bau4 = new Canvas();

        Canvas TelaInventario = new Canvas();
        Canvas botaoFechar = new Canvas();

        Canvas slot1 = new Canvas();
        Canvas slot2 = new Canvas();
        Canvas slot3 = new Canvas();
        Canvas slot4 = new Canvas();
        Canvas slot5 = new Canvas();
        Canvas slot6 = new Canvas();

        TextBlock nome = new TextBlock();
        TextBlock AtaqueItem = new TextBlock();
        TextBlock VidaItem = new TextBlock();
        TextBlock DefesaItem = new TextBlock();

        public MainPage()
        {
            
            this.InitializeComponent();
            
        }
        
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
          
            p = e.Parameter as Player[];
            person.Background = p[0].personagem.ib;
            DescPlayer();
            BauMap();
            await Task.Delay(1500);
            CARREGAR.Text = " ";
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            base.OnNavigatedTo(e);

        }
        public void DescPlayer()
        {

            //VIDA
            Canvas life1 = new Canvas();
            life1.Height = 70;
            life1.Width = 70;
            ImageBrush lifeImg = new ImageBrush();
            lifeImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/heart.png"));
            life1.Background = lifeImg;
            Canvas.SetLeft(life1, 50);
            Canvas.SetTop(life1, 0);
            csvsMain.Children.Add(life1);

            //ATAQUE
            Canvas ataque = new Canvas();
            ataque.Height = 60;
            ataque.Width = 60;
            ImageBrush ataqueImg = new ImageBrush();
            ataqueImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/upg_sword.png"));

            if (p[0].personagem.id == 1)
            {
                ataqueImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/upg_bow.png"));
            }

            if (p[0].personagem.id == 02)
            {
                ataqueImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/machadoEsq.png"));
            }
            if (p[0].personagem.id == 03)
            {
                ataqueImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/upg_wand.png"));
            }
            if (p[0].personagem.id == 04)
            {
                ataqueImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/upg_sword.png"));
            }

            ataque.Background = ataqueImg;
            Canvas.SetLeft(ataque, 50);
            Canvas.SetTop(ataque, 50);
            csvsMain.Children.Add(ataque);


            //DEFESA
            Canvas defesa = new Canvas();
            defesa.Height = 60;
            defesa.Width = 60;
            ImageBrush defesaImg = new ImageBrush();
            defesaImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/upg_shield.png"));
            defesa.Background = defesaImg;
            Canvas.SetLeft(defesa, 50);
            Canvas.SetTop(defesa, 100);
            csvsMain.Children.Add(defesa);


            
        }

        public void BauMap()
        {
            //BAU1
            Bau.Height = 32;
            Bau.Width = 32;
            ImageBrush bauImg = new ImageBrush();
            bauImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/bauEsq.png"));
            Bau.Background = bauImg;
            csvsMain.Children.Add(Bau);

            Canvas.SetLeft(Bau, 480);
            Canvas.SetTop(Bau, 448);

            //BAU2
            Bau2.Width = 32;
            Bau2.Height = 32;
            ImageBrush bauImg2 = new ImageBrush();
            bauImg2.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/bauFrente.png"));
            Bau2.Background = bauImg2;
            csvsMain.Children.Add(Bau2);

            Canvas.SetLeft(Bau2, 1248);
            Canvas.SetTop(Bau2, 32);
            
            //BAU3
            Bau3.Width = 32;
            Bau3.Height = 32;
            ImageBrush bauImg3 = new ImageBrush();
            bauImg3.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/bauFrente.png"));
            Bau3.Background = bauImg3;
            csvsMain.Children.Add(Bau3);

            Canvas.SetLeft(Bau3, 1088);
            Canvas.SetTop(Bau3,416);

            //BAU4
            Bau4.Width = 32;
            Bau4.Height = 32;
            ImageBrush bauImg4 = new ImageBrush();
            bauImg4.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/bauBack.png"));
            Bau4.Background = bauImg4;
            csvsMain.Children.Add(Bau4);

            Canvas.SetLeft(Bau4, 224);
            Canvas.SetTop(Bau4, 640);

        }

        private void inventarioBotao_Click(object sender, RoutedEventArgs e)
        {
            TelaInventario = new Canvas();
            botaoFechar = new Canvas();

            TelaInventario.Height = 502;
            TelaInventario.Width = 333;
            ImageBrush imgInventario = new ImageBrush();
            imgInventario.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/inventario.png"));
            TelaInventario.Background = imgInventario;
            csvsMain.Children.Add(TelaInventario);
            Canvas.SetLeft(TelaInventario, 500);
            Canvas.SetTop(TelaInventario, 150);


            //ARMAZENAÇÃO DE ITEM NO INVENTARIO

            //SLOT 1      
            slot1.Height = 90;
            slot1.Width = 90;
            TelaInventario.Children.Add(slot1);
            Canvas.SetLeft(slot1,Canvas.GetLeft(TelaInventario) -465);
            Canvas.SetTop(slot1, Canvas.GetTop(TelaInventario) -70);
            slot1.Background = p[0].personagem.inventario[0].itemImg;
            slot1.Tapped += Slot1_Tapped;

            TelaInventario.Children.Add(nome);
            TelaInventario.Children.Add(VidaItem);
            TelaInventario.Children.Add(AtaqueItem);
            TelaInventario.Children.Add(DefesaItem);
            
            //SLOT 2
            slot2.Height = 90;
            slot2.Width = 90;
            TelaInventario.Children.Add(slot2);
            Canvas.SetLeft(slot2, Canvas.GetLeft(slot1) + 85);
            Canvas.SetTop(slot2, Canvas.GetTop(TelaInventario) - 70);
            slot2.Background = p[0].personagem.inventario[1].itemImg;
            slot2.Tapped += Slot2_Tapped;

            //SLOT 3
            slot3.Height = 90;
            slot3.Width = 90;
            TelaInventario.Children.Add(slot3);
            Canvas.SetLeft(slot3, Canvas.GetLeft(slot2) + 85);
            Canvas.SetTop(slot3, Canvas.GetTop(TelaInventario) - 70);
            slot3.Background = p[0].personagem.inventario[2].itemImg;
            slot3.Tapped += Slot3_Tapped;

            //SLOT 4
            slot4.Height = 90;
            slot4.Width = 90;
            TelaInventario.Children.Add(slot4);
            Canvas.SetLeft(slot4, Canvas.GetLeft(TelaInventario) - 470);
            Canvas.SetTop(slot4, Canvas.GetTop(slot1) + 90);
            slot4.Background = p[0].personagem.inventario[3].itemImg;
            slot4.Tapped += Slot4_Tapped;

            //SLOT 5
            slot5.Height = 90;
            slot5.Width = 90;
            TelaInventario.Children.Add(slot5);
            Canvas.SetLeft(slot5, Canvas.GetLeft(slot4) +90);
            Canvas.SetTop(slot5, Canvas.GetTop(slot1) + 90);
            slot5.Background = p[0].personagem.inventario[4].itemImg;
            slot5.Tapped += Slot5_Tapped;

            //SLOT 6
            slot6.Height = 90;
            slot6.Width = 90;
            TelaInventario.Children.Add(slot6);
            Canvas.SetLeft(slot6, Canvas.GetLeft(slot5) + 90);
            Canvas.SetTop(slot6, Canvas.GetTop(slot1) + 90);
            slot6.Background = p[0].personagem.inventario[5].itemImg;
            slot6.Tapped += Slot6_Tapped;

            //BOTAO FECHAR
            botaoFechar.Height = 64;
            botaoFechar.Width = 64;
            ImageBrush imgFechar = new ImageBrush();
            imgFechar.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/fechar.png"));
            botaoFechar.Background = imgFechar;
         
            TelaInventario.Children.Add(botaoFechar);

            botaoFechar.Tapped += BotaoFechar_Tapped;
             
        }

        private void Slot6_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[5].NumItem != 0)
            {
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[5].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[5].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[5].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[5].defesaItem;
            }
        }

        private void Slot5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[4].NumItem != 0)
            {
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[4].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[4].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[4].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[4].defesaItem;
            }
        }

        private void Slot4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[3].NumItem != 0)
            {
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[3].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[3].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[3].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[3].defesaItem;
            }
        }

        private void Slot3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[2].NumItem!=0)
            {
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[2].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[2].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[2].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[2].defesaItem;

            }
        }

        private void Slot2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[1].NumItem!=0){
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[1].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[1].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[1].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[1].defesaItem;
            }
        }

        private void Slot1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (p[0].personagem.inventario[0].NumItem!=0)
            {
                nome.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(nome, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(nome, Canvas.GetTop(TelaInventario) + 180);
                nome.Text = p[0].personagem.inventario[0].nomeItem;

                VidaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(VidaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(VidaItem, Canvas.GetTop(nome) + 20);
                VidaItem.Text = p[0].personagem.inventario[0].vidaItem;

                AtaqueItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(AtaqueItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(AtaqueItem, Canvas.GetTop(VidaItem) + 20);
                AtaqueItem.Text = p[0].personagem.inventario[0].ataqueItem;

                DefesaItem.Foreground = new SolidColorBrush(Colors.White);
                Canvas.SetLeft(DefesaItem, Canvas.GetLeft(TelaInventario) - 465);
                Canvas.SetTop(DefesaItem, Canvas.GetTop(AtaqueItem) + 20);
                DefesaItem.Text = p[0].personagem.inventario[0].defesaItem;
            }
        }


        private void BotaoFechar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            TelaInventario.Visibility = Visibility.Visible;
            TelaInventario.Visibility = Visibility.Collapsed;
            TelaInventario.Children.Remove(slot1);
            TelaInventario.Children.Remove(slot2);
            TelaInventario.Children.Remove(slot3);
            TelaInventario.Children.Remove(slot4);
            TelaInventario.Children.Remove(slot5);
            TelaInventario.Children.Remove(slot6);
            TelaInventario.Children.Remove(nome);
            TelaInventario.Children.Remove(VidaItem);
            TelaInventario.Children.Remove(AtaqueItem);
            TelaInventario.Children.Remove(DefesaItem);
            nome.Text = " ";
            VidaItem.Text = " ";
            AtaqueItem.Text = " ";
            DefesaItem.Text = " ";
            TelaInventario.Children.Remove(botaoFechar);
            csvsMain.Children.Remove(TelaInventario);
            


        }

        private async void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {

            Texto1.Text = p[0].personagem.Vida.ToString();
            Texto2.Text = p[0].personagem.Ataque.ToString();
            Texto3.Text = p[0].personagem.Defesa.ToString();
            
            person.Background = p[0].personagem.ib;

            if (args.VirtualKey == Windows.System.VirtualKey.B)
            {

                this.Frame.Navigate(typeof(TelaBatalha), p);
            }

            if (args.VirtualKey == Windows.System.VirtualKey.D)
            {
                int t = 0;
                p[0].personagem.pegaritem(matriz, matriz.l, matriz.c + 1);
                if (matriz.Colidir("D", p[0].personagem, matriz) == true)
                {

                    person.Background = p[0].personagem.imagemposicao("D", p[0].personagem.id);
                    while (t != 8)
                    {
                        Canvas.SetLeft(person, Canvas.GetLeft(person) + 4);
                        await Task.Delay(20);
                        t++;
                    }
                    if (matriz.ponto[14,15].caminhar!=2)
                    {
                        Bau.Width = 0;
                        Bau.Height = 0;
                    }
                    if (matriz.ponto[1,39].caminhar!=2)
                    {
                        Bau2.Width = 0;
                        Bau2.Height = 0;
                    }
                    if (matriz.ponto[13,34].caminhar!=2)
                    {
                        Bau3.Width = 0;
                        Bau3.Height = 0;
                    }
                    if (matriz.ponto[20,7].caminhar!=2)
                    {
                        Bau4.Width = 0;
                        Bau4.Height = 0;
                    }

                }
        }

            if (args.VirtualKey == Windows.System.VirtualKey.A)
            {
                p[0].personagem.pegaritem(matriz, matriz.l, matriz.c - 1);
                if (matriz.Colidir("A", p[0].personagem, matriz) == true)
                {
                    int t = 0;
                    person.Background = p[0].personagem.imagemposicao("A", p[0].personagem.id);
                    while (t != 8)
                    {
                        Canvas.SetLeft(person, Canvas.GetLeft(person) - 4);
                        await Task.Delay(20);
                        t++;
                    }
                }
                if (matriz.ponto[14, 15].caminhar != 2)
                {
                    Bau.Width = 0;
                    Bau.Height = 0;
                }
                if (matriz.ponto[1, 39].caminhar != 2)
                {
                    Bau2.Width = 0;
                    Bau2.Height = 0;
                }
                if (matriz.ponto[13, 34].caminhar != 2)
                {
                    Bau3.Width = 0;
                    Bau3.Height = 0;
                }
                if (matriz.ponto[20, 7].caminhar != 2)
                {
                    Bau4.Width = 0;
                    Bau4.Height = 0;
                }


            }

            if (args.VirtualKey == Windows.System.VirtualKey.S)
            {
                p[0].personagem.pegaritem(matriz, matriz.l+1, matriz.c);
                if (matriz.Colidir("S", p[0].personagem, matriz) == true)
                {
                    int t = 0;
                    person.Background = p[0].personagem.imagemposicao("S", p[0].personagem.id);
                    while (t != 8)
                    {
                        Canvas.SetTop(person, Canvas.GetTop(person) + 4);
                        await Task.Delay(20);
                        t++;
                    }

                }
                if (matriz.ponto[14, 15].caminhar != 2)
                {
                    Bau.Width = 0;
                    Bau.Height = 0;
                }
                if (matriz.ponto[1, 39].caminhar != 2)
                {
                    Bau2.Width = 0;
                    Bau2.Height = 0;
                }
                if (matriz.ponto[13, 34].caminhar != 2)
                {
                    Bau3.Width = 0;
                    Bau3.Height = 0;
                }
                if (matriz.ponto[20, 7].caminhar != 2)
                {
                    Bau4.Width = 0;
                    Bau4.Height = 0;
                }

            }
            if (args.VirtualKey == Windows.System.VirtualKey.W)
            {
                p[0].personagem.pegaritem(matriz, matriz.l-1, matriz.c);
                if (matriz.Colidir("W", p[0].personagem, matriz) == true)
                {
                    int t = 0;
                    person.Background = p[0].personagem.imagemposicao("W", p[0].personagem.id);
                    while (t != 8)
                    {
                        Canvas.SetTop(person, Canvas.GetTop(person) - 4);
                        await Task.Delay(20);
                        t++;
                    }
                }
                if (matriz.ponto[14, 15].caminhar != 2)
                {
                    Bau.Width = 0;
                    Bau.Height = 0;
                }
                if (matriz.ponto[1, 39].caminhar != 2)
                {
                    Bau2.Width = 0;
                    Bau2.Height = 0;
                }
                if (matriz.ponto[13, 34].caminhar != 2)
                {
                    Bau3.Width = 0;
                    Bau3.Height = 0;
                }
                if (matriz.ponto[20, 7].caminhar != 2)
                {
                    Bau4.Width = 0;
                    Bau4.Height = 0;
                }
            }

        }

       
    }

    }

