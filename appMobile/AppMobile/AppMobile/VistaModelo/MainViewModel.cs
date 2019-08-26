namespace AppMobile.Modelo
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        { get; set; }

        public ServicesViewModel Services
        { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            else
                return instance;
        }
        #endregion
    }
}
