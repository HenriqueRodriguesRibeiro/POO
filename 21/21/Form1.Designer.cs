namespace _21
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCarta = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblJogador = new System.Windows.Forms.Label();
            this.lblBanca = new System.Windows.Forms.Label();
            this.ptnBanca = new System.Windows.Forms.Label();
            this.ptnJogador = new System.Windows.Forms.Label();
            this.btnParar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(22, 525);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(188, 58);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnCarta
            // 
            this.btnCarta.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarta.Location = new System.Drawing.Point(292, 497);
            this.btnCarta.Name = "btnCarta";
            this.btnCarta.Size = new System.Drawing.Size(215, 58);
            this.btnCarta.TabIndex = 1;
            this.btnCarta.Text = "Pedir Carta";
            this.btnCarta.UseVisualStyleBackColor = true;
            this.btnCarta.Click += new System.EventHandler(this.btnCarta_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(804, 525);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(188, 58);
            this.btnReiniciar.TabIndex = 2;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Visible = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_21.Properties.Resources.back_red;
            this.pictureBox2.Location = new System.Drawing.Point(22, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lblJogador
            // 
            this.lblJogador.AutoSize = true;
            this.lblJogador.Font = new System.Drawing.Font("Bauhaus 93", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJogador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblJogador.Location = new System.Drawing.Point(16, 20);
            this.lblJogador.Name = "lblJogador";
            this.lblJogador.Size = new System.Drawing.Size(199, 32);
            this.lblJogador.TabIndex = 5;
            this.lblJogador.Text = "Sua Pontuação";
            // 
            // lblBanca
            // 
            this.lblBanca.AutoSize = true;
            this.lblBanca.Font = new System.Drawing.Font("Bauhaus 93", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBanca.Location = new System.Drawing.Point(16, 358);
            this.lblBanca.Name = "lblBanca";
            this.lblBanca.Size = new System.Drawing.Size(195, 64);
            this.lblBanca.TabIndex = 6;
            this.lblBanca.Text = "Pontuação da \r\nBanca";
            // 
            // ptnBanca
            // 
            this.ptnBanca.AutoSize = true;
            this.ptnBanca.Font = new System.Drawing.Font("Bauhaus 93", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptnBanca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptnBanca.Location = new System.Drawing.Point(75, 440);
            this.ptnBanca.Name = "ptnBanca";
            this.ptnBanca.Size = new System.Drawing.Size(36, 38);
            this.ptnBanca.TabIndex = 7;
            this.ptnBanca.Text = "0";
            // 
            // ptnJogador
            // 
            this.ptnJogador.AutoSize = true;
            this.ptnJogador.Font = new System.Drawing.Font("Bauhaus 93", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptnJogador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptnJogador.Location = new System.Drawing.Point(75, 62);
            this.ptnJogador.Name = "ptnJogador";
            this.ptnJogador.Size = new System.Drawing.Size(36, 38);
            this.ptnJogador.TabIndex = 8;
            this.ptnJogador.Text = "0";
            // 
            // btnParar
            // 
            this.btnParar.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParar.Location = new System.Drawing.Point(552, 497);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(188, 58);
            this.btnParar.TabIndex = 9;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1015, 606);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.ptnJogador);
            this.Controls.Add(this.ptnBanca);
            this.Controls.Add(this.lblBanca);
            this.Controls.Add(this.lblJogador);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnCarta);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCarta;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblJogador;
        private System.Windows.Forms.Label lblBanca;
        private System.Windows.Forms.Label ptnBanca;
        private System.Windows.Forms.Label ptnJogador;
        private System.Windows.Forms.Button btnParar;
    }
}

