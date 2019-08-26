namespace AppMobile.Modelo
{
    using System.Collections.Generic;
    using Modelos;
    using System.Collections.ObjectModel;
    using ServiciosApi;
    using Xamarin.Forms;

    public class ServicesViewModel : BaseViewModel
    {
        #region ServiciosApi
        private ServiciosApi serviciosApi;
        #endregion

        #region Atributos
        private ObservableCollection<Servicios> servicios;
        #endregion

        #region Propiedades
        public ObservableCollection<Servicios> Servicios
        {
            get { return servicios; }
            set { SetValue(ref servicios, value); }
        }
        #endregion

        #region Constructor
        public ServicesViewModel()
        {
            this.serviciosApi = new ServiciosApi();
            this.LoadServices();
        }
        #endregion

        #region Metodos
        private async void LoadServices()
        {
            var conexion = await this.serviciosApi.RevisaConeccion();

            if(!conexion.EsCorrecto)
            {
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Mensaje, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var respuesta = await this.serviciosApi.GetList<Servicios>("", "", "");

            if(!respuesta.EsCorrecto)
            {
                await Application.Current.MainPage.DisplayAlert("Error", respuesta.Mensaje, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var listservicios = (List<Servicios>)respuesta.Resultado;

            this.Servicios = new ObservableCollection<Servicios>(listservicios);

        }
        #endregion
    }
}
