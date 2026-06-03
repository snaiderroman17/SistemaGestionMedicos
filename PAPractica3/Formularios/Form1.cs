using PAPractica3.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PAPractica3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Datos de prueba
            Lista.ListaMedicos.Insertar(new MedicoGeneral(
                "MG001", "1234567890", "Juan", "Perez", new DateTime(1980, 5, 15),
                "Activo", "Medicina General", "101", 10, 2000m, 50, "Mañana"
                ));

            Lista.ListaMedicos.Insertar(new MedicoGeneral(
                "MG002", "1122334455", "Ana", "Lopez", new DateTime(1965, 3, 10),
                "Activo", "Medicina General", "102", 25, 2500m, 120, "Tarde"
                ));

            Lista.ListaMedicos.Insertar(new MedicoEspecialista(
                "ME001", "0987654321", "Maria", "Gomez", new DateTime(1975, 8, 20),
                "Activo", "Cardiologia", "202", 15, 3000m, 100, 80, 500m
                ));

            Lista.ListaMedicos.Insertar(new MedicoEspecialista(
                "ME002", "5566778899", "Carlos", "Sanchez", new DateTime(1955, 12, 5),
                "Activo", "Neurologia", "203", 30, 3500m, 150, 140, 700m
                ));
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Formularios.Form2 form2 = new Formularios.Form2();
            form2.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //obtener el primer campo del registro seleccionado
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var idCodigo = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(idCodigo))
                {
                    var eliminado = Lista.ListaMedicos.Eliminar(idCodigo);
                    if (eliminado)
                    {
                        MessageBox.Show("Médico eliminado correctamente.");
                        btnListarGen.PerformClick(); // Refrescar la lista
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el médico para eliminar.");
                    }
                }
            }
        }

        private void btnTotalTipoM_Click(object sender, EventArgs e)
        {
            // Total por tipo de medico
            dataGridView1.DataSource = Lista.ListaMedicos.Listar()
                .GroupBy(m => m.MostrarTipoMedico())
                .Select(g => new
                {
                    Tipo = g.Key,
                    Total = g.Count()
                }).ToList();
        }

        private void btnMedicoMayorS_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Lista.ListaMedicos.Listar()
                .Select(m => new
                {
                    m.IdCodigo,
                    m.Nombre,
                    m.Apellido,
                    Tipo = m.MostrarTipoMedico(),
                    Sueldo = m.CalcularSueldo()
                })
                .OrderByDescending(m => m.Sueldo)
                .Take(1)
                .ToList();
        }

        private void btnPromedioS_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Lista.ListaMedicos.Listar()
                .GroupBy(m => m.MostrarTipoMedico())
                .Select(g => new
                {
                    Tipo = g.Key,
                    PromedioSueldo = g.Average(m => m.CalcularSueldo())
                }).ToList();
        }

        private void btnPromedioEdad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Lista.ListaMedicos.Listar()
                .GroupBy(m => m.MostrarTipoMedico())
                .Select(g => new
                {
                    Tipo = g.Key,
                    PromedioEdad = g.Average(m => DateTime.Today.Year - m.FechaNacimiento.Year)
                }).ToList();
        }

        private void btnConsultasMG_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Lista.ListaMedicos.Listar()
                .Where(m => m.MostrarTipoMedico() == "Medico General")
                .Select(m => new
                {
                    m.IdCodigo,
                    m.Nombre,
                    m.Apellido,
                    NumeroConsultas = (m as MedicoGeneral)?.NumeroConsultas ?? 0
                }).ToList();
        }

        private void btnListarGen_Click(object sender, EventArgs e)
        {
            // Aparezcan atributos en orden
            dataGridView1.DataSource = Lista.ListaMedicos
                .ListarPorTipo("Medico General").Select(m => new
                {
                    m.IdCodigo,
                    m.Nombre,
                    m.Apellido,
                    m.FechaNacimiento,
                    m.Estado,
                    m.Especialidad,
                    m.NumeroConsultorio,
                    m.AniosExperiencia,
                    m.SueldoBase,
                    NumeroConsultas = (m as MedicoGeneral)?.NumeroConsultas ?? 0,
                    Turno = (m as MedicoGeneral)?.Turno ?? "N/A"
                }).ToList();
        }

        private void btnListarEsp_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Lista.ListaMedicos
                .ListarPorTipo("Medico Especialista").Select(m => new
                {
                    m.IdCodigo,
                    m.Nombre,
                    m.Apellido,
                    m.FechaNacimiento,
                    m.Estado,
                    m.Especialidad,
                    m.NumeroConsultorio,
                    m.AniosExperiencia,
                    m.SueldoBase,
                    NumeroCirugias = (m as MedicoEspecialista)?.NumeroCirugias ?? 0,
                    CirugiasExitosas = (m as MedicoEspecialista)?.CirugiasExitosas ?? 0,
                    ValorComision = (m as MedicoEspecialista)?.ValorComision ?? 0
                }).ToList();
        }
    }
}
