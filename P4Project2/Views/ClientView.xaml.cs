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
        private Context _context;
        public ClientView()
        {
            InitializeComponent();

            MainFrame.Navigate(new Menu(this));
            

        }

        public ClientView(Context a) : this()
        {
            _context = a;
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }
    }
}
