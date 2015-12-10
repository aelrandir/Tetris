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
using System.Drawing;
using System.Windows.Threading;
using System.Timers;

namespace Tetris
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ChoisirPiece();
            AfficherPiece(PieceAuHasard());
        }

        public void AfficherBlockPiece(int ligne, int colonne, TetrisValeur Couleur)
        {
            if (Couleur != TetrisValeur.TETRIS_RIEN)
            {
                Rectangle block = new Rectangle();

                if (Couleur == TetrisValeur.CARRE_BLEU)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
                }

                if (Couleur == TetrisValeur.LIGNE_ROUGE)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Red);
                }

                if (Couleur == TetrisValeur.TRIANGLE_VERT)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green);
                }

                if (Couleur == TetrisValeur.ZIG1_CYAN)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Cyan);
                }

                if (Couleur == TetrisValeur.ZIG2_GRIS)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray);
                }

                if (Couleur == TetrisValeur.L1_ROSE)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Pink);
                }

                if (Couleur == TetrisValeur.L2_JAUNE)
                {
                    block.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
                }

                block.SetValue(Grid.ColumnProperty, colonne);
                block.SetValue(Grid.RowProperty, ligne);
                Grille.Children.Add(block);
            }
        }

        public void AfficherPiece(TetrisValeur couleur)
        {
            for (int block = 0; block < 4; block++)
            {
                int PieceCourante = (int)m_PieceCourante;
                int ligneRel = pieces[PieceCourante, Rotation % 4, block, 0];
                int colonneRel = pieces[PieceCourante, Rotation % 4, block, 1];

                int ligne = ligneTetris + ligneRel;
                int colonne = colonneTetris + colonneRel;

                if (ligne >= 0 && ligne < 20 && colonne >= 0 && colonne < 10)
                {
                    AfficherBlockPiece(ligne, colonne, couleur);
                }
            }
        }

        private void ChoisirPiece()
        {
            if (m_PremierChoix)
            {
                m_PieceCourante = PieceAuHasard();
                m_PremierChoix = false;
            }
            else
            {
                m_PieceCourante = m_ProchainePiece;
            }
            m_ProchainePiece = PieceAuHasard();
        }

        #region Timer 

        //private void StartAscenscion(object sender, EventArgs e)
        //{
        //    Wallah().Start();
        //}
        //DispatcherTimer timer;

        //void MainWindow_Initilized(object sender, EventArgs e)
        //{
        //    timer = new DispatcherTimer();
        //    timer.Tick += new EventHandler(timer_Tick);
        //    timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        //    timer.Start();
        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    DeplacementPiece(1,0,0);
        //}

        #endregion

        #region Move

        private bool DeplacementPiece(int ligne, int colonne, int rotation)
        {
            Grille.Children.Clear();
            ChangeCoordonee(ligne, colonne, rotation);
            AfficherPiece(m_PieceCourante);

            return true;
        }

        //fait le deplacement et verifie la possibilité de se deplacer dans la grille
        // Le e.modifiers doit enregistrer la seconde touche sur le clavier
        private void Window_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Key.Up))
            {
                DeplacementPiece(0, 0, 1);
            }

            else if (e.KeyCode.Equals(Key.Down))
            {
                if (CheckMap() == false)
                {
                    if (e.KeyCode.Equals(Key.Down) && e.Modifiers.Equals(Key.Left))
                    {
                        DeplacementPiece(0, -1, 0);
                    }
                    else if (e.KeyCode.Equals(Key.Down) && e.Modifiers.Equals(Key.Right))
                    {
                        DeplacementPiece(0, 1, 0);
                    }
                }
                else
                    DeplacementPiece(1, 0, 0);
            }

            // Aller à Gauche
            else if (e.KeyCode.Equals(Key.Left))
            {
                if (CheckMap() == false)
                {
                    if (e.KeyCode.Equals(Key.Left) && e.Modifiers.Equals(Key.Down))
                    {
                        DeplacementPiece(1, 0, 0);
                    }
                    else if (e.KeyCode.Equals(Key.Left) && e.Modifiers.Equals(Key.Right))
                    {
                        DeplacementPiece(0, 1, 0);
                    }
                }
            else
                DeplacementPiece(0, -1, 0);
            }

            // Aller à Droite
            else if (e.KeyCode.Equals(Key.Right))
            {
                if (CheckMap() == false)
                {
                    if (e.KeyCode.Equals(Key.Right) && e.Modifiers.Equals(Key.Down))
                    {
                        DeplacementPiece(1, 0, 0);
                    }
                    else if (e.KeyCode.Equals(Key.Right) && e.Modifiers.Equals(Key.Left))
                    {
                        DeplacementPiece(0, -1, 0);
                    }
                }
                else
                    DeplacementPiece(0, 1, 0);
            }
        }

        public bool CheckMap()
        {
            bool check = false;
            if (c1 == null || c10 == null)
            {
                check = true;
            }
            return check;
        }

        private void ChangeCoordonee(int ligne, int colonne, int rotation)
        {
            Rotation += rotation;
            ligneTetris += ligne;
            colonneTetris += colonne;
        }

        #endregion

        #region Pièces

        public enum TetrisValeur
        {
            CARRE_BLEU = 0,

            LIGNE_ROUGE = 1,

            TRIANGLE_VERT = 2,

            ZIG1_CYAN = 3,

            ZIG2_GRIS = 4,

            L1_ROSE = 5,

            L2_JAUNE = 6,

            TETRIS_RIEN = 7
        }

        static int[,,,] pieces =
            {
                    {	// Le carre (toujours ds la meme position)
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

        #endregion

        private int Rotation;
        private int ligneTetris;
        private int colonneTetris;
        private bool m_PremierChoix = true;
        private TetrisValeur m_ProchainePiece;

        TetrisValeur PieceAuHasard()
        {
            Random truc = new Random();
            int maxVal = (int)TetrisValeur.TETRIS_RIEN;
            int val = truc.Next(maxVal);
            return (TetrisValeur)val;
        }

        private TetrisValeur m_PieceCourante;


        public TetrisValeur PieceCourante
        {
            get { return m_PieceCourante; }
        }
    }
}