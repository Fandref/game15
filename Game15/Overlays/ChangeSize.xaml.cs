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
using WpfApp1.Pages;
using WpfApp1;


namespace WpfApp1.Overlays
{
    /// <summary>
    /// Логика взаимодействия для ChangeSize.xaml
    /// </summary>
    public partial class ChangeSize : Page
    {
        private Game game;
        public ChangeSize(Game Game)
        {
            
            game = Game;
           
            InitializeComponent();

        }

        private void NewSizeGame(object sender, RoutedEventArgs e)
        {

            string sizeTag = (string)((Button)sender).Tag;
            int size = Int16.Parse(sizeTag);

            Properties.Settings.Default.size = size;
            Properties.Settings.Default.Save();

            game.NewGame(size);
            //game.Restart(sender, e);
            game.CloseOverlay(sender, e);
        }

        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            game.Continue(sender, e);
            game.CloseOverlay(sender, e);
        }

    }
}
