using System.ComponentModel;

namespace AppUserData.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, string PropertyName = null)
        {
            var result = false;
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(PropertyName);
                result = true;
            }
            return result;
        }
    }

}
