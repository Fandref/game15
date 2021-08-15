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
    /// Логика взаимодействия для ResultList.xaml
    /// </summary>
    public partial class ResultList : Page
    {

       private Game game;

        public ResultList(Game Game)
        {
            InitializeComponent();
            game = Game;
            BestResults bestResults = new BestResults();
            List<ResultItem> results = bestResults.GetResultList();
            int indexColumn = 0;
            foreach (ResultItem result in results)
            {
                ResultTime bestTime = result.result;
                StackPanel time = new StackPanel();

                time.Orientation = Orientation.Horizontal;
                time.HorizontalAlignment = HorizontalAlignment.Center;
                time.Margin = new Thickness(20, 30, 0, 0);
                string mainTime = "";
                string miliseconds = "";

                if (bestTime.IsEmpty())
                {
                    mainTime = "--:--";
                    miliseconds = "---";
                }
                else
                {

                    if (bestTime.Minutes < 10)
                    {
                        mainTime += $"0{bestTime.Minutes}";
                    }
                    else
                    {
                        mainTime += $"{bestTime.Minutes}";
                    }

                    mainTime += ":";

                    if (bestTime.Seconds < 10)
                    {
                        mainTime += $"0{bestTime.Seconds}";
                    }
                    else
                    {
                        mainTime += $"{bestTime.Seconds}";
                    }
                    if (bestTime.Miliseconds < 10)
                    {
                        miliseconds += $"00{bestTime.Miliseconds}";
                    }
                    else if (bestTime.Miliseconds < 100)
                    {
                        miliseconds += $"0{bestTime.Miliseconds}";
                    }
                    else
                    {
                        miliseconds += $"{bestTime.Miliseconds}";
                    }

                }

                TextBlock mainTimeElement = new TextBlock();
                mainTimeElement.Text = mainTime;
                mainTimeElement.FontSize = 25;
                mainTimeElement.VerticalAlignment = VerticalAlignment.Bottom;

                TextBlock milisecondsElement = new TextBlock();
                milisecondsElement.Text = miliseconds;

                milisecondsElement.VerticalAlignment = VerticalAlignment.Bottom;
                milisecondsElement.Margin = new Thickness(0, 0, 0, 3);
                TextBlock point = new TextBlock();
                point.Text = ".";
                point.VerticalAlignment = VerticalAlignment.Bottom;
                point.Margin = new Thickness(0, 0, 0, 3);



                time.Children.Add(mainTimeElement);
                time.Children.Add(point);
                time.Children.Add(milisecondsElement);

                Grid.SetRow(time, 1);
                Grid.SetColumn(time, indexColumn++);

                ResultGrid.Children.Add(time);

            }
        }

        public void CloseMenu(object sender, RoutedEventArgs e)
        {
            game.CloseOverlay(sender, e);
        }
    }
}
