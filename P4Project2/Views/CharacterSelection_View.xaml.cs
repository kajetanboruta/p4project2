using P4Project2.DBContext;
using P4Project2.Models;
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
    /// Logika interakcji dla klasy CharacterSelection_View.xaml
    /// </summary>
    public partial class CharacterSelection_View : Page
    {
        public CharacterSelection_View()
        {
            InitializeComponent();

            Gladiator _g = new Gladiator();
            Context _ctx = new Context();
            
            _g._Gladiators = _ctx.Gladiators.ToList();
            DG_Gladiators.ItemsSource = _g._Gladiators;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new Menu(window));
        }
    }
}
