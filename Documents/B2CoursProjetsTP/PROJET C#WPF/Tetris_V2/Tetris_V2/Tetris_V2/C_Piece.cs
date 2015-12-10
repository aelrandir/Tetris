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
    public class C_Piece : MainWindow
    {
        private int l_rotation;
        private int l_lignePiece;
        private int l_colonnePiece;
        private bool premierePiece = true;
        private TetrisPiece l_prochainePiece;
        private TetrisPiece l_pieceCourante;

        public int rotation
        {
            get { return l_rotation; }
            set { l_rotation = value; }
        }

        public int lignePiece
        {
            get { return l_lignePiece; }
            set { l_lignePiece = value; }
        }

        public int colonnePiece
        {
            get { return l_colonnePiece; }
            set { l_colonnePiece = value; }
        }

        public TetrisPiece prochainePiece
        {
            get { return l_prochainePiece; }
        }

        public TetrisPiece pieceCourante
        {
            get { return l_pieceCourante; }
        }

        public int[,,,] matricePieces
        {
            get { return l_matricePieces; }
        }

        private static int[,,,] l_matricePieces =
           {
                    {	// Le carre
       	                {
                           {0,0}, {0,1},
                           {1,0}, {1,1}
                       },
                       {
                           {0,0}, {0,1},
                           {1,0}, {1,1}
                       },
                       {
                           {0,0}, {0,1},
                           {1,0}, {1,1}
                       },
                       {
                           {0,0}, {0,1},
                           {1,0}, {1,1}
                       }
                    },

                    {	// La ligne
    	                {
                            {0,0},{0,1},{0,2},{0,3}
                        },
                        {
                            {0,0},
                            {1,0},
                            {2,0},
                            {3,0}
                        },
                        {
                            {0,0},{0,1},{0,2},{0,3}
                        },
                        {
                            {0,0},
                            {1,0},
                            {2,0},
                            {3,0}
                        }
                    },

                    {	// Le triangle
    	                {
                                   {0,1},
                            {1,0}, {1,1}, {1,2}
                        },
                        {
                                {0,0},
                                {1,0}, {1,1},
                                {2,0}
                        },
                        {
                            {0,0}, {0,1}, {0,2},
                                    {1,1},
                        },
                        {
                                    {0,1},
                            {1,0}, {1,1},
                                    {2,1}
                        }
                    },

                    {	// Le zigzag 1
    	                {
                            {0,0}, {0,1},
                                    {1,1}, {1,2}
                        },
                        {
                                   {0,1},
                            {1,0}, {1,1} ,
                            {2,0}
                        },
                        {
                            {0,0}, {0,1},
                                    {1,1}, {1,2}
                        },
                        {
                                   {0,1},
                            {1,0}, {1,1} ,
                            {2,0}
                        }
                    },

                    {	// Le zigzag 2
    	                {
                                    {0,1}, {0,2},
                            {1,0}, {1,1}
                        },
                        {
                            {0,0},
                            {1,0}, {1,1},
                                    {2,1}
                        },
                        {
                                    {0,1}, {0,2},
                            {1,0}, {1,1}
                        },
                        {
                            {0,0},
                            {1,0}, {1,1},
                                   {2,1}
                        }
                    },

                    {	// Le L 1
    	                {
                            {0,0}, {0,1},{0,2},
                            {1,0}
                        },
                        {
                                {0,0}, {0,1},
                                       {1,1},
                                       {2,1}
                        },
                        {
                                         {0,2},
                            {1,0}, {1,1},{1,2},
                        },
                        {
                            {0,0},
                            {1,0},
                            {2,0}, {2,1}
                        }
                    },

                    {	// Le L 2
    	                {
                            {0,0}, {0,1}, {0,2},
                                          {1,2}
                        },
                        {
                                  {0,1},
                                  {1,1},
                           {2,0}, {2,1}

                        },
                        {
                            {0,0},
                            {1,0}, {1,1}, {1,2},
                        },
                        {
                            {0,0},{0,1},
                            {1,0},
                            {2,0}
                        }
                    }
                };

        public TetrisPiece PieceAuHasard()
        {
            Random random = new Random();
            int maxVal = (int)TetrisPiece.Tetris_Vide;
            int valeur = random.Next(maxVal);
            return (TetrisPiece)valeur;
        }

        public void ChoisirPiece()
        {
            if (premierePiece == true)
            {
                l_pieceCourante = PieceAuHasard();
                premierePiece = false;
            }

            else
            {
                l_pieceCourante = prochainePiece;
            }

            l_prochainePiece = PieceAuHasard();
        }
    }
}
