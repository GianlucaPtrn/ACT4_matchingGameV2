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
using System.Xml.Linq;

namespace Act4_MatchingGame_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[,] textblock = new TextBlock[4,4];
        public MainWindow()
        {
            InitializeComponent();
            affichageWpf();
        }

        public void affichageWpf()
        {
            //Caractéristique de toutes la pages
            this.Width = 400;
            this.Height = 450;
            this.FontSize = 36;
            this.Title = "Interface dynamique pour le matching game";

            //Création des colonnes
            ColumnDefinition[] coldef = new ColumnDefinition[4];
            for (int i = 0; i < 4; i++)
            {
                coldef[i] = new ColumnDefinition();
                GrdMain.ColumnDefinitions.Add(coldef[i]);
            }

            //Création des lignes
            RowDefinition[] rowDef = new RowDefinition[4];
            for (int y = 0; y < 4; y++)
            {
                rowDef[y] = new RowDefinition();
                GrdMain.RowDefinitions.Add(rowDef[y]);
            }

            //Boucle créant les textBlocks en ajoutant les caractéristiques 
            for (int x = 0; x < 4; x++)
            {
                for(int y = 0; y < 4; y++)
                {
                    //paramètre de base
                    textblock[x,y] = new TextBlock();
                    textblock[x, y].Text = "?";
                    textblock[x, y].HorizontalAlignment = HorizontalAlignment.Center;
                    textblock[x, y].VerticalAlignment = VerticalAlignment.Center;
                    //positionement de chaque textBlock grâce à la boucle for
                    Grid.SetColumn(textblock[x, y], x);
                    Grid.SetRow(textblock[x, y], y);
                    //ajout de l'enfant (pour créer concretement le textBlock)
                    GrdMain.Children.Add(textblock[x, y]);
                    //Création d'un évènement (click gauche = X et en bonus click droit = ? )
                    textblock[x, y].MouseLeftButtonDown += new MouseButtonEventHandler(Case_MouseDown);
                    textblock[x, y].MouseRightButtonDown += new MouseButtonEventHandler(Case_MouseDown_Reverse);
                }
            }
        }
        //Procédure qui permet que quand il y a un évènement de click gauche alors le texte est modifié 
        public void Case_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            ((TextBlock)sender).Text = "X";
        }
        
        //BONUS
        //Un "reset" avec click droit
        //Procédure qui permet que quand il y a un évènement de click droit alors le texte est modifié 
        public void Case_MouseDown_Reverse(Object sender, EventArgs e)
        {
            ((TextBlock)sender).Text = "?";
        }
    }
}
