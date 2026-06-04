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
            CargarDatosTesteo();
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Carga datos de prueba en la lista de médicos
        /// </summary>
        private void CargarDatosTesteo()
        {
            // Médicos Generales
            Lista.ListaMedicos.Insertar(new MedicoGeneral(
                "MG001", "1234567890", "Juan", "Perez", new DateTime(1980, 5, 15),
                "Activo", "Medicina General", "101", 10, 2000m, 50, "Mañana"
            ));

            Lista.ListaMedicos.Insertar(new MedicoGeneral(
                "MG002", "1122334455", "Ana", "Lopez", new DateTime(1965, 3, 10),
                "Activo", "Medicina General", "102", 25, 2500m, 120, "Tarde"
            ));

            // Médicos Especialistas
            Lista.ListaMedicos.Insertar(new MedicoEspecialista(
                "ME001", "0987654321", "Maria", "Gomez", new DateTime(1975, 8, 20),
                "Activo", "Cardiologia", "202", 15, 3000m, 100, 80, 500m
            ));

            Lista.ListaMedicos.Insertar(new MedicoEspecialista(
                "ME002", "5566778899", "Carlos", "Sanchez", new DateTime(1955, 12, 5),
                "Activo", "Neurologia", "203", 30, 3500m, 150, 140, 700m
            ));
        }

        /// <summary>
        /// Configura las propiedades del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Limpia y recarga el DataGridView
        /// </summary>
        private void LimpiarDataGridView()
        {
            dataGridView1.DataSource = null;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Formularios.Form2 form2 = new Formularios.Form2();
            form2.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya un registro seleccionado
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un médico para eliminar.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del registro seleccionado
            var idCodigo = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(idCodigo))
            {
                MessageBox.Show("Error al obtener el ID del médico.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var resultado = MessageBox.Show(
                $"¿Está seguro de que desea eliminar al médico con ID {idCodigo}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool eliminado = Lista.ListaMedicos.Eliminar(idCodigo);
                if (eliminado)
                {
                    MessageBox.Show("Médico eliminado correctamente.", 
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDataGridView();
                }
                else
                {
                    MessageBox.Show("No se encontró el médico para eliminar.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTotalTipoM_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos.Listar()
                    .GroupBy(m => m.MostrarTipoMedico())
                    .Select(g => new
                    {
                        Tipo = g.Key,
                        Total = g.Count()
                    }).ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMedicoMayorS_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos.Listar()
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

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay médicos en la lista.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPromedioS_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos.Listar()
                    .GroupBy(m => m.MostrarTipoMedico())
                    .Select(g => new
                    {
                        Tipo = g.Key,
                        PromedioSueldo = Math.Round(g.Average(m => m.CalcularSueldo()), 2)
                    }).ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPromedioEdad_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos.Listar()
                    .GroupBy(m => m.MostrarTipoMedico())
                    .Select(g => new
                    {
                        Tipo = g.Key,
                        PromedioEdad = Math.Round(g.Average(m => DateTime.Today.Year - m.FechaNacimiento.Year), 1)
                    }).ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultasMG_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos.Listar()
                    .Where(m => m.MostrarTipoMedico() == "Medico General")
                    .Select(m => new
                    {
                        m.IdCodigo,
                        m.Nombre,
                        m.Apellido,
                        NumeroConsultas = (m as MedicoGeneral)?.NumeroConsultas ?? 0,
                        Turno = (m as MedicoGeneral)?.Turno ?? "N/A"
                    }).ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay médicos generales en la lista.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListarGen_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos
                    .ListarPorTipo("Medico General")
                    .Select(m => new
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

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay médicos generales en la lista.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListarEsp_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDataGridView();
                var resultados = Lista.ListaMedicos
                    .ListarPorTipo("Medico Especialista")
                    .Select(m => new
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
                        ValorComision = (m as MedicoEspecialista)?.ValorComision ?? 0m
                    }).ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay médicos especialistas en la lista.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
