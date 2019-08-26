namespace AppMobile.ServiciosApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Modelos;
    using Newtonsoft.Json;
    using Plugin.Connectivity;

    public class ServiciosApi
    {
        public async Task<Respuesta> RevisaConeccion()
        {
            if(!CrossConnectivity.Current.IsConnected)
            {
                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje = "Por favor, Necesita conexion a internet"
                };
            }

            var estaConectado = await CrossConnectivity.Current.IsRemoteReachable("google.com");

            if(!estaConectado)
            {
                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje="Revise su conexion a internet"
                };
            }

            return new Respuesta
            {
                EsCorrecto = true,
                Mensaje = "OK"
            };
        }

        public async Task<Respuesta> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var respues = await client.GetAsync(url);
                var result = await respues.Content.ReadAsStringAsync();

                if(!respues.IsSuccessStatusCode)
                {
                    return new Respuesta
                    {
                        EsCorrecto = false,
                        Mensaje = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Respuesta
                {
                    EsCorrecto = true,
                    Mensaje = "OK",
                    Resultado = list
                };
            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje = ex.Message
                };
            }

        }
    }
}
