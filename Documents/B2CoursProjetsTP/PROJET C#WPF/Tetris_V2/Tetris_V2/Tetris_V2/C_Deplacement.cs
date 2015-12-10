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
    public class C_Deplacement : MainWindow
    {
        C_Piece piece = new C_Piece();

        public void ChangerCoordonee(int p_ligne, int p_colonne, int p_rotation)
        {
            piece.rotation += p_rotation;
            piece.lignePiece += p_ligne;
            piece.colonnePiece += p_colonne;
        }

        public void AfficherBlockPiece(int ligne, int colonne, TetrisPiece Couleur)
        {
            if (Couleur != TetrisPiece.Tetris_Vide)
            {
                Rectangle block = new Rectangle();

                if (Couleur == TetrisPiece.Carre_Rose)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
                }

                if (Couleur == TetrisPiece.Ligne_Rouge)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Red);
                }

                if (Couleur == TetrisPiece.Triangle_Cyan)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
                }

                if (Couleur == TetrisPiece.Zigzag1_Orange)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Cyan);
                }

                if (Couleur == TetrisPiece.Zigzag2_Vert)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);
                }

                if (Couleur == TetrisPiece.L1_Jaune)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Pink);
                }

                if (Couleur == TetrisPiece.L2_Bleu)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
                }

                block.SetValue(Grid.ColumnProperty, colonne);
                block.SetValue(Grid.RowProperty, ligne);
                Grille.Children.Add(block);
            }
        }

        public bool DeplacementPiece(int ligne, int colonne, int rotation)
        {
            Grille.Children.Clear();
            ChangeCoordonee(ligne, colonne, rotation);
            AfficherPiece(piece.pieceCourante);

            return true;
        }

        public void ChangeCoordonee(int ligne, int colonne, int rotation)
        {
            piece.rotation += rotation;
            piece.lignePiece += ligne;
            piece.colonnePiece += colonne;
        }

        

        public void AfficherPiece(TetrisPiece piecePlacer)
        {
            for (int block = 0; block < 4; block++)
            {
                int PieceCourante = (int)piece.pieceCourante;
                int ligneAct = piece.matricePieces[PieceCourante, piece.rotation % 4, block, 0];
                int colonneAct = piece.matricePieces[PieceCourante, piece.rotation % 4, block, 1];

                int ligne = piece.lignePiece + ligneAct;
                int colonne = piece.colonnePiece + colonneAct;

                if (ligne >= 0 && ligne < 20 && colonne >= 0 && colonne < 10)
                {
                    matriceGrille[ligne, colonne] = piecePlacer;
                    AfficherBlockPiece(ligne, colonne, piecePlacer);
                }
            }
        }
    }
}
