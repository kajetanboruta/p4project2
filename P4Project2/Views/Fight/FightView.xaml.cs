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

        public FightView(Gladiator Player, Gladiator Enemy)
        {
            InitializeComponent();
            //fight.Enemy = ctx.Gladiators.Where(x => x.Name == "Sorka").FirstOrDefault();
            fight.Player = Player;
            fight.Enemy = Enemy;
            LoadGladiators();

        }

        private void LoadGladiators()
        {
            DBContext.Context ctx = new DBContext.Context();


            enemy_Name.Content = $"{fight.Enemy.Name} ({fight.Enemy.PrimaryClass.Name})";
            enemy_Hp.Text = fight.Enemy.Health.ToString();
            enemy_Mp.Text = fight.Enemy.Mana.ToString();
            player_Name.Content = $"{fight.Player.Name} ({fight.Player.PrimaryClass.Name})";
            player_Hp.Text = fight.Player.Health.ToString();
            player_Mp.Text = fight.Player.Mana.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fight.Attack(fight.Player, fight.Enemy);

            foreach (var log in fight.Logs.FightLog)
            {
                logger.Items.Add(log);
            }
            fight.Logs.FightLog.Clear();

            LoadGladiators();
        }
    }
}
