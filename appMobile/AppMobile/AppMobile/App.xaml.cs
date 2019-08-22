namespace AppMobile
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Vista;

    public partial class App : Application
    {
        #region Constructor
        public App()
        {
            InitializeComponent();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        #endregion

        #region Region
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
