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

namespace Tetris_V2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            C_Piece l_piece = new C_Piece();
            C_Deplacement l_deplacement = new C_Deplacement();

            l_piece.ChoisirPiece();
            l_deplacement.AfficherPiece(l_piece.PieceAuHasard());
        }

        private TetrisPiece[,] l_matriceGrille = new TetrisPiece[20, 10];

        public TetrisPiece[,] matriceGrille
        {
            get { return l_matriceGrille; }
            set { l_matriceGrille = value; }
        }

        public void Deplacement (object sender, KeyEventArgs e)
        {
            C_Deplacement deplacement = new C_Deplacement();

            if (e.Key.Equals(Key.Up))
            {
                deplacement.DeplacementPiece(0, 0, 1);
            }

            else if (e.Key.Equals(Key.Down))
            {
                deplacement.DeplacementPiece(1, 0, 0);
            }

            else if (e.Key.Equals(Key.Left))
            {
                deplacement.DeplacementPiece(0, -1, 0);
            }

            else if (e.Key.Equals(Key.Right))
            {
                deplacement.DeplacementPiece(0, 1, 0);
            }
        }
    }
}
