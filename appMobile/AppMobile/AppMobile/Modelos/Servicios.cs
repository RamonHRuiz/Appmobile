namespace AppMobile.Modelos
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Servicios
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "Servicio")]
        public int Servicio_Padre { get; set; }
    }

    public class RootObject
    {
        public List<Servicios> Servicios { get; set; }
    }
}
