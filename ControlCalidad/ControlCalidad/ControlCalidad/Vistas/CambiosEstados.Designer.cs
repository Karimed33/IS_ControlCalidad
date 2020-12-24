namespace ControlCalidad.Vistas
{
    partial class CambiosEstados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiosEstados));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFinalizar = new System.Windows.Forms.Label();
            this.pbFinalizar = new System.Windows.Forms.PictureBox();
            this.lbPasar = new System.Windows.Forms.Label();
            this.pbPausar = new System.Windows.Forms.PictureBox();
            this.lbIniciar = new System.Windows.Forms.Label();
            this.pbIniciar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbcodOP2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPausar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIniciar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(7, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 57);
            this.panel1.TabIndex = 240;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(357, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(372, 39);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cambio de Estados OP";
            // 
            // lbFinalizar
            // 
            this.lbFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFinalizar.AutoSize = true;
            this.lbFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinalizar.ForeColor = System.Drawing.Color.Silver;
            this.lbFinalizar.Location = new System.Drawing.Point(896, 459);
            this.lbFinalizar.Name = "lbFinalizar";
            this.lbFinalizar.Size = new System.Drawing.Size(75, 15);
            this.lbFinalizar.TabIndex = 239;
            this.lbFinalizar.Text = "FINALIZAR";
            // 
            // pbFinalizar
            // 
            this.pbFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFinalizar.Image = global::ControlCalidad.Properties.Resources.finalizado2;
            this.pbFinalizar.Location = new System.Drawing.Point(875, 358);
            this.pbFinalizar.Name = "pbFinalizar";
            this.pbFinalizar.Size = new System.Drawing.Size(115, 98);
            this.pbFinalizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFinalizar.TabIndex = 238;
            this.pbFinalizar.TabStop = false;
            this.pbFinalizar.Click += new System.EventHandler(this.pbFinalizar_Click);
            // 
            // lbPasar
            // 
            this.lbPasar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPasar.AutoSize = true;
            this.lbPasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPasar.ForeColor = System.Drawing.Color.Silver;
            this.lbPasar.Location = new System.Drawing.Point(467, 459);
            this.lbPasar.Name = "lbPasar";
            this.lbPasar.Size = new System.Drawing.Size(61, 15);
            this.lbPasar.TabIndex = 237;
            this.lbPasar.Text = "PAUSAR";
            // 
            // pbPausar
            // 
            this.pbPausar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbPausar.Image = global::ControlCalidad.Properties.Resources.pausar1;
            this.pbPausar.Location = new System.Drawing.Point(443, 358);
            this.pbPausar.Name = "pbPausar";
            this.pbPausar.Size = new System.Drawing.Size(115, 98);
            this.pbPausar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPausar.TabIndex = 236;
            this.pbPausar.TabStop = false;
            this.pbPausar.Click += new System.EventHandler(this.pbPausar_Click);
            // 
            // lbIniciar
            // 
            this.lbIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbIniciar.AutoSize = true;
            this.lbIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIniciar.ForeColor = System.Drawing.Color.Silver;
            this.lbIniciar.Location = new System.Drawing.Point(83, 459);
            this.lbIniciar.Name = "lbIniciar";
            this.lbIniciar.Size = new System.Drawing.Size(56, 15);
            this.lbIniciar.TabIndex = 235;
            this.lbIniciar.Text = "INICIAR";
            // 
            // pbIniciar
            // 
            this.pbIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbIniciar.Image = global::ControlCalidad.Properties.Resources.empezar1;
            this.pbIniciar.Location = new System.Drawing.Point(59, 358);
            this.pbIniciar.Name = "pbIniciar";
            this.pbIniciar.Size = new System.Drawing.Size(115, 98);
            this.pbIniciar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIniciar.TabIndex = 234;
            this.pbIniciar.TabStop = false;
            this.pbIniciar.Click += new System.EventHandler(this.pbIniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(416, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 233;
            this.label1.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstado.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.ForeColor = System.Drawing.Color.Silver;
            this.txtEstado.Location = new System.Drawing.Point(283, 183);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(344, 34);
            this.txtEstado.TabIndex = 232;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.ForeColor = System.Drawing.Color.Silver;
            this.lbUsuario.Location = new System.Drawing.Point(602, 125);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(52, 16);
            this.lbUsuario.TabIndex = 231;
            this.lbUsuario.Text = "Usuario";
            // 
            // lbcodOP2
            // 
            this.lbcodOP2.AutoSize = true;
            this.lbcodOP2.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcodOP2.ForeColor = System.Drawing.Color.Silver;
            this.lbcodOP2.Location = new System.Drawing.Point(8, 125);
            this.lbcodOP2.Name = "lbcodOP2";
            this.lbcodOP2.Size = new System.Drawing.Size(180, 16);
            this.lbcodOP2.TabIndex = 230;
            this.lbcodOP2.Text = "Código Orden de Producción";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Silver;
            this.txtUsuario.Location = new System.Drawing.Point(598, 98);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(344, 24);
            this.txtUsuario.TabIndex = 229;
            // 
            // txtOP
            // 
            this.txtOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOP.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOP.ForeColor = System.Drawing.Color.Silver;
            this.txtOP.Location = new System.Drawing.Point(7, 98);
            this.txtOP.Name = "txtOP";
            this.txtOP.ReadOnly = true;
            this.txtOP.Size = new System.Drawing.Size(344, 24);
            this.txtOP.TabIndex = 228;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1023, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 37);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 241;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // CambiosEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1064, 571);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbFinalizar);
            this.Controls.Add(this.pbFinalizar);
            this.Controls.Add(this.lbPasar);
            this.Controls.Add(this.pbPausar);
            this.Controls.Add(this.lbIniciar);
            this.Controls.Add(this.pbIniciar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.lbcodOP2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtOP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CambiosEstados";
            this.Text = "CambiosEstados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPausar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIniciar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbFinalizar;
        private System.Windows.Forms.PictureBox pbFinalizar;
        private System.Windows.Forms.Label lbPasar;
        private System.Windows.Forms.PictureBox pbPausar;
        private System.Windows.Forms.Label lbIniciar;
        private System.Windows.Forms.PictureBox pbIniciar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbcodOP2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.PictureBox btnCerrar;
    }
}