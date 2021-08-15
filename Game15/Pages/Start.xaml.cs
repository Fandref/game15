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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        private Frame _parent;
        public Start(Frame parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        public void SelectSize(object sender, RoutedEventArgs e)
        {
            string sizeTag = (string)((Button)sender).Tag;
            int size = Int16.Parse(sizeTag);

            Properties.Settings.Default.size = size;
            Properties.Settings.Default.Save();

            _parent.Content = new Game(size);
        }
    }
}
