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
using GameUI;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TelaInicial : Page
    {
        public TelaInicial()
        {
            this.InitializeComponent();
        }

        private void botaoJogar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayerSelect));
        }

        private void botaoSair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botaoConf_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }
    }
}
