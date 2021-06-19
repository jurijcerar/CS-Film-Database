using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Filmska_Baza
{
    public class Film : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private string t = "";
        private string p = "";
        private string d = "";
        private int r = 0;
        private bool f = false;

        public string title
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
                OnPropertyChange(new PropertyChangedEventArgs("title"));
            }
        }
        public string poster
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
                OnPropertyChange(new PropertyChangedEventArgs("poster"));
            }
        }
        public List<string> directors = new List<string>();
        public List<string> writers = new List<string>();
        public List<string> actors = new List<string>();
        public List<string> genres = new List<string>();
        public string description
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                OnPropertyChange(new PropertyChangedEventArgs("description"));
            }
        }
        public int rating
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                OnPropertyChange(new PropertyChangedEventArgs("rating"));
            }
        }

        public bool favorite
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
                OnPropertyChange(new PropertyChangedEventArgs("favorite"));
            }
        }

        public override string ToString()
        {
            return this.title;
        }
    }
}
