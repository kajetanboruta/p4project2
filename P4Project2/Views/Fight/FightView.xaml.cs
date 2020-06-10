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
    /// Logika interakcji dla klasy FightView.xaml
    /// </summary>
    public partial class FightView : Page
    {
        public FightView()
        {
            InitializeComponent();
        }

        FightModel fight = new FightModel();
        Logger _logger = new Logger();

        public FightView(Gladiator player/*, Gladiator Enemy*/)
        {
            InitializeComponent();
            DBContext.Context ctx = new DBContext.Context();
            fight.Enemy = ctx.Gladiators.Where(x => x.Name == "Sorka").FirstOrDefault();
            fight.Player = player;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fight.Attack(fight.Player, fight.Enemy);

            foreach (var log in fight.Logs.FightLog)
            {
                logger.Items.Add(log);
            }
            fight.Logs.FightLog.Clear();
        }
    }
}
