using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P4Project2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();

        }

        readonly ClientView clientView;

        public Menu(ClientView clientView)
        {
            InitializeComponent();
            this.clientView = clientView;
        }

        private void Switch_To_CharacterCreationView(object sender, RoutedEventArgs e)
        {
            if (clientView.MainFrame != null)
                clientView.MainFrame.Navigate(new CharacterCreation_View());
        }

        private void CloseClient(object sender, RoutedEventArgs e)
        {
            clientView.Close();
        }

        private void Switch_To_CharacterSelectionView(object sender, RoutedEventArgs e)
        {
            if (clientView.MainFrame != null)
                clientView.MainFrame.Navigate(new CharacterSelection_View());
        }
    }
}
