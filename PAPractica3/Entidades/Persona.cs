using System;

namespace PAPractica3.Entidades
{
    public class Persona
    {
        public string IdCodigo { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }

        public Persona() { }

        public Persona(string idCodigo, string cedula, string nombre, string apellido,
            DateTime fechaNacimiento, string estado)
        {
            IdCodigo = idCodigo;
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Estado = estado;
        }


    }
}
