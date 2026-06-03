using System;

namespace PAPractica3.Entidades
{
    public abstract class Medico : Persona
    {
        public Medico() { }

        public Medico(string idCodigo, string cedula, string nombre, string apellido,
            DateTime fechaNacimiento, string estado, string especialidad,
            string numeroConsultorio, int aniosExperiencia, decimal sueldoBase)
            : base(idCodigo, cedula, nombre, apellido, fechaNacimiento, estado)
        {
            Especialidad = especialidad;
            NumeroConsultorio = numeroConsultorio;
            AniosExperiencia = aniosExperiencia;
            SueldoBase = sueldoBase;
        }

        public string Especialidad { get; set; }
        public string NumeroConsultorio { get; set; }
        public int AniosExperiencia { get; set; }
        public decimal SueldoBase { get; set; }

        public abstract decimal CalcularSueldo();
        public abstract decimal CalcularBono();
        public abstract string MostrarTipoMedico();
    }
}
