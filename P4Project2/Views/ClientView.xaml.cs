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
using System.Windows.Shapes;
using P4Project2.DBContext;
using P4Project2.Models;

namespace P4Project2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ClientView.xaml
    /// </summary>
    public partial class ClientView : Window
    {
        public ClientView()
        {
            InitializeComponent();

            MainFrame.Navigate(new Menu(this));

            Context context = new Context();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();

            //Gladiator gladiator = new Gladiator();
            //gladiator =
            //context.Gladiators.Where(g => g.Name == "Kajetan").FirstOrDefault();

            //MessageBox.Show($"Name: {gladiator.Name}, HP: {gladiator.Health}, Mana: {gladiator.Mana}, Coins: {gladiator.Purse}");
        }
    }
}
