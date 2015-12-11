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
    public class C_Deplacement
    {
        public void ChangerCoordonee(int p_ligne, int p_colonne, int p_rotation)
        {      
            MainWindow.main.l_piece.rotation += p_rotation;
            MainWindow.main.l_piece.lignePiece += p_ligne;
            MainWindow.main.l_piece.colonnePiece += p_colonne;
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
                MainWindow.main.Grille.Children.Add(block);
            }
        }

        public bool DeplacementPiece(int ligne, int colonne, int rotation)
        {
            MainWindow.main.Grille.Children.Clear();
            ChangeCoordonee(ligne, colonne, rotation);
            AfficherPiece(MainWindow.main.l_piece.pieceCourante);

            return true;
        }

        public void ChangeCoordonee(int ligne, int colonne, int rotation)
        {
            MainWindow.main.l_piece.rotation += rotation;
            MainWindow.main.l_piece.lignePiece += ligne;
            MainWindow.main.l_piece.colonnePiece += colonne;
        }

        public void AfficherPiece(TetrisPiece piecePlacer)
        {
            int[] t_ligne = new int[4];
            int[] t_colonne = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int PieceCourante = (int)MainWindow.main.l_piece.pieceCourante;
                int ligneAct = MainWindow.main.l_piece.matricePieces[PieceCourante, MainWindow.main.l_piece.rotation % 4, i, 0];
                int colonneAct = MainWindow.main.l_piece.matricePieces[PieceCourante, MainWindow.main.l_piece.rotation % 4, i, 1];

                int ligne = MainWindow.main.l_piece.lignePiece + ligneAct;
                int colonne = MainWindow.main.l_piece.colonnePiece + colonneAct;

                t_ligne[i] = ligne;
                t_colonne[i] = colonne;
            }

            for (int i = 0; i < 4; i++)
            {
                if (t_colonne[i] == -1)
                {
                    t_colonne[0] += 1;
                    t_colonne[1] += 1;
                    t_colonne[2] += 1;
                    t_colonne[3] += 1;
                }

                if (t_colonne[i] == 21)
                {
                    t_colonne[0] -= 1;
                    t_colonne[1] -= 1;
                    t_colonne[2] -= 1;
                    t_colonne[3] -= 1;
                }

                if (t_ligne[i] == 19)
                {
                    MainWindow.main.l_piece.StartNewPiece();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                MainWindow.main.matriceGrille[t_ligne[i], t_colonne[i]] = piecePlacer;
                AfficherBlockPiece(t_ligne[i], t_colonne[i], piecePlacer);
                MainWindow.main.label.Content = MainWindow.main.matriceGrille;
            }
        }
    }
}
