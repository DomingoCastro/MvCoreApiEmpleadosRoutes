using MvCoreApiEmpleadosRoutes.Models;
using System.Net.Http.Headers;

namespace MvCoreApiEmpleadosRoutes.Services
{
    public class ServiceEmpleados
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceEmpleados(string url)
        {
            this.UrlApi = url;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }


        //Hacemos un emtodo intermedio para leer los datos del api
        //independientmente de lo que leamos
        //1) Objeto que devuelve: T
        //2) PETICION REQUEST
        private async Task<T> GetDatosApi<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress= new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T datos = await response.Content.ReadAsAsync<T>();
                    return datos;
                }
                else
                {
                    return default(T);
                }
            }

        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            string request = "/api/Empleado";
            List<Empleado> empleados = await this.GetDatosApi<List<Empleado>>(request);
            return empleados;
        }
        public async Task<List<string>> GetOficiosAsync()
        {
            string request = "/api/Empleado/Oficios";
            List<string> oficios = await this.GetDatosApi<List<string>>(request);
            return oficios;
        }
        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            string request = "/api/Empleado/" + id;
            Empleado empleado = await this.GetDatosApi<Empleado>(request);
            return empleado;
        }
        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            string request = "/api/Empleado/EmpleadosOficio/" + oficio;
            List<Empleado> empleados = await this.GetDatosApi<List<Empleado>>(request);
            return empleados;
        }
        public async Task<List<Empleado>> GetEmpleadosSalarioAsync(int salario)
        {
            string request = "/api/Empleado/EmpleadosSalario/" + salario;
            List<Empleado> empleados = await this.GetDatosApi<List<Empleado>>(request);
            return empleados;
        }
    }
}
