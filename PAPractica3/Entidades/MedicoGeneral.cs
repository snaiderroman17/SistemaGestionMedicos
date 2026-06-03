using System;

namespace PAPractica3.Entidades
{
    public class MedicoGeneral : Medico
    {
        public MedicoGeneral() { }
        public MedicoGeneral(string idCodigo, string cedula, string nombre, string apellido,
            DateTime fechaNacimiento, string estado, string especialidad,
            string numeroConsultorio, int aniosExperiencia, decimal sueldoBase,
            int numeroConsultas, string turno)
            : base(idCodigo, cedula, nombre, apellido, fechaNacimiento, estado, especialidad,
                  numeroConsultorio, aniosExperiencia, sueldoBase)
        {
            NumeroConsultas = numeroConsultas;
            Turno = turno;
        }

        public int NumeroConsultas { get; set; }
        public string Turno { get; set; }

        public override decimal CalcularSueldo()
        {
            var descuentoIess = SueldoBase * 0.0932m;
            return SueldoBase - descuentoIess + CalcularBono();
        }

        public override decimal CalcularBono()
        {
            var bonoConsultas = NumeroConsultas * 50m;
            var bonoAdicional = NumeroConsultas > 80 ? 500m : 0m;
            return bonoConsultas + bonoAdicional + CalcularBonoCumpleanos();
        }

        public override string MostrarTipoMedico()
        {
            return "Medico General";
        }

        private decimal CalcularBonoCumpleanos()
        {
            var hoy = DateTime.Today;
            if (FechaNacimiento.Month != hoy.Month)
            {
                return 0m;
            }

            var edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 60 ? 1000m : 450m;
        }
    }
}
