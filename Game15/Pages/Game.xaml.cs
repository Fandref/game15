using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp1.Classes;


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    

    struct FreePlate
    {
        public int x;
        public int y;

        public FreePlate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Game : Page
    {
        private int size;
        public int Size => size;
        private Button[][] field;
        private FreePlate freePlate;
        private ResultTimer ResultTime;
        private Page SizeMenu;
        private DispatcherTimer updateInerval;
        public bool isPause;
        


        public Game()
        {

            InitializeComponent();

            SizeMenu = new Overlays.ChangeSize(this);


            ResultTime = new ResultTimer();

            ResultTime.Start();

            InitGame(4);

        }




        public void ShowTimer(object sender, EventArgs e)
        {
            miliseconds.Text = ResultTime.Miliseconds;
            seconds.Text = ResultTime.Seconds;
            minutes.Text = ResultTime.Minutes;
        }


        public Game(int size = 4)
        {

            InitializeComponent();

            ResultTime = new ResultTimer();

            SizeMenu = new Overlays.ChangeSize(this);
            StartBtn.Visibility = Visibility.Visible;
            PauseBtn.Visibility = Visibility.Hidden;
            RestartBtn.IsEnabled = false;
            InitGame(size);
            isPause = true;

        }


        public void NewGame(int size = 4)
        {
            
            ClearField();
            GameField.Children.Clear();
            ResultTime.Reset();
            
            StartBtn.Visibility = Visibility.Visible;
            PauseBtn.Visibility = Visibility.Hidden;
            ContinueBtn.Visibility = Visibility.Hidden;
            RestartBtn.IsEnabled = false;
            InitGame(size);
            isPause = true;
        }
        
        public void Start(object sender, RoutedEventArgs e)
        {
            
            ResultTime.Start();
            GameContainerField.IsEnabled = true;
            StartBtn.Visibility = Visibility.Hidden;
            PauseBtn.Visibility = Visibility.Visible;
            PauseBtn.IsEnabled = true;
            RestartBtn.IsEnabled = true;
            isPause = false;

        }
        private void SetUpdateInterval(){
            updateInerval = new DispatcherTimer();
            updateInerval.Tick += new EventHandler(ShowTimer);
            updateInerval.Interval = new TimeSpan(0, 0, 0, 0, 1);
            updateInerval.Start();
        }
        
        public void MovingPlate(object sender, RoutedEventArgs e)
        {
            Button plate = (Button)e.OriginalSource;

            int x = Grid.GetColumn(plate);
            int y = Grid.GetRow(plate);


            bool diagonal = (Math.Abs(x - freePlate.x) == 1 && Math.Abs(y - freePlate.y) == 1);
            if (Math.Abs(x - freePlate.x) <= 1 && Math.Abs(y - freePlate.y) <= 1 && !diagonal)
            {

                Grid.SetColumn(plate, freePlate.x);
                Grid.SetRow(plate, freePlate.y);

                field[y][x] = null;
                field[freePlate.y][freePlate.x] = plate;
                freePlate.x = x;
                freePlate.y = y;


            }

            if (CheckEnd())
            {
                EndGame();
            }



        }


        private Button[] InitPlate(int size)
        {
            int countPlates = size * size - 1;
            Button[] plates = new Button[countPlates];


            for (int i = 0; i < countPlates; i++)
            {
                plates[i] = new Button();
                Button plate = plates[i];
                plate.Content = i + 1;
                plate.Style = (Style)Resources["Plate"];
                plate.AddHandler(Button.ClickEvent, new RoutedEventHandler(MovingPlate));
            }

            return plates;
        }


        private void InitGame(int size)
        {
            SetUpdateInterval();

            field = new Button[size][];
            for (int i = 0; i < size; i++)
            {
                field[i] = new Button[size];
            }
            this.size = size;

            Button[] plates = InitPlate(size);
            GridDefenition();
            PainField(size, plates);
            
            ShowBestTime();



        }
        private void ShowBestTime()
        {
            BestResults best = new BestResults();

            ResultTime bestTime = best.GetResult(size);
            string mainTime = "";
            string miliseconds = "";
            if (bestTime.IsEmpty())
            {
                mainTime = "--:--";
                miliseconds = "---";
            }
            else
            {
                
                if(bestTime.Minutes < 10)
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
            MainBestTime.Text = mainTime;
            BestMilisecond.Text = miliseconds;
        }

        private void GridDefenition() {
            for (int i = 0; i < size; i++)
            {
                RowDefinition row = new RowDefinition();
                GameField.RowDefinitions.Add(row);
           
                ColumnDefinition column = new ColumnDefinition();
                GameField.ColumnDefinitions.Add(column);
            }

        }
        private bool Solvability()
        {
            int sum = 0;
            int e = size;

            Button[] plates = field.SelectMany(item => item).Distinct().Where(item => item != null).ToArray();

            for (int i = 0; i < size*size-1; i++)
            {
                int select = (int)plates[i].Content;
                for (int j = i + 1; j < size * size-1; j++)
                {
                    int current = (int)plates[j].Content;
                    if (select > current)
                        sum++;
                     
                        
                }
            }



            sum += e;
            
            if (size % 2 == 0)
                return sum % 2 == 0;
            else
                return sum % 2 != 0;



        }

        private void PainField(int size, Button[] plates)
        {

            int lastCoord = size - 1;
            freePlate = new FreePlate(lastCoord, lastCoord);
            Button[] buttonPlates = plates;
            
            for (int i = 0; i < size; i++)
            {


                for (int j = 0; j < size; j++)
                {
                    int currentLength = plates.Length;
                    if (currentLength > 0)
                    {
                        var rand = new Random();
                        Button plate;

                        while (true)
                        {
                            int index = rand.Next(0, currentLength - 1);
                            plate = plates[index];
                            if (plate != null)
                            {
                                Grid.SetRow(plate, i);
                                Grid.SetColumn(plate, j);
                                GameField.Children.Add(plate);
                                field[i][j] = plate;
                                plates = plates.Where((val, idx) => idx != index).ToArray();
                                break;
                            }
                        }
                    }
                }
            }
            if (!Solvability())
            {
                Button temp = field[0][0];
                field[0][0] = field[0][1];
                field[0][1] = temp;

                Grid.SetRow(field[0][0], 0);
                Grid.SetColumn(field[0][0], 0);
                Grid.SetRow(field[0][1], 0);
                Grid.SetColumn(field[0][1], 1);


            }
            


        }

        public void Restart(object sender, RoutedEventArgs e)
        {
            ResultTime.Stop();
            ResultTime.Reset();
            ResultTime.Continue();
            GameContainerField.IsEnabled = true;
            PauseBtn.Visibility = Visibility.Visible;
            PauseBtn.IsEnabled = true;
            ContinueBtn.Visibility = Visibility.Hidden;
            Button[] plates = field.SelectMany(item => item).Distinct().Where(item => item != null).ToArray();
            GameField.Children.Clear();
            PainField(size, plates);
            isPause = false;
            ShowBestTime();

        }

        public void Pause(object sender, RoutedEventArgs e)
        {
         

            PauseBtn.Visibility = Visibility.Hidden;
            ContinueBtn.Visibility = Visibility.Visible;
            GameContainerField.IsEnabled = false;
            isPause = true;
            ResultTime.Stop();
            
        }


        public void Continue(object sender, RoutedEventArgs e)
        {

            ContinueBtn.Visibility = Visibility.Hidden;
            PauseBtn.Visibility = Visibility.Visible;
            GameContainerField.IsEnabled = true;
            isPause = false;
            ResultTime.Start();
        }


        private bool CheckEnd()
        {
        
            for (int i = 0; i < size; i++)
            {
                int startRow = size * i;
                for (int j = 0; j < size; j++)
                {
                    if (field[i][j] != null)
                    {
                        int plateNumber = (int)field[i][j].Content;

                        if (startRow + j + 1 != plateNumber)
                        {
                            return false;
                        }
                        
                        
                 
                        
                    }
                   


                }

            }
            

            return true;
        }


        private void EndGame()
        {
            ResultTime.Stop();
            GameContainerField.IsEnabled = false;
            PauseBtn.IsEnabled = false;
            Page EndMessage = new Overlays.Winner(ResultTime, this);
            isPause = true;
            OpenOverlay(EndMessage);
        }


        private void ClearField()
        {
            GameField.RowDefinitions.Clear();
            GameField.ColumnDefinitions.Clear();

        }


        public void OpenSizeMenu(object sender, RoutedEventArgs e)
        {
            if(!isPause)
                Pause(sender, e);
            OpenOverlay(SizeMenu);
        }
        public void OpenResults(object sender, RoutedEventArgs e)
        {
            if (!isPause)
                Pause(sender, e);
            Page ResultsPage = new Overlays.ResultList(this);
            OpenOverlay(ResultsPage);
        }

        public void OpenOverlay(Page Content)
        {
            OverlayContainer.Visibility = Visibility.Visible;
            Overlay.Content = Content;
        }
        public void CloseOverlay(object sender, RoutedEventArgs e)
        {
            OverlayContainer.Visibility = Visibility.Hidden;
            
        }
    }
}
