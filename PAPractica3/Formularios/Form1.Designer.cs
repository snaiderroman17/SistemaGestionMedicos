namespace PAPractica3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConsultasMG = new System.Windows.Forms.Button();
            this.btnPromedioEdad = new System.Windows.Forms.Button();
            this.btnPromedioS = new System.Windows.Forms.Button();
            this.btnMedicoMayorS = new System.Windows.Forms.Button();
            this.btnTotalTipoM = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnListarEsp = new System.Windows.Forms.Button();
            this.btnListarGen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Médicos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 183);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultasMG);
            this.groupBox1.Controls.Add(this.btnPromedioEdad);
            this.groupBox1.Controls.Add(this.btnPromedioS);
            this.groupBox1.Controls.Add(this.btnMedicoMayorS);
            this.groupBox1.Controls.Add(this.btnTotalTipoM);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultas";
            // 
            // btnConsultasMG
            // 
            this.btnConsultasMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultasMG.Location = new System.Drawing.Point(403, 35);
            this.btnConsultasMG.Name = "btnConsultasMG";
            this.btnConsultasMG.Size = new System.Drawing.Size(93, 59);
            this.btnConsultasMG.TabIndex = 8;
            this.btnConsultasMG.Text = "Consultas por médico general";
            this.btnConsultasMG.UseVisualStyleBackColor = true;
            this.btnConsultasMG.Click += new System.EventHandler(this.btnConsultasMG_Click);
            // 
            // btnPromedioEdad
            // 
            this.btnPromedioEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromedioEdad.Location = new System.Drawing.Point(304, 35);
            this.btnPromedioEdad.Name = "btnPromedioEdad";
            this.btnPromedioEdad.Size = new System.Drawing.Size(93, 59);
            this.btnPromedioEdad.TabIndex = 7;
            this.btnPromedioEdad.Text = "Promedio de edad";
            this.btnPromedioEdad.UseVisualStyleBackColor = true;
            this.btnPromedioEdad.Click += new System.EventHandler(this.btnPromedioEdad_Click);
            // 
            // btnPromedioS
            // 
            this.btnPromedioS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromedioS.Location = new System.Drawing.Point(204, 35);
            this.btnPromedioS.Name = "btnPromedioS";
            this.btnPromedioS.Size = new System.Drawing.Size(93, 59);
            this.btnPromedioS.TabIndex = 6;
            this.btnPromedioS.Text = "Promedio de sueldo";
            this.btnPromedioS.UseVisualStyleBackColor = true;
            this.btnPromedioS.Click += new System.EventHandler(this.btnPromedioS_Click);
            // 
            // btnMedicoMayorS
            // 
            this.btnMedicoMayorS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicoMayorS.Location = new System.Drawing.Point(105, 35);
            this.btnMedicoMayorS.Name = "btnMedicoMayorS";
            this.btnMedicoMayorS.Size = new System.Drawing.Size(93, 59);
            this.btnMedicoMayorS.TabIndex = 5;
            this.btnMedicoMayorS.Text = "Medico con mayor suledo";
            this.btnMedicoMayorS.UseVisualStyleBackColor = true;
            this.btnMedicoMayorS.Click += new System.EventHandler(this.btnMedicoMayorS_Click);
            // 
            // btnTotalTipoM
            // 
            this.btnTotalTipoM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalTipoM.Location = new System.Drawing.Point(6, 35);
            this.btnTotalTipoM.Name = "btnTotalTipoM";
            this.btnTotalTipoM.Size = new System.Drawing.Size(93, 59);
            this.btnTotalTipoM.TabIndex = 4;
            this.btnTotalTipoM.Text = "Total por tipo de médico";
            this.btnTotalTipoM.UseVisualStyleBackColor = true;
            this.btnTotalTipoM.Click += new System.EventHandler(this.btnTotalTipoM_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.Location = new System.Drawing.Point(12, 77);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(79, 28);
            this.btnInsertar.TabIndex = 3;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(97, 77);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 28);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnListarEsp
            // 
            this.btnListarEsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarEsp.Location = new System.Drawing.Point(182, 77);
            this.btnListarEsp.Name = "btnListarEsp";
            this.btnListarEsp.Size = new System.Drawing.Size(144, 28);
            this.btnListarEsp.TabIndex = 5;
            this.btnListarEsp.Text = "Listar especialistas";
            this.btnListarEsp.UseVisualStyleBackColor = true;
            this.btnListarEsp.Click += new System.EventHandler(this.btnListarEsp_Click);
            // 
            // btnListarGen
            // 
            this.btnListarGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarGen.Location = new System.Drawing.Point(332, 77);
            this.btnListarGen.Name = "btnListarGen";
            this.btnListarGen.Size = new System.Drawing.Size(144, 28);
            this.btnListarGen.TabIndex = 6;
            this.btnListarGen.Text = "Listar generales";
            this.btnListarGen.UseVisualStyleBackColor = true;
            this.btnListarGen.Click += new System.EventHandler(this.btnListarGen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListarGen);
            this.Controls.Add(this.btnListarEsp);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnListarEsp;
        private System.Windows.Forms.Button btnPromedioEdad;
        private System.Windows.Forms.Button btnPromedioS;
        private System.Windows.Forms.Button btnMedicoMayorS;
        private System.Windows.Forms.Button btnTotalTipoM;
        private System.Windows.Forms.Button btnConsultasMG;
        private System.Windows.Forms.Button btnListarGen;
    }
}

