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
using System.Windows.Threading;


namespace Tetris_V2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public C_Piece l_piece = new C_Piece();
        public C_Deplacement l_deplacement = new C_Deplacement();
        public static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
            timer.Start();

            main = this;
            l_piece.ChoisirPiece();
            l_deplacement.AfficherPiece(l_piece.PieceAuHasard());
        }

        void timer_Tick(object sender, EventArgs e)
        {
            l_deplacement.DeplacementPiece(1, 0, 0);
        }


        private TetrisPiece[,] l_matriceGrille = new TetrisPiece[20, 10];

        public TetrisPiece[,] matriceGrille
        {
            get { return l_matriceGrille; }
            set { l_matriceGrille = value; }
        }

        public void Deplacement (object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Up))
            {
                l_deplacement.DeplacementPiece(0, 0, 1);
            }

            else if (e.Key.Equals(Key.Down))
            {
                l_deplacement.DeplacementPiece(1, 0, 0);
            }

            else if (e.Key.Equals(Key.Left))
            {
                l_deplacement.DeplacementPiece(0, -1, 0);
            }

            else if (e.Key.Equals(Key.Right))
            {
                l_deplacement.DeplacementPiece(0, 1, 0);
            }
        }
    }
}
