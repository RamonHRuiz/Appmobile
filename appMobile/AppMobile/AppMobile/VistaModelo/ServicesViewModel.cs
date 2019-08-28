namespace AppMobile.Modelo
{
    using System.Collections.Generic;
    using Modelos;
    using System.Collections.ObjectModel;
    using ServiciosApi;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;

    public class ServicesViewModel : BaseViewModel
    {
        #region ServiciosApi
        private ServiciosApi serviciosApi;
        #endregion

        #region Atributos
        private ObservableCollection<Servicios> servicios;
        private bool isRefreshing;
        private string filter;
        private List<Servicios> listaServicio;
        #endregion

        #region Propiedades
        public ObservableCollection<Servicios> Servicios
        {
            get { return servicios; }
            set { SetValue(ref servicios, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }

        }

        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }

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

            if (!conexion.EsCorrecto)
            {
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Mensaje, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var respuesta = await this.serviciosApi.GetList<Servicios>("http://restcountries.eu", "/rest", "/v2/all");
            //var respuesta = await this.serviciosApi.GetList<Servicios>("http://192.168.0.6:8000", "/Documents", "/Trabajos/Servicios");

            if (!respuesta.EsCorrecto)
            {
                await Application.Current.MainPage.DisplayAlert("Error", respuesta.Mensaje, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            listaServicio = (List<Servicios>)respuesta.Resultado;

            this.Servicios = new ObservableCollection<Servicios>(listaServicio);
        }
        #region Commandos
        public ICommand RefrescarComando
        {
            get
            {
                return new RelayCommand(LoadServices);
            }
        }

        public ICommand BuscarCommando
        {
            get
            {
                return new RelayCommand(Buscar);
            }
        }

        private void Buscar()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Servicios = new ObservableCollection<Servicios>(listaServicio);
            }
            else
            {
                this.Servicios = new ObservableCollection<Servicios>(this.listaServicio.Where(s => s.Name.ToLower().Contains(this.filter.ToLower()) 
                || s.Capital.ToLower().Contains(this.filter.ToLower())));
            }
        }
        #endregion

    }
    #endregion
}

