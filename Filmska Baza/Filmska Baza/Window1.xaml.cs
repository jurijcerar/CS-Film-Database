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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Edit_String();
        }

        private void Add_Genre(object sender, RoutedEventArgs e)
        {
            string g = Add_Genre_Textbox.Text;
            if(g != "")
            {
                Properties.Settings.Default.genres.Add(g);
                Properties.Settings.Default.Save();
                this.Genres_List.Items.Add(g);
            }
            
        }

        private void Delete_Genre(object sender, RoutedEventArgs e)
        {
            if (Genres_List.SelectedIndex > -1)
            {
                Properties.Settings.Default.genres.Remove(Genres_List.SelectedItem.ToString());
                Properties.Settings.Default.Save();
                this.Genres_List.Items.RemoveAt(Genres_List.SelectedIndex);
            }
        }

        private void Edit_String()
        {
            for (int i = 0; i < Properties.Settings.Default.genres.Count; i++)
            {
                this.Genres_List.Items.Add(Properties.Settings.Default.genres[i]);
            }
        }

        private void Edit_Genre(object sender, RoutedEventArgs e)
        {
            string g = Add_Genre_Textbox.Text;
            if (g != "")
            {
                Properties.Settings.Default.genres.Insert(Genres_List.SelectedIndex, g);
                Properties.Settings.Default.genres.RemoveAt(Genres_List.SelectedIndex + 1);
                Properties.Settings.Default.Save();
                this.Genres_List.Items.Insert(Genres_List.SelectedIndex, g);
                this.Genres_List.Items.RemoveAt(Genres_List.SelectedIndex);
            }
        }

        private void Accept_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
