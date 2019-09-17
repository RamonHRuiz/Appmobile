namespace AppMobile.VistaModelo
{
    using Modelos;
    public class ServiceViewModel
    {
        #region Propiedades
        public Servicios Service
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public ServiceViewModel(Servicios service)
        {
            this.Service = service;
            Service.Imagen = Service.Name;
        }
        #endregion
    }
}
