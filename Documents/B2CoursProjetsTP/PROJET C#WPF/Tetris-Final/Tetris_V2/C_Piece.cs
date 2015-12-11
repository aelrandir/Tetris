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
    public class C_Piece
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


        //public void AfficherProchainePiece()
        //{
        //    if(prochainePiece == TetrisPiece.Carre_Rose)
        //    {
        //        Uri uri = new Uri("Image/Carre_Rose.png");
        //        MainWindow.main.NxtPic.Source = uri;
        //    }
        //}

        public void GetImage()
        {
            if (l_prochainePiece == TetrisPiece.Carre_Rose)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Carre_Rose.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.Ligne_Rouge)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/Ligne_Rouge.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.Triangle_Cyan)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/Triangle_Cyan.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.Zigzag1_Orange)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/Zigzag1_Orange.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.Zigzag2_Vert)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/Zigzag2_Vert.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.L1_Jaune)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/L1_Jaune.PNG", UriKind.Relative));
            }

            if (l_prochainePiece == TetrisPiece.L2_Bleu)
            {
                MainWindow.main.NxtPic.Source = new BitmapImage(new Uri("Image/L2_Bleu.PNG", UriKind.Relative));
            }
        }

        private static int[,,,] l_matricePieces =
           {
                    {	// Le carre
       	                {
                           {0,4}, {0,5},
                           {1,4}, {1,5}
                       },
                       {
                           {0,4}, {0,5},
                           {1,4}, {1,5}
                       },
                       {
                           {0,4}, {0,5},
                           {1,4}, {1,5}
                       },
                       {
                           {0,4}, {0,5},
                           {1,4}, {1,5}
                       }
                    },

                    {	// La ligne
    	                {
                            {0,4},{0,5},{0,6},{0,7}
                        },
                        {
                            {0,4},
                            {1,4},
                            {2,4},
                            {3,4}
                        },
                        {
                            {0,4},{0,5},{0,6},{0,7}
                        },
                        {
                            {0,4},
                            {1,4},
                            {2,4},
                            {3,4}
                        }
                    },

                    {	// Le triangle
    	                {
                                   {0,5},
                            {1,4}, {1,5}, {1,6}
                        },
                        {
                                {0,5},
                                {1,5}, {1,6},
                                {2,5}
                        },
                        {
                            {0,4}, {0,5}, {0,6},
                                    {1,5},
                        },
                        {
                                    {0,5},
                            {1,4}, {1,5},
                                    {2,5}
                        }
                    },

                    {	// Le zigzag 1
    	                {
                            {0,4}, {0,5},
                                    {1,5}, {1,6}
                        },
                        {
                                   {0,5},
                            {1,4}, {1,5} ,
                            {2,4}
                        },
                        {
                            {0,4}, {0,5},
                                    {1,5}, {1,6}
                        },
                        {
                                   {0,5},
                            {1,4}, {1,5} ,
                            {2,4}
                        }
                    },

                    {	// Le zigzag 2
    	                {
                                    {0,5}, {0,6},
                            {1,4}, {1,5}
                        },
                        {
                            {0,4},
                            {1,4}, {1,5},
                                    {2,5}
                        },
                        {
                                    {0,5}, {0,6},
                            {1,4}, {1,5}
                        },
                        {
                            {0,5},
                            {1,5}, {1,6},
                                   {2,6}
                        }
                    },

                    {	// Le L 1
    	                {
                            {0,4}, {0,5},{0,6},
                            {1,4}
                        },
                        {
                                {0,4}, {0,5},
                                       {1,5},
                                       {2,5}
                        },
                        {
                                         {0,6},
                            {1,4}, {1,5},{1,6},
                        },
                        {
                            {0,4},
                            {1,4},
                            {2,4}, {2,5}
                        }
                    },

                    {	// Le L 2
    	                {
                            {0,4}, {0,5}, {0,6},
                                          {1,6}
                        },
                        {
                                  {0,5},
                                  {1,5},
                           {2,4}, {2,5}

                        },
                        {
                            {0,4},
                            {1,4}, {1,5}, {1,6},
                        },
                        {
                            {0,4},{0,5},
                            {1,4},
                            {2,4}
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

        public void StartNewPiece()
        {
            ChoisirPiece();
            lignePiece = -1;
            colonnePiece = 0;
            rotation = 0;
        }
    }
}
