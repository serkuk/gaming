using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ByteBee.BattleShip.Engine;

namespace ByteBee.BattleShip
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ComputerBoard _computerBoard;
        private int _currentRound;

        public ComputerBoard ComputerBoard
        {
            get => _computerBoard;
            set
            {
                _computerBoard = value;
                OnPropertyChanged(nameof(ComputerBoard));
            }
        }

        public string[] Numbers { get; } = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public string[] Letters { get; } = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        public int CurrentRound
        {
            get => _currentRound;
            set
            {
                _currentRound = value;
                OnPropertyChanged(nameof(CurrentRound));
            }
        }

        public MainWindow()
        {
            InitializeComponent();



            ComputerBoard = new ComputerBoard();
            ComputerBoard.Generate();

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ComputerFieldClicked(object sender, MouseButtonEventArgs e)
        {
            Field field = (Field) ((Panel) sender).DataContext;

            CurrentRound++;
        }
    }
}
