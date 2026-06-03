using System;

namespace PAPractica3.Entidades
{
    public class MedicoEspecialista : Medico
    {
        public MedicoEspecialista() { }

        public MedicoEspecialista(string idCodigo, string cedula, string nombre, string apellido,
            DateTime fechaNacimiento, string estado, string especialidad,
            string numeroConsultorio, int aniosExperiencia, decimal sueldoBase,
            int numeroCirugias, int cirugiasExitosas, decimal valorComision)
            : base(idCodigo, cedula, nombre, apellido, fechaNacimiento, estado,
                  especialidad, numeroConsultorio, aniosExperiencia, sueldoBase)
        {
            NumeroCirugias = numeroCirugias;
            CirugiasExitosas = cirugiasExitosas;
            ValorComision = valorComision;
        }

        public int NumeroCirugias { get; set; }
        public int CirugiasExitosas { get; set; }
        public decimal ValorComision { get; set; }

        public override decimal CalcularSueldo()
        {
            var descuentoIess = SueldoBase * 0.0932m;
            return SueldoBase - descuentoIess + CalcularBono();
        }

        public override decimal CalcularBono()
        {
            var comision = NumeroCirugias * ValorComision;
            var bonoCirugias = CirugiasExitosas * 300m;
            var bonoExperiencia = AniosExperiencia > 10 ? 700m : 0m;
            return comision + bonoCirugias + bonoExperiencia + CalcularBonoCumpleanos();
        }

        public override string MostrarTipoMedico()
        {
            return "Medico Especialista";
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
