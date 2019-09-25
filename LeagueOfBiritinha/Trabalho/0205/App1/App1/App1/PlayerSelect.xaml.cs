using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EngineRPG;
using EngineRPG.MapElements;
using App1;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GameUI{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerSelect : Page {
        Player[] p = new Player[2];
       
        public PlayerSelect() {
            p[0] = new Player();
            p[1] = new Player();
            this.InitializeComponent();
        }

        private void WarriorButton_Click(object sender, RoutedEventArgs e) {
            p[0].personagem = new GuerreiroP();
            this.Frame.Navigate(typeof(MainPage), p);
        }

        private void AcherButton_Click(object sender, RoutedEventArgs e) {
            p[0].personagem = new ArqueiraP();
            this.Frame.Navigate(typeof(MainPage), p);

        }

        private void WizardButton_Click(object sender, RoutedEventArgs e) {
            p[0].personagem = new FeiticeiraP();
            this.Frame.Navigate(typeof(MainPage), p);

        }

        private void ThiefButton_Click(object sender, RoutedEventArgs e) {
            p[0].personagem = new LadraoP();
            this.Frame.Navigate(typeof(MainPage), p);

        }
    }
}
