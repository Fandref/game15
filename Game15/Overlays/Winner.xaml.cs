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
using WpfApp1.Classes;
using WpfApp1.Pages;


namespace WpfApp1.Overlays
{
    /// <summary>
    /// Логика взаимодействия для Winner.xaml
    /// </summary>
    public partial class Winner : Page
    {
     
        private Game game;
        public Winner(ResultTimer resultTime, Game Game)
        {
            InitializeComponent();
            game = Game;
            minutes.Text = resultTime.Minutes;
            seconds.Text = resultTime.Seconds;
            miliseconds.Text = resultTime.Miliseconds;
            BestResults bestResults = new BestResults();
            ResultTime bestTime = bestResults.GetResult(game.Size);
            ResultTime currentTime = resultTime.Time;
            if (!bestTime.IsEmpty())
            {
                if (currentTime < bestTime)
                {
                    Cong.Text = "Вітаю, ви встановили рекорд";
                    bestResults.SetResult(game.Size, currentTime);
                    bestResults.SaveResult();
                }
            }
            else
            {
                Cong.Text = "Вітаю, ви встановили рекорд";
                bestResults.SetResult(game.Size, currentTime);
                bestResults.SaveResult();
            }
            
            
        }

        public void NewGame(object sender, RoutedEventArgs e)
        {
            game.CloseOverlay(sender, e);
            game.Restart(sender, e);
        }

        public void OpenSizeMenu(object sender, RoutedEventArgs e)
        {
            game.OpenSizeMenu(sender, e);
        }

    }
}
