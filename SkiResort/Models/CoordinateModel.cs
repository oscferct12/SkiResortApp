namespace SkiResort.Models
{

    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class CoordinateModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        private int _xCoord;

        /// <summary>
        /// 
        /// </summary>
        private int _yCoord;

        /// <summary>
        /// 
        /// </summary>
        private int _value;

        /// <summary>
        /// 
        /// </summary>
        public int Xcoord
        {
            get { return _xCoord; }
            set
            {
                if (_xCoord == value) return;
                _xCoord = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Ycoord
        {
            get { return _yCoord; }
            set
            {
                if (_yCoord == value) return;
                _yCoord = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
