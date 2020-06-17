using Microsoft.EntityFrameworkCore;
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
        Gladiator enemy;
        public DrawEnemyView(Gladiator _player)
        {
            InitializeComponent();
            player = _player;
            Func();
        }

        Random rnd = new Random();
        Context ctx = new Context();
        List<Gladiator> _tempGladiators = new List<Gladiator>();

        public void Func()
        {
            var a = ctx.Gladiators.Include(x => x.CurrentWeapon).Include(x => x.CurrentLevel).Include(x => x.PrimaryClass);
            _tempGladiators = a.Where(x => x.LevelID_FK <= (player.LevelID_FK + 1) && x.LevelID_FK >= (player.LevelID_FK - 1) && x.ID != player.ID).ToList();
            //List<Gladiator> a = drawnEnemies.OrderBy(x => rnd.Next()).Take(3).ToList();
            Style style = this.TryFindResource("menu_Button") as Style;

            foreach (var gladiator in _tempGladiators)
            {
                Border border = new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.White),
                    BorderThickness = new Thickness(1, 3, 1, 3),
                    Margin = new Thickness(25)
                };

                Button btn = new Button
                {
                    Name = $"_{gladiator.ID}",
                    Style = style,
                    Content = $"{gladiator.Name}, Lvl {gladiator.LevelID_FK}\n" +
                        $"{gladiator.CurrentWeapon.Name}({gladiator.CurrentWeapon.Damage}dmg/{gladiator.CurrentWeapon.Accuracy}acc)" +
                        $"\n{gladiator.Health}HP/{gladiator.Mana}Mana",
                };
                btn.Click += Btn_Click;
                border.Child = btn;
                chooseFrom.Children.Add(border);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button);
            var b = Convert.ToInt32(a.Name.Replace("_",""));

            enemy = _tempGladiators.Where(x => x.ID == b).FirstOrDefault();
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new FightView(player,enemy));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //window.MainFrame.Navigate(new DrawEnemyView(player));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = (ClientView)Application.Current.MainWindow;
            window.MainFrame.Navigate(new CharacterSelection_View());
        }
    }
}
