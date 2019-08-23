namespace AppMobile.Modelo
{
    using System.Windows.Input;
    public class LoginViewModel
    {

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemember = true;
        }
        #endregion

        #region Propiedades
        public string Email
        { get; set; }

        public string Password
        { get; set; }

        public bool IsRunning
        { get; set; }

        public bool IsRemember
        { get; set; }
        #endregion

        #region Command
        public ICommand LoginCommand
        { get; set; }

        public ICommand RegistCommand
        { get; set; }
        #endregion
    }
}
