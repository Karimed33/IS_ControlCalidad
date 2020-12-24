namespace ControlCalidad.Vistas
{
    partial class AdministrarOP
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrarOP));
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.lbNumeroOP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtEstadoOP = new System.Windows.Forms.TextBox();
            this.lbLineaTrabajo = new System.Windows.Forms.Label();
            this.txtLineaTrabajo = new System.Windows.Forms.TextBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbModelo = new System.Windows.Forms.ComboBox();
            this.lbModelo = new System.Windows.Forms.Label();
            this.lbOjetivo = new System.Windows.Forms.Label();
            this.txtObjetivo = new System.Windows.Forms.TextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lbDetalle = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.lbAgregar = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dGVLineas = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Botones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lineaTrabajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLineas = new System.Windows.Forms.Button();
            this.pbAgregar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.ordenProduccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbCancelar = new System.Windows.Forms.PictureBox();
            this.lbCancelar = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaTrabajoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenProduccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtNumeroOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroOP.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOP.ForeColor = System.Drawing.Color.Silver;
            this.txtNumeroOP.Location = new System.Drawing.Point(524, 282);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.Size = new System.Drawing.Size(336, 24);
            this.txtNumeroOP.TabIndex = 2;
            // 
            // lbNumeroOP
            // 
            this.lbNumeroOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNumeroOP.AutoSize = true;
            this.lbNumeroOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumeroOP.ForeColor = System.Drawing.Color.Silver;
            this.lbNumeroOP.Location = new System.Drawing.Point(525, 303);
            this.lbNumeroOP.Name = "lbNumeroOP";
            this.lbNumeroOP.Size = new System.Drawing.Size(197, 15);
            this.lbNumeroOP.TabIndex = 213;
            this.lbNumeroOP.Text = "Numero Orden de Producción";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(304, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 32);
            this.label2.TabIndex = 220;
            this.label2.Text = "Orden de Produccion";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtUsuario);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(15, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 43);
            this.panel2.TabIndex = 221;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Silver;
            this.txtUsuario.Location = new System.Drawing.Point(870, 0);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(106, 24);
            this.txtUsuario.TabIndex = 253;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEstadoOP
            // 
            this.txtEstadoOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtEstadoOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstadoOP.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoOP.ForeColor = System.Drawing.Color.Silver;
            this.txtEstadoOP.Location = new System.Drawing.Point(636, 153);
            this.txtEstadoOP.Name = "txtEstadoOP";
            this.txtEstadoOP.ReadOnly = true;
            this.txtEstadoOP.Size = new System.Drawing.Size(106, 24);
            this.txtEstadoOP.TabIndex = 230;
            this.txtEstadoOP.Text = "En Proceso";
            this.txtEstadoOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbLineaTrabajo
            // 
            this.lbLineaTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLineaTrabajo.AutoSize = true;
            this.lbLineaTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineaTrabajo.ForeColor = System.Drawing.Color.Silver;
            this.lbLineaTrabajo.Location = new System.Drawing.Point(520, 247);
            this.lbLineaTrabajo.Name = "lbLineaTrabajo";
            this.lbLineaTrabajo.Size = new System.Drawing.Size(116, 15);
            this.lbLineaTrabajo.TabIndex = 233;
            this.lbLineaTrabajo.Text = "Linea de Trabajo";
            // 
            // txtLineaTrabajo
            // 
            this.txtLineaTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineaTrabajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtLineaTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLineaTrabajo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineaTrabajo.ForeColor = System.Drawing.Color.Silver;
            this.txtLineaTrabajo.Location = new System.Drawing.Point(518, 224);
            this.txtLineaTrabajo.Name = "txtLineaTrabajo";
            this.txtLineaTrabajo.ReadOnly = true;
            this.txtLineaTrabajo.Size = new System.Drawing.Size(344, 24);
            this.txtLineaTrabajo.TabIndex = 232;
            // 
            // cbColor
            // 
            this.cbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.cbColor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(528, 463);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(332, 30);
            this.cbColor.TabIndex = 243;
            // 
            // cbModelo
            // 
            this.cbModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.cbModelo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModelo.ForeColor = System.Drawing.Color.Silver;
            this.cbModelo.FormattingEnabled = true;
            this.cbModelo.Location = new System.Drawing.Point(528, 401);
            this.cbModelo.Name = "cbModelo";
            this.cbModelo.Size = new System.Drawing.Size(332, 30);
            this.cbModelo.TabIndex = 242;
            this.cbModelo.SelectionChangeCommitted += new System.EventHandler(this.cbModelo_SelectionChangeCommitted);
            // 
            // lbModelo
            // 
            this.lbModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModelo.AutoSize = true;
            this.lbModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelo.ForeColor = System.Drawing.Color.Silver;
            this.lbModelo.Location = new System.Drawing.Point(528, 429);
            this.lbModelo.Name = "lbModelo";
            this.lbModelo.Size = new System.Drawing.Size(55, 15);
            this.lbModelo.TabIndex = 240;
            this.lbModelo.Text = "Modelo";
            // 
            // lbOjetivo
            // 
            this.lbOjetivo.AutoSize = true;
            this.lbOjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOjetivo.ForeColor = System.Drawing.Color.White;
            this.lbOjetivo.Location = new System.Drawing.Point(932, 447);
            this.lbOjetivo.Name = "lbOjetivo";
            this.lbOjetivo.Size = new System.Drawing.Size(66, 16);
            this.lbOjetivo.TabIndex = 245;
            this.lbOjetivo.Text = "Objetivo";
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtObjetivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObjetivo.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjetivo.ForeColor = System.Drawing.Color.Silver;
            this.txtObjetivo.Location = new System.Drawing.Point(924, 398);
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.ReadOnly = true;
            this.txtObjetivo.Size = new System.Drawing.Size(101, 46);
            this.txtObjetivo.TabIndex = 244;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(65)))));
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetalle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.ForeColor = System.Drawing.Color.Silver;
            this.txtDetalle.Location = new System.Drawing.Point(526, 339);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(336, 24);
            this.txtDetalle.TabIndex = 246;
            // 
            // lbDetalle
            // 
            this.lbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDetalle.AutoSize = true;
            this.lbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetalle.ForeColor = System.Drawing.Color.Silver;
            this.lbDetalle.Location = new System.Drawing.Point(528, 365);
            this.lbDetalle.Name = "lbDetalle";
            this.lbDetalle.Size = new System.Drawing.Size(72, 15);
            this.lbDetalle.TabIndex = 247;
            this.lbDetalle.Text = "DetalleOP";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.ForeColor = System.Drawing.Color.Silver;
            this.lbEstado.Location = new System.Drawing.Point(649, 180);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(70, 15);
            this.lbEstado.TabIndex = 248;
            this.lbEstado.Text = "EstadoOP";
            // 
            // lbAgregar
            // 
            this.lbAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAgregar.AutoSize = true;
            this.lbAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgregar.ForeColor = System.Drawing.Color.White;
            this.lbAgregar.Location = new System.Drawing.Point(745, 579);
            this.lbAgregar.Name = "lbAgregar";
            this.lbAgregar.Size = new System.Drawing.Size(64, 16);
            this.lbAgregar.TabIndex = 254;
            this.lbAgregar.Text = "Agregar";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtId.Location = new System.Drawing.Point(647, 8);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(33, 15);
            this.txtId.TabIndex = 255;
            // 
            // dGVLineas
            // 
            this.dGVLineas.AllowUserToAddRows = false;
            this.dGVLineas.AllowUserToDeleteRows = false;
            this.dGVLineas.AutoGenerateColumns = false;
            this.dGVLineas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dGVLineas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dGVLineas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVLineas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVLineas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVLineas.ColumnHeadersHeight = 30;
            this.dGVLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVLineas.ColumnHeadersVisible = false;
            this.dGVLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.Botones});
            this.dGVLineas.DataSource = this.lineaTrabajoBindingSource;
            this.dGVLineas.EnableHeadersVisualStyles = false;
            this.dGVLineas.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVLineas.Location = new System.Drawing.Point(15, 219);
            this.dGVLineas.Name = "dGVLineas";
            this.dGVLineas.ReadOnly = true;
            this.dGVLineas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVLineas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVLineas.RowHeadersVisible = false;
            this.dGVLineas.RowHeadersWidth = 81;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dGVLineas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVLineas.Size = new System.Drawing.Size(441, 381);
            this.dGVLineas.TabIndex = 256;
            this.dGVLineas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVLineas_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn.MinimumWidth = 15;
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroDataGridViewTextBoxColumn.Visible = false;
            // 
            // Botones
            // 
            this.Botones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Botones.DataPropertyName = "Numero";
            this.Botones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Botones.HeaderText = "Seleccionar";
            this.Botones.MinimumWidth = 15;
            this.Botones.Name = "Botones";
            this.Botones.ReadOnly = true;
            this.Botones.Text = "Seleccionar";
            // 
            // lineaTrabajoBindingSource
            // 
            this.lineaTrabajoBindingSource.DataSource = typeof(ControlCalidadDominio.Modelo.LineaTrabajo);
            // 
            // btnLineas
            // 
            this.btnLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnLineas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLineas.FlatAppearance.BorderSize = 0;
            this.btnLineas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLineas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineas.ForeColor = System.Drawing.Color.White;
            this.btnLineas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLineas.Location = new System.Drawing.Point(15, 166);
            this.btnLineas.Name = "btnLineas";
            this.btnLineas.Size = new System.Drawing.Size(441, 52);
            this.btnLineas.TabIndex = 257;
            this.btnLineas.Text = "Lineas de Trabajo";
            this.btnLineas.UseVisualStyleBackColor = false;
            this.btnLineas.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // pbAgregar
            // 
            this.pbAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAgregar.Image = global::ControlCalidad.Properties.Resources.finalizado1;
            this.pbAgregar.Location = new System.Drawing.Point(744, 515);
            this.pbAgregar.Name = "pbAgregar";
            this.pbAgregar.Size = new System.Drawing.Size(78, 66);
            this.pbAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAgregar.TabIndex = 253;
            this.pbAgregar.TabStop = false;
            this.pbAgregar.Click += new System.EventHandler(this.pbAgregar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1034, 1);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 37);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 201;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ordenProduccionBindingSource
            // 
            this.ordenProduccionBindingSource.DataSource = typeof(ControlCalidadDominio.Modelo.OrdenProduccion);
            // 
            // pbCancelar
            // 
            this.pbCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCancelar.Image = global::ControlCalidad.Properties.Resources.eliminar3;
            this.pbCancelar.Location = new System.Drawing.Point(967, 515);
            this.pbCancelar.Name = "pbCancelar";
            this.pbCancelar.Size = new System.Drawing.Size(78, 66);
            this.pbCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancelar.TabIndex = 251;
            this.pbCancelar.TabStop = false;
            this.pbCancelar.Click += new System.EventHandler(this.pbModificar_Click);
            // 
            // lbCancelar
            // 
            this.lbCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCancelar.AutoSize = true;
            this.lbCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancelar.ForeColor = System.Drawing.Color.White;
            this.lbCancelar.Location = new System.Drawing.Point(973, 584);
            this.lbCancelar.Name = "lbCancelar";
            this.lbCancelar.Size = new System.Drawing.Size(70, 16);
            this.lbCancelar.TabIndex = 252;
            this.lbCancelar.Text = "Cancelar";
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColor.AutoSize = true;
            this.lbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColor.ForeColor = System.Drawing.Color.Silver;
            this.lbColor.Location = new System.Drawing.Point(528, 491);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(41, 15);
            this.lbColor.TabIndex = 241;
            this.lbColor.Text = "Color";
            // 
            // AdministrarOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1080, 610);
            this.Controls.Add(this.btnLineas);
            this.Controls.Add(this.dGVLineas);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lbAgregar);
            this.Controls.Add(this.pbAgregar);
            this.Controls.Add(this.lbCancelar);
            this.Controls.Add(this.pbCancelar);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbDetalle);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.lbOjetivo);
            this.Controls.Add(this.txtObjetivo);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.cbModelo);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbModelo);
            this.Controls.Add(this.lbLineaTrabajo);
            this.Controls.Add(this.txtLineaTrabajo);
            this.Controls.Add(this.txtEstadoOP);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbNumeroOP);
            this.Controls.Add(this.txtNumeroOP);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdministrarOP";
            this.Text = "AsignarOP";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineaTrabajoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenProduccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.TextBox txtNumeroOP;
        private System.Windows.Forms.Label lbNumeroOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn asignadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEstadoOP;
        private System.Windows.Forms.Label lbLineaTrabajo;
        private System.Windows.Forms.TextBox txtLineaTrabajo;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbModelo;
        private System.Windows.Forms.Label lbModelo;
        private System.Windows.Forms.Label lbOjetivo;
        private System.Windows.Forms.TextBox txtObjetivo;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lbDetalle;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbAgregar;
        private System.Windows.Forms.PictureBox pbAgregar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dGVLineas;
        private System.Windows.Forms.BindingSource lineaTrabajoBindingSource;
        private System.Windows.Forms.Button btnLineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Botones;
        private System.Windows.Forms.BindingSource ordenProduccionBindingSource;
        private System.Windows.Forms.PictureBox pbCancelar;
        private System.Windows.Forms.Label lbCancelar;
        private System.Windows.Forms.Label lbColor;
    }
}