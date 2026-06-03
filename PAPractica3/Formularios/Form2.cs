using System;
using System.Windows.Forms;
using PAPractica3.Entidades;
using PAPractica3.Lista;

namespace PAPractica3.Formularios
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rbtnGeneral.CheckedChanged += TipoMedico_CheckedChanged;
            rbtnEspecialista.CheckedChanged += TipoMedico_CheckedChanged;
            ActualizarCamposPorTipo();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!rbtnGeneral.Checked && !rbtnEspecialista.Checked)
            {
                MessageBox.Show("Seleccione el tipo de médico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text)
                || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtEstado.Text)
                || string.IsNullOrWhiteSpace(txtEspecialidad.Text) || string.IsNullOrWhiteSpace(txtNumConsultorio.Text)
                || string.IsNullOrWhiteSpace(txtAniosExp.Text) || string.IsNullOrWhiteSpace(txtSueldoB.Text))
            {
                MessageBox.Show("Complete los datos generales del médico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAniosExp.Text, out var aniosExp))
            {
                MessageBox.Show("Años de experiencia inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSueldoB.Text, out var sueldoBase))
            {
                MessageBox.Show("Sueldo base inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbtnGeneral.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNumConsultas.Text) || string.IsNullOrWhiteSpace(txtTurno.Text))
                {
                    MessageBox.Show("Complete los datos del médico general.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtNumConsultas.Text, out var numConsultas))
                {
                    MessageBox.Show("Número de consultas inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var medico = new MedicoGeneral
                {
                    IdCodigo = txtCodigo.Text.Trim(),
                    Cedula = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Estado = txtEstado.Text.Trim(),
                    FechaNacimiento = dtpFechaN.Value.Date,
                    Especialidad = txtEspecialidad.Text.Trim(),
                    NumeroConsultorio = txtNumConsultorio.Text.Trim(),
                    AniosExperiencia = aniosExp,
                    SueldoBase = sueldoBase,
                    NumeroConsultas = numConsultas,
                    Turno = txtTurno.Text.Trim()
                };

                ListaMedicos.Insertar(medico);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNumCirugias.Text) || string.IsNullOrWhiteSpace(txtCirugiasEx.Text)
                    || string.IsNullOrWhiteSpace(txtComision.Text))
                {
                    MessageBox.Show("Complete los datos del médico especialista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtNumCirugias.Text, out var numCirugias))
                {
                    MessageBox.Show("Número de cirugías inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCirugiasEx.Text, out var cirugiasExitosas))
                {
                    MessageBox.Show("Número de cirugías exitosas inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtComision.Text, out var comision))
                {
                    MessageBox.Show("Comisión inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var medico = new MedicoEspecialista
                {
                    IdCodigo = txtCodigo.Text.Trim(),
                    Cedula = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Estado = txtEstado.Text.Trim(),
                    FechaNacimiento = dtpFechaN.Value.Date,
                    Especialidad = txtEspecialidad.Text.Trim(),
                    NumeroConsultorio = txtNumConsultorio.Text.Trim(),
                    AniosExperiencia = aniosExp,
                    SueldoBase = sueldoBase,
                    NumeroCirugias = numCirugias,
                    CirugiasExitosas = cirugiasExitosas,
                    ValorComision = comision
                };

                ListaMedicos.Insertar(medico);
            }

            MessageBox.Show("Médico registrado correctamente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarCamposPorTipo();
        }

        private void TipoMedico_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCamposPorTipo();
        }

        private void ActualizarCamposPorTipo()
        {
            var esGeneral = rbtnGeneral.Checked;
            gpbMGeneral.Enabled = esGeneral;
            gpbEspecialista.Enabled = rbtnEspecialista.Checked;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEstado.Clear();
            txtEspecialidad.Clear();
            txtNumConsultorio.Clear();
            txtAniosExp.Clear();
            txtSueldoB.Clear();
            txtNumConsultas.Clear();
            txtTurno.Clear();
            txtNumCirugias.Clear();
            txtCirugiasEx.Clear();
            txtComision.Clear();
        }
    }
}
