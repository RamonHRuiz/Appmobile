namespace AppMobile.VistaModelo
{
    using GalaSoft.MvvmLight.Command;
    using Modelos;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Vista;
    using Modelo;

    public class ServicieItemViewModel : Servicios
    {
        #region Commands
        public ICommand SelectServiceCommand
        {
            get
            {
                return new RelayCommand(SelectService);
            }
        }
        #endregion

        private async void SelectService()
        {
            MainViewModel.GetInstance().Service = new ServiceViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ServicePage());
        }
    }
}
