namespace AppMobile.Modelo
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Vista;

    public class LoginViewModel : BaseViewModel
    {
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
            this.IsEnable = true;

            this.Email = "ruizpachecoramon@gmail.com";
            this.Password = "1234";

        }
        #endregion

        #region Propiedades
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                SetValue(ref email, value);
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetValue(ref password, value);
            }
        }

        public bool IsRunning
        {
            get
            {
                return isrunning;
            }
            set
            {
                SetValue(ref isrunning, value);
            }
        }

        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                SetValue(ref isEnable, value);
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


            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Necesita agregar el Password",
                    "Accept");
                return;
            }

            IsRunning = true;
            IsEnable = false;
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

            this.Email = string.Empty;
            this.Password = string.Empty;
            MainViewModel.GetInstance().Services = new ServicesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ServicesPage());
        }

        public ICommand RegistCommand
        { get; set; }
        #endregion
    }
}
