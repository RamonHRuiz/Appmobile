namespace AppMobile.Modelo
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        private string email;
        private string password;
        private bool isrunning;
        private bool isEnable;
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemember = true;
            isEnable = true;
        }
        #endregion

        #region Propiedades
        public string Email
        { get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.email)));
                }
            }
        }

        public string Password
        { get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.password)));
                }
            }
        }

        public bool IsRunning
        { get
            {
                return this.isrunning;
            }
            set
            {
                if (this.isrunning != value)
                {
                    this.isrunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.isrunning)));
                }
            }
        }

        public bool IsEnable
        { get
            {
                return this.isEnable;
            }
            set
            {
                if (this.isEnable != value)
                {
                    this.isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.isEnable)));
                }
            }
        }

        public bool IsRemember
        { get; set; }
        #endregion

        #region Command
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Necesita agregar el Email",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Necesita agregar el Password",
                    "Accept");
                return;
            }

            if (Email != "ruizpachecoramon@gmail.com" || Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tu correo o contraseña es Incorrecto",
                    "Accept");
                Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;

            await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Se a registrado correctamente",
                    "Accept");
        }

        public ICommand RegistCommand
        { get; set; }
        #endregion
    }
}
