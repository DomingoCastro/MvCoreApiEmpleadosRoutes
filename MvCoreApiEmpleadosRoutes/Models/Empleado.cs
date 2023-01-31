namespace MvCoreApiEmpleadosRoutes.Models
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Oficio { get; set; }
        public int IdDepartamento { get; set; }
        public int Salario { get; set; }
    }
}
