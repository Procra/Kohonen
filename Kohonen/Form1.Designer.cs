namespace Kohonen
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.map = new System.Windows.Forms.Panel();
            this.generer = new System.Windows.Forms.Button();
            this.Démarrer = new System.Windows.Forms.Button();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map.Location = new System.Drawing.Point(12, 12);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(202, 202);
            this.map.TabIndex = 0;
            this.map.Paint += new System.Windows.Forms.PaintEventHandler(this.map_Paint);
            // 
            // generer
            // 
            this.generer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generer.Location = new System.Drawing.Point(13, 239);
            this.generer.Name = "generer";
            this.generer.Size = new System.Drawing.Size(75, 23);
            this.generer.TabIndex = 1;
            this.generer.Text = "Générer";
            this.generer.UseVisualStyleBackColor = true;
            this.generer.Click += new System.EventHandler(this.generer_Click);
            // 
            // Démarrer
            // 
            this.Démarrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Démarrer.Location = new System.Drawing.Point(138, 239);
            this.Démarrer.Name = "Démarrer";
            this.Démarrer.Size = new System.Drawing.Size(75, 23);
            this.Démarrer.TabIndex = 2;
            this.Démarrer.Text = "Démarrer";
            this.Démarrer.UseVisualStyleBackColor = true;
            this.Démarrer.Click += new System.EventHandler(this.Démarrer_Click);
            // 
            // bgw1
            // 
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 277);
            this.Controls.Add(this.Démarrer);
            this.Controls.Add(this.generer);
            this.Controls.Add(this.map);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.Button generer;
        private System.Windows.Forms.Button Démarrer;
        private System.ComponentModel.BackgroundWorker bgw1;
    }
}

