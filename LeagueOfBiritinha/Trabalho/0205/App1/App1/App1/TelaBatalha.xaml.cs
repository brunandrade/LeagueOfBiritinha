using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;
using EngineRPG;
using EngineRPG.MapElements;
using Windows.UI.Xaml.Input;
using Windows.UI;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TelaBatalha : Page
    {
        
        MapaBatalha matrizbatalha = new MapaBatalha();
        Player[] p;
        ZeGotinha zegotinha = new ZeGotinha();
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
        Canvas imagemzegotinha = new Canvas();
        Canvas ataque = new Canvas();
        public TelaBatalha()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            csvsMain.Children.Add(imagemzegotinha);
            imagemzegotinha.Width = 92;
            imagemzegotinha.Height = 92;
            Canvas.SetLeft(imagemzegotinha, 892);
            Canvas.SetTop(imagemzegotinha, 352);
            imagemzegotinha.Background = zegotinha.ib;
            Canvas.SetTop(person, Canvas.GetTop(person)+32);
            Canvas.SetLeft(person, 576);
            p = e.Parameter as Player[];
            person.Background = p[0].personagem.ib;
            matrizbatalha.ponto[11, 28] =zegotinha;
            DescPlayer();
            turnos();
            base.OnNavigatedTo(e);
        }
        public void turnos()
        {
            Texto1.Text = p[0].personagem.Vida.ToString();
            Texto2.Text = p[0].personagem.Ataque.ToString();
            Texto3.Text = p[0].personagem.Defesa.ToString();
            VidaText.Text = zegotinha.Vida.ToString();
            AtaqueText.Text = zegotinha.Ataque.ToString();
            DefesaText.Text = zegotinha.Defesa.ToString();
            csvsMain.Children.Add(ataque);
            ataque.Tapped += Ataque_Tapped;
            ataque.Width = 152;
            ataque.Height = 64;
            ImageBrush ataqueimg = new ImageBrush();
            ataqueimg.ImageSource=new BitmapImage(new Uri("ms-appx://App1/Assets/botaoATACAR.png"));
            ataque.Background = ataqueimg;
            Canvas.SetLeft(ataque, Canvas.GetLeft(person)-55);
            Canvas.SetTop(ataque, Canvas.GetTop(person) -80);
        }

        private async void Ataque_Tapped(object sender, TappedRoutedEventArgs e)
        {
            person.Background = p[0].personagem.ib;
            Texto1.Text = p[0].personagem.Vida.ToString();
            Texto2.Text = p[0].personagem.Ataque.ToString();
            Texto3.Text = p[0].personagem.Defesa.ToString();
            VidaText.Text = zegotinha.Vida.ToString();
            AtaqueText.Text = zegotinha.Ataque.ToString();
            DefesaText.Text = zegotinha.Defesa.ToString();
            if (p[0].personagem.Vida>0 && zegotinha.Vida>0)
            {
                p[0].personagem.dirpoder = "Direita";
                person.Background = p[0].personagem.ibdireita;
                csvsMain.Children.Remove(ataque);
                Canvas poder = new Canvas();
                csvsMain.Children.Add(poder);
                poder.Height = 32;
                poder.Width = 32;
                poder.Background = p[0].personagem.skill.Anim(p[0].personagem, zegotinha);
                Canvas.SetLeft(poder, Canvas.GetLeft(person) + 3);
                Canvas.SetTop(poder, Canvas.GetTop(person) + 3);
                while (Canvas.GetLeft(poder) < 928)
                {
                    Canvas.SetLeft(poder, Canvas.GetLeft(poder) + 3);
                    await Task.Delay(5);

                }
                poder.Height = 0;
                poder.Width = 0;
                imagemzegotinha.Opacity = 0;
                await Task.Delay(80);
                imagemzegotinha.Opacity = 100;
                await Task.Delay(80);
                imagemzegotinha.Opacity = 0;
                await Task.Delay(80);
                imagemzegotinha.Opacity = 100;
                ataqueboss();
            }
        }
        public async void Resultado()
        {
            Canvas resultado = new Canvas();
            csvsMain.Children.Add(resultado);

            if (p[0].personagem.Vida <= 0)
            {
                while (Canvas.GetTop(person)>375) {
                    Canvas.SetTop(person, Canvas.GetTop(person) - 3);
                    await Task.Delay(80);
                }
                while (704-Canvas.GetTop(person)>0)
                {
                    Canvas.SetTop(person, Canvas.GetTop(person) + 3);
                    await Task.Delay(2);
                }
                Canvas.SetTop(resultado, -200);
                //Canvas.SetLeft(resultado, 300);
                resultado.Height = 704;
                resultado.Width = 1376;
                ImageBrush gameOverimg = new ImageBrush();
                gameOverimg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/GAMEOVER.png"));
                resultado.Background = gameOverimg;

            }

            else
            {
                ImageBrush zegotinhamorte = new ImageBrush();
                zegotinhamorte.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/6.png"));
                imagemzegotinha.Background = zegotinhamorte;
                await Task.Delay(700);
                resultado.Height = 704;
                resultado.Width = 1376;
                Canvas.SetTop(resultado, -200);
                ImageBrush youWinimg = new ImageBrush();
                youWinimg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/YOUWIN.png"));
                resultado.Background = youWinimg;               

            }

            Canvas tentarnovamente = new Canvas();
            tentarnovamente.Tapped += tentarnovamente_Tapped;
            csvsMain.Children.Add(tentarnovamente);
            ImageBrush tentarnimg = new ImageBrush();
            tentarnimg.ImageSource= new BitmapImage(new Uri("ms-appx://App1/Assets/botaoJOGARNOVAMENTE.png"));
            tentarnovamente.Background = tentarnimg;
            tentarnovamente.Width = 338;
            tentarnovamente.Height = 75;
            Canvas.SetLeft(tentarnovamente, 550);
            Canvas.SetTop(tentarnovamente, 300);
        }
        private void tentarnovamente_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TelaInicial));
        }
        public async void ataqueboss()
        {
            VidaText.Text = zegotinha.Vida.ToString();
            AtaqueText.Text = zegotinha.Ataque.ToString();
            DefesaText.Text = zegotinha.Defesa.ToString();
            if (zegotinha.Vida > 0)
            {
                Canvas poderboss = new Canvas();
                csvsMain.Children.Add(poderboss);
                poderboss.Height = 32;
                poderboss.Width = 32;
                poderboss.Background = zegotinha.skill.Anim(zegotinha, p[0].personagem);
                Canvas.SetLeft(poderboss, Canvas.GetLeft(imagemzegotinha) - 3);
                Canvas.SetTop(poderboss, Canvas.GetTop(imagemzegotinha) + 30);
                while (Canvas.GetLeft(poderboss) > Canvas.GetLeft(person))
                {
                    Canvas.SetLeft(poderboss, Canvas.GetLeft(poderboss) - 3);
                    await Task.Delay(5);
                }

                poderboss.Height = 0;
                poderboss.Width = 0;
                person.Opacity = 0;
                await Task.Delay(80);
                person.Opacity = 100;
                await Task.Delay(80);
                person.Opacity = 0;
                await Task.Delay(80);
                person.Opacity = 100;

            }
            Texto1.Text = p[0].personagem.Vida.ToString();
            Texto2.Text = p[0].personagem.Ataque.ToString();
            Texto3.Text = p[0].personagem.Defesa.ToString();
            csvsMain.Children.Add(ataque);
            if (p[0].personagem.Vida <= 0 || zegotinha.Vida <= 0)
            {
                csvsMain.Children.Remove(ataque);
                ataque.Height = 0;
                ataque.Width = 0;
                this.Resultado();
            }
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

            Canvas life2 = new Canvas();
            life2.Height = 70;
            life2.Width = 70;
            ImageBrush life2Img = new ImageBrush();
            life2Img.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/vidaChefao.png"));
            life2.Background = life2Img;
            Canvas.SetLeft(life2, 1250);
            Canvas.SetTop(life2, 0);
            csvsMain.Children.Add(life2);

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

            //ATAQUE CHEFAO
            Canvas ataquechefao = new Canvas();
            ataquechefao.Height = 60;
            ataquechefao.Width = 60;
            ImageBrush ataquechefaoImg = new ImageBrush();
            ataquechefaoImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/armaChefao.png"));
            ataquechefao.Background = ataquechefaoImg;
            Canvas.SetLeft(ataquechefao, 1250);
            Canvas.SetTop(ataquechefao, 50);
            csvsMain.Children.Add(ataquechefao);


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

            Canvas defesachefao = new Canvas();
            defesachefao.Height = 60;
            defesachefao.Width = 60;
            ImageBrush defesachefaoImg = new ImageBrush();
            defesachefaoImg.ImageSource = new BitmapImage(new Uri("ms-appx://App1/Assets/shieldch.png"));
            defesachefao.Background = defesachefaoImg;
            Canvas.SetLeft(defesachefao, 1250);
            Canvas.SetTop(defesachefao, 100);
            csvsMain.Children.Add(defesachefao);



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
            Canvas.SetLeft(slot1, Canvas.GetLeft(TelaInventario) - 465);
            Canvas.SetTop(slot1, Canvas.GetTop(TelaInventario) - 70);
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
            Canvas.SetLeft(slot5, Canvas.GetLeft(slot4) + 90);
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
            if (p[0].personagem.inventario[2].NumItem != 0)
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
            if (p[0].personagem.inventario[1].NumItem != 0)
            {
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
            if (p[0].personagem.inventario[0].NumItem != 0)
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
            //PODER
            if (args.VirtualKey == Windows.System.VirtualKey.Q)
            {
                if (p[0].personagem.dirpoder == "Direita")
                {

                    Canvas poder = new Canvas();
                    csvsMain.Children.Add(poder);
                    poder.Height = 32;
                    poder.Width = 32;
                    //poder.Background = p[0].personagem.Liberarskill(matrizbatalha, zegotinha);
                    Canvas.SetLeft(poder, Canvas.GetLeft(person) + 3);
                    Canvas.SetTop(poder, Canvas.GetTop(person) + 3);
                    while (Canvas.GetLeft(poder) < 928)
                    {
                        Canvas.SetLeft(poder, Canvas.GetLeft(poder) + 3);
                        await Task.Delay(5);

                    }
                    poder.Height = 0;
                    poder.Width = 0;

                }

                //if (p[0].personagem.dirpoder == "Esquerda")
                //{
                //    Canvas poder = new Canvas();
                //    csvsMain.Children.Add(poder);
                //    poder.Height = 32;
                //    poder.Width = 32;
                //    poder.Background = p[0].personagem.Habilidade();
                //    Canvas.SetLeft(poder, Canvas.GetLeft(person) + 3);
                //    Canvas.SetTop(poder, Canvas.GetTop(person) + 3);

                //    while (Canvas.GetLeft(poder) > 448)
                //    {
                //        Canvas.SetLeft(poder, Canvas.GetLeft(poder) - 3);
                //        await Task.Delay(5);

                //    }
                //    poder.Height = 0;
                //    poder.Width = 0;
                //}
                //if (p[0].personagem.dirpoder == "Cima")
                //{
                //    Canvas poder = new Canvas();
                //    csvsMain.Children.Add(poder);
                //    poder.Height = 32;
                //    poder.Width = 32;
                //    poder.Background = p[0].personagem.Habilidade();
                //    Canvas.SetLeft(poder, Canvas.GetLeft(person) + 3);
                //    Canvas.SetTop(poder, Canvas.GetTop(person) + 3);

                //    while (Canvas.GetTop(poder) > 128)
                //    {
                //        Canvas.SetTop(poder, Canvas.GetTop(poder) - 3);
                //        await Task.Delay(5);

                //    }
                //    poder.Height = 0;
                //    poder.Width = 0;
                //}
                //if (p[0].personagem.dirpoder == "Baixo")
                //{
                //    Canvas poder = new Canvas();
                //    csvsMain.Children.Add(poder);
                //    poder.Height = 32;
                //    poder.Width = 32;
                //    poder.Background = p[0].personagem.Habilidade();
                //    Canvas.SetLeft(poder, Canvas.GetLeft(person) + 3);
                //    Canvas.SetTop(poder, Canvas.GetTop(person) + 3);

                //    while (Canvas.GetTop(poder) < 544)
                //    {
                //        Canvas.SetTop(poder, Canvas.GetTop(poder) + 3);
                //        await Task.Delay(5);

                //    }
                //    poder.Height = 0;
                //    poder.Width = 0;

                //}
            }

            //if (args.VirtualKey == Windows.System.VirtualKey.D)
            //{
            //    int t = 0;
            //    if (matrizbatalha.Colidir("D", p[0].personagem, matrizbatalha) == true)
            //    {

            //        person.Background = p[0].personagem.imagemposicao("D", p[0].personagem.id);
            //        while (t != 8)
            //        {
            //            Canvas.SetLeft(person, Canvas.GetLeft(person) + 4);
            //            await Task.Delay(5);
            //            t++;
            //        }

            //    }

            //}

        //    if (args.VirtualKey == Windows.System.VirtualKey.A)
        //    {

        //        if (matrizbatalha.Colidir("A", p[0].personagem, matrizbatalha) == true)
        //        {
        //            int t = 0;
        //            person.Background = p[0].personagem.imagemposicao("A", p[0].personagem.id);
        //            while (t != 8)
        //            {
        //                Canvas.SetLeft(person, Canvas.GetLeft(person) - 4);
        //                await Task.Delay(20);
        //                t++;
        //            }
        //        }
        //    }

        //    if (args.VirtualKey == Windows.System.VirtualKey.S)
        //    {
        //        if (matrizbatalha.Colidir("S", p[0].personagem, matrizbatalha) == true)
        //        {
        //            int t = 0;
        //            person.Background = p[0].personagem.imagemposicao("S", p[0].personagem.id);
        //            while (t != 8)
        //            {
        //                Canvas.SetTop(person, Canvas.GetTop(person) + 4);
        //                await Task.Delay(20);
        //                t++;
        //            }
        //        }
        //    }
        //    if (args.VirtualKey == Windows.System.VirtualKey.W)
        //    {
        //        if (matrizbatalha.Colidir("W", p[0].personagem, matrizbatalha) == true)
        //        {
        //            int t = 0;
        //            person.Background = p[0].personagem.imagemposicao("W", p[0].personagem.id);
        //            while (t != 8)
        //            {
        //                Canvas.SetTop(person, Canvas.GetTop(person) - 4);
        //                await Task.Delay(20);
        //                t++;
        //            }
        //        }

        //    }
        }
    }
}
