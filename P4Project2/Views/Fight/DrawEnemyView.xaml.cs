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

namespace P4Project2.Views.Fight
{
    /// <summary>
    /// Logika interakcji dla klasy DrawEnemyView.xaml
    /// </summary>
    public partial class DrawEnemyView : Page
    {
        Gladiator player;
        public DrawEnemyView(Gladiator _player)
        {
            InitializeComponent();
            player = _player;
            Func();
        }

        Random rnd = new Random();
        Context ctx = new Context();

        public void Func()
        {
            var rnder = rnd.Next();
            var drawnEnemies = ctx.Gladiators.Where(x => x.LevelID_FK <= (player.LevelID_FK + 1) && x.LevelID_FK >= (player.LevelID_FK - 1));
            //List<Gladiator> a = drawnEnemies.OrderBy(x => rnd.Next()).Take(3).ToList();
            foreach (var item in a)
            {
                MessageBox.Show(item.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new Fight.DrawEnemyView(player));
        }
    }
}
