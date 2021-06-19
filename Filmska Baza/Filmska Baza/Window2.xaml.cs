using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Filmska_Baza
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            Load_Genres();
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF,*.PNG";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.RelativeOrAbsolute));
                Image_Path.Content = ofd.FileName;
            }
        }

        private void Load_Genres()
        {

            for (int i = 0; i < Properties.Settings.Default.genres.Count; i++)
            {
                this.ListView_Available_Genres.Items.Add(Properties.Settings.Default.genres[i]);
            }
        }

        private void Accept_Button(object sender, RoutedEventArgs e)
        {
            if(Image_Path.Content.ToString() == "" || Film_Title.Text == "" || Rating_UC.UCText.Text == "")
            {
                MessageBox.Show("Obvezno dodaj sliko, naslov in oceno!");
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Obvezno dodaj sliko, naslov in oceno!", "Opozorilo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }
        private void Add_Director(object sender, RoutedEventArgs e)
        {
            string g = Directors_Textbox.Text;
            if (g != "")
            {
                this.ListView_Directors.Items.Add(g);
            }
        }

        private void Delete_Director(object sender, RoutedEventArgs e)
        {
            if (ListView_Directors.SelectedIndex > -1)
            {
                this.ListView_Directors.Items.RemoveAt(ListView_Directors.SelectedIndex);
            }
        }

        private void Edit_Director(object sender, RoutedEventArgs e)
        {
            string g = Directors_Textbox.Text;
            if (g != "")
            {
                this.ListView_Directors.Items.Insert(ListView_Directors.SelectedIndex, g);
                this.ListView_Directors.Items.RemoveAt(ListView_Directors.SelectedIndex);
            }
        }
        private void Add_Writer(object sender, RoutedEventArgs e)
        {
            string g = Writers_Textbox.Text;
            if (g != "")
            {
                this.ListView_Writers.Items.Add(g);
            }
        }

        private void Delete_Writer(object sender, RoutedEventArgs e)
        {
            if (ListView_Directors.SelectedIndex > -1)
            {
                this.ListView_Writers.Items.RemoveAt(ListView_Writers.SelectedIndex);
            }
            
        }

        private void Edit_Writer(object sender, RoutedEventArgs e)
        {
            string g = Writers_Textbox.Text;
            if (g != "")
            {
                this.ListView_Writers.Items.Insert(ListView_Writers.SelectedIndex, g);
                this.ListView_Writers.Items.RemoveAt(ListView_Writers.SelectedIndex);
            }
        }

        private void Add_Actor(object sender, RoutedEventArgs e)
        {
            string g = Actors_Textbox.Text;
            if (g != "")
            {
                this.ListView_Actors.Items.Add(g);
            }
        }

        private void Delete_Actor(object sender, RoutedEventArgs e)
        {
            if (ListView_Directors.SelectedIndex > -1)
            {
                this.ListView_Actors.Items.RemoveAt(ListView_Actors.SelectedIndex);
            }
            
        }

        private void Edit_Actor(object sender, RoutedEventArgs e)
        {
            string g = Actors_Textbox.Text;
            if (g != "")
            {
                this.ListView_Actors.Items.Insert(ListView_Actors.SelectedIndex, g);
                this.ListView_Actors.Items.RemoveAt(ListView_Actors.SelectedIndex);
            }
        }

        private void Add_Genre(object sender, RoutedEventArgs e)
        {
            this.ListView_Genres.Items.Add(ListView_Available_Genres.SelectedItem);
        }

        private void Delete_Genre(object sender, RoutedEventArgs e)
        {
            if (ListView_Directors.SelectedIndex > -1)
            {
                this.ListView_Genres.Items.RemoveAt(ListView_Genres.SelectedIndex);
            }

            
        }

        private void Fav_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Fav_or_No.Content.ToString() == "Favorite")
            {
                Fav_or_No.Content = "Not Favorite";
            }
            else if (Fav_or_No.Content.ToString() == "Not Favorite")
            {
                Fav_or_No.Content = "Favorite";
            }

        }

        private void UC_OnGetRating(object sender, int rating)
        {
            Rating_UC.UCText.Text = "Ocena: " + rating;
        }
    }
}
