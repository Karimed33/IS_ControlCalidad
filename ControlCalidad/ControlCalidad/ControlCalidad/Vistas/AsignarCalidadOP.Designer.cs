namespace ControlCalidad.Vistas
{
    partial class AsignarCalidadOP
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAsignarOP = new System.Windows.Forms.Button();
            this.lbDefectos = new System.Windows.Forms.Label();
            this.btnEliminarOP = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Controls.Add(this.btnAsignarOP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDefectos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminarOP, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 53);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAsignarOP
            // 
            this.btnAsignarOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnAsignarOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarOP.Image = global::ControlCalidad.Properties.Resources.nuevo;
            this.btnAsignarOP.Location = new System.Drawing.Point(3, 3);
            this.btnAsignarOP.Name = "btnAsignarOP";
            this.btnAsignarOP.Size = new System.Drawing.Size(62, 47);
            this.btnAsignarOP.TabIndex = 1;
            this.btnAsignarOP.UseVisualStyleBackColor = false;
            this.btnAsignarOP.Click += new System.EventHandler(this.btnAsignarOP_Click);
            // 
            // lbDefectos
            // 
            this.lbDefectos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDefectos.AutoSize = true;
            this.lbDefectos.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDefectos.ForeColor = System.Drawing.Color.White;
            this.lbDefectos.Location = new System.Drawing.Point(71, 0);
            this.lbDefectos.Name = "lbDefectos";
            this.lbDefectos.Size = new System.Drawing.Size(330, 53);
            this.lbDefectos.TabIndex = 272;
            // 
            // btnEliminarOP
            // 
            this.btnEliminarOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnEliminarOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarOP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnEliminarOP.Image = global::ControlCalidad.Properties.Resources.eliminar;
            this.btnEliminarOP.Location = new System.Drawing.Point(407, 3);
            this.btnEliminarOP.Name = "btnEliminarOP";
            this.btnEliminarOP.Size = new System.Drawing.Size(56, 47);
            this.btnEliminarOP.TabIndex = 2;
            this.btnEliminarOP.UseVisualStyleBackColor = false;
            // 
            // AsignarCalidadOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AsignarCalidadOP";
            this.Size = new System.Drawing.Size(750, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAsignarOP;
        private System.Windows.Forms.Button btnEliminarOP;
        private System.Windows.Forms.Label lbDefectos;
    }
}
