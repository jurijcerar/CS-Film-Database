using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Filmska_Baza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Film> Filmi = new ObservableCollection<Film>();

        Storyboard story = new Storyboard();
        public MainWindow()
        {
            InitializeComponent();

            StringAnimationUsingKeyFrames anim = new StringAnimationUsingKeyFrames();
            anim.Duration = new Duration(new TimeSpan(0, 0, 11));
            anim.FillBehavior = FillBehavior.HoldEnd;
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("F", TimeSpan.FromSeconds(1)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Fi", TimeSpan.FromSeconds(2)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Fil", TimeSpan.FromSeconds(3)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Film", TimeSpan.FromSeconds(4)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Films", TimeSpan.FromSeconds(5)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmsk", TimeSpan.FromSeconds(6)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmska", TimeSpan.FromSeconds(7)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmska b", TimeSpan.FromSeconds(8)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmska ba", TimeSpan.FromSeconds(9)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmska baz", TimeSpan.FromSeconds(10)));
            anim.KeyFrames.Add(new DiscreteStringKeyFrame("Filmska baza", TimeSpan.FromSeconds(11)));
            Storyboard.SetTargetName(anim, Footer.Name);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Label.ContentProperty));
            story.Children.Add(anim);
            story.Begin(this);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMinutes(60);
            dt.Tick += timeout;
            dt.Start();

            ListView1.ItemsSource = Filmi;

            if (Properties.Settings.Default.genres.ToString() == "")
            {
                Properties.Settings.Default.genres = new System.Collections.Specialized.StringCollection();
            }

            Film temp = new Film() { title = "Taste of Cherry", description = "An Iranian man drives his truck in search of someone who will quietly bury him under a cherry tree after he commits suicide.", rating = 2, poster = "slike/1.jpg", favorite = true };
            temp.directors.Add("Martin Scorsese");
            temp.writers.Add("Martin Scorsese");
            temp.actors.Add("Martin Scorsese");
            Filmi.Add(temp);

            temp = new Film() { title = "Drugo", description = "An Iranian man drives his truck in search of someone who will quietly bury him under a cherry tree after he commits suicide.", rating = 4, poster = "slike/2.jpg" };
            temp.directors.Add("Ed Holmes");
            temp.writers.Add("Ed Holmes");
            temp.actors.Add("Ed Holmes");
            Filmi.Add(temp);

            temp = new Film() { title = "Trtje", description = "An Iranian man drives his truck in search of someone who will quietly bury him under a cherry tree after he commits suicide.", rating = 2, poster = "slike/3.jpg", favorite = true };
            temp.directors.Add("Nekdo");
            temp.writers.Add("Ed Holmes");
            temp.actors.Add("Ed Holmes");
            Filmi.Add(temp);

            CollectionView view = CollectionViewSource.GetDefaultView(ListView1.ItemsSource) as CollectionView;

            view.Filter = CustomFilter;

        }

        private bool CustomFilter(object obj)
        {
            if (string.IsNullOrEmpty(txtData.Text))
            {
                return true;
            }
            else
            {
                return (obj.ToString().IndexOf(txtData.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void txtData_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListView1.ItemsSource).Refresh();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {

                using (TextWriter tw = new StreamWriter("Saves/autosave.xml"))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Film>));
                    xs.Serialize(tw, Filmi);
                }
        }

        private void timeout(object sender, EventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
           System.Windows.Application.Current.Shutdown();
        }

        private void settings_window(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            if(window.ShowDialog() == true)
            {
                if((bool)window.AS_bool.IsChecked == true)
                {
                    DispatcherTimer dt = new DispatcherTimer();
                    int time = Int32.Parse(window.AS_time.Text);
                    dt.Interval = TimeSpan.FromMinutes(time);
                    dt.Tick += Dt_Tick;
                    dt.Start();
                }
                else
                {
                    DispatcherTimer dt = new DispatcherTimer();
                }
            }
            
        }

        private void remove_film(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedIndex > -1)
            {
                Filmi.RemoveAt(ListView1.SelectedIndex);
            }
            else
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Niste izbrali filma!", "Opozorilo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void add_film(object sender, RoutedEventArgs e)
        {
            /*int i = (ListView1.Items.Count + 1);
            Film temp = new Film() { title = "Film" + i, description = i + " Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", rating = 2 };
            temp.poster = new BitmapImage(new Uri("slike/d.jpg", UriKind.Relative));
            Filmi.Add(temp);*/

            Window2 window = new Window2();
            window.Fav_or_No.Content = "Not Favorite";
            if (window.ShowDialog() == true)
            {
                Film f = new Film();
                f.title = window.Film_Title.Text;
                f.poster = window.Image_Path.Content.ToString();
                f.favorite = false;
                if(window.Fav_or_No.Content.ToString() == "Favorite")
                {
                    f.favorite = true;
                }
                //MessageBox.Show(window.Image_Path.Content.ToString());

                for (int i = 0; i < window.ListView_Directors.Items.Count; i++)
                {
                    f.directors.Add(window.ListView_Directors.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Writers.Items.Count; i++)
                {
                    f.writers.Add(window.ListView_Writers.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Actors.Items.Count; i++)
                {
                    f.actors.Add(window.ListView_Actors.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Genres.Items.Count; i++)
                {
                    f.genres.Add(window.ListView_Genres.Items[i].ToString());
                }

                f.description = window.Desc_Text.Text;

                f.rating = int.Parse(window.Rating_UC.UCText.Text[window.Rating_UC.UCText.Text.Length-1].ToString());

                Filmi.Add(f);
            }
        }



       /*BitmapImage toc = new BitmapImage(new Uri("slike/1.jpg", UriKind.Relative));
        BitmapImage sa = new BitmapImage(new Uri("slike/2.jpg", UriKind.Relative));
        BitmapImage fc = new BitmapImage(new Uri("slike/3.jpg", UriKind.Relative));
        BitmapImage hf = new BitmapImage(new Uri("slike/4.jpg", UriKind.Relative));
        BitmapImage zo = new BitmapImage(new Uri("slike/5.jpg", UriKind.Relative));
        BitmapImage def = new BitmapImage(new Uri("slike/d.jpg", UriKind.Relative));*/

        private void change_film(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedIndex > -1)
            {
                int j = ListView1.SelectedIndex;
                FilmTitle.Content = Filmi[j].title;
                Poster.Source = new BitmapImage(new Uri(Filmi[j].poster, UriKind.RelativeOrAbsolute));
                FilmData.Text = "Directors: ";
                for (int i = 0; i < Filmi[j].directors.Count; i++)
                {
                    FilmData.Text += Filmi[j].directors[i];
                    FilmData.Text += " ";
                }
                FilmData.Text += "\n ";

                FilmData.Text += "Writers: ";
                for (int i = 0; i < Filmi[j].writers.Count; i++)
                {
                    FilmData.Text += Filmi[j].writers[i];
                    FilmData.Text += " ";
                }
                FilmData.Text += "\n ";

                FilmData.Text += "Actors: ";
                for (int i = 0; i < Filmi[j].actors.Count; i++)
                {
                    FilmData.Text += Filmi[j].actors[i];
                    FilmData.Text += " ";
                }
                FilmData.Text += "\n ";

                FilmDesc.Text = Filmi[j].description;
                Rating_UC.UCSelect.SelectedIndex = -1;
                Fav_or_No.Content = "Not Favorite";
                if (Filmi[j].favorite == true)
                {
                    Fav_or_No.Content = "Favorite";
                }

                Rating_UC.UCText.Text = "Ocena: " + Filmi[j].rating.ToString();
            }
            
        }

        private void Change_Film(object sender, MouseButtonEventArgs e)
        {
            Window2 window = new Window2();

            int j = ListView1.SelectedIndex;
            window.Film_Title.Text = Filmi[j].title;
            window.img.Source = new BitmapImage(new Uri(Filmi[j].poster, UriKind.RelativeOrAbsolute));
            window.Image_Path.Content = Filmi[j].poster;
            window.Title = Filmi[j].title;
            window.Fav_or_No.Content = "Not Favorite";

            if (Filmi[j].favorite)
            {
                window.Fav_or_No.Content = "Favorite";
            }

            for (int i = 0; i < Filmi[j].directors.Count; i++)
            {
                window.ListView_Directors.Items.Add(Filmi[j].directors[i]);
            }

            for (int i = 0; i < Filmi[j].writers.Count; i++)
            {
                window.ListView_Writers.Items.Add(Filmi[j].writers[i]);
            }

            for (int i = 0; i < Filmi[j].actors.Count; i++)
            {
                window.ListView_Actors.Items.Add(Filmi[j].actors[i]);
            }

            for (int i = 0; i < Filmi[j].genres.Count; i++)
            {
                window.ListView_Genres.Items.Add(Filmi[j].genres[i]);
            }

            window.Desc_Text.Text = Filmi[j].description;

            window.Rating_UC.UCText.Text = "Ocena: " + Filmi[j].rating;

            if (window.ShowDialog() == true)
            {
                Filmi[j].title = window.Film_Title.Text;
                Filmi[j].poster = window.Image_Path.Content.ToString();
                //MessageBox.Show(window.Image_Path.Content.ToString());
                Filmi[j].directors.Clear();
                Filmi[j].writers.Clear();
                Filmi[j].actors.Clear();
                Filmi[j].genres.Clear();

                Filmi[j].favorite = false;
                if (window.Fav_or_No.Content.ToString() == "Favorite")
                {
                    Filmi[j].favorite = true;
                }

                for (int i = 0; i < window.ListView_Directors.Items.Count; i++)
                {
                    Filmi[j].directors.Add(window.ListView_Directors.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Writers.Items.Count; i++)
                {
                    Filmi[j].writers.Add(window.ListView_Writers.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Actors.Items.Count; i++)
                {
                    Filmi[j].actors.Add(window.ListView_Actors.Items[i].ToString());
                }

                for (int i = 0; i < window.ListView_Genres.Items.Count; i++)
                {
                    Filmi[j].genres.Add(window.ListView_Genres.Items[i].ToString());
                }

                Filmi[j].description = window.Desc_Text.Text;

                Filmi[j].rating = int.Parse(window.Rating_UC.UCText.Text[window.Rating_UC.UCText.Text.Length - 1].ToString());

            }
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.XML)|*.XML";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                using (TextReader tr = new StreamReader(ofd.FileName))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Film>));
                    Filmi = (ObservableCollection<Film>)xs.Deserialize(tr);
                    ListView1.ItemsSource = Filmi;
                }

            }
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.XML)|*.XML";

            if (sfd.ShowDialog() == true)
            {
                using (TextWriter tw = new StreamWriter(sfd.FileName))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Film>));
                    xs.Serialize(tw, Filmi);
                }

            }
        }

        private void UC_OnGetRating(object sender, int rating)
        {
            Rating_UC.UCText.Text = "Ocena: " + rating;
            int j = ListView1.SelectedIndex;
            Filmi[j].rating = rating;
        }

        private void Main_Favorite(object sender, RoutedEventArgs e)
        {
            int j = ListView1.SelectedIndex;

            if (Fav_or_No.Content.ToString() == "Favorite")
            {
                Filmi[j].favorite = false;
                Fav_or_No.Content = "Not Favorite";

            }
            else if (Fav_or_No.Content.ToString() == "Not Favorite")
            {
                Filmi[j].favorite = true;
                Fav_or_No.Content = "Favorite";
            }
        }

        private void Default_Layout(object sender, RoutedEventArgs e)
        {
            ListView1.SetValue(Grid.RowProperty, 1);
            ListView1.SetValue(Grid.ColumnProperty, 0);
            //ListView1.SetValue(Grid.RowSpanProperty, 1);

            C.SetValue(Grid.RowProperty, 1);
            C.SetValue(Grid.ColumnProperty, 1);
            C.SetValue(Grid.ColumnSpanProperty, 2);

            E.Visibility = Visibility.Visible;

            F.SetValue(Grid.ColumnProperty, 0);
            F.HorizontalAlignment = HorizontalAlignment.Right;
        }

        private void New_Layout(object sender, RoutedEventArgs e)
        {

            ListView1.SetValue(Grid.RowProperty, 1);
            ListView1.SetValue(Grid.ColumnProperty, 4);
            ListView1.SetValue(Grid.RowSpanProperty, 4);

            C.SetValue(Grid.RowProperty, 1);
            C.SetValue(Grid.ColumnProperty, 0);
            C.SetValue(Grid.ColumnSpanProperty, 2);

            E.Visibility = Visibility.Collapsed;

            F.SetValue(Grid.ColumnProperty, 2);
            F.HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
}
