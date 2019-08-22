namespace AppMobile.Infraestructura
{
    using Modelo;
   public class InstanciaLocal
    {
        #region Propiedades
        public MainViewModel Main
        {
            get;set;
        }
        #endregion

        #region Constructor
        public InstanciaLocal()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
