using PAPractica3.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace PAPractica3.Lista
{
    public static class ListaMedicos
    {
        private static readonly List<Medico> medicos = new List<Medico>();

        public static List<Medico> Listar()
        {
            return medicos.ToList();
        }

        public static void Insertar(Medico medico)
        {
            if (medico == null)
            {
                return;
            }

            medicos.Add(medico);
        }

        public static bool Eliminar(string idCodigo)
        {
            var medico = medicos.FirstOrDefault(item => item.IdCodigo == idCodigo);
            if (medico == null)
            {
                return false;
            }

            return medicos.Remove(medico);
        }

        public static decimal CalcularSueldo(Medico medico)
        {
            return medico?.CalcularSueldo() ?? 0m;
        }

        public static List<Medico> ListarPorTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                return new List<Medico>();
            }

            return medicos
                .Where(item => item.MostrarTipoMedico() == tipo)
                .ToList();
        }
    }
}
