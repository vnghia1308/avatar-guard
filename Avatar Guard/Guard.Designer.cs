namespace Avatar_Guard
{
    partial class Guard
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.access_tokenLabel = new System.Windows.Forms.Label();
            this.access_token = new System.Windows.Forms.TextBox();
            this.guardAvatar = new System.Windows.Forms.Button();
            this.loginToken = new System.Windows.Forms.Button();
            this.Copright = new System.Windows.Forms.Label();
            this.unGuard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // access_tokenLabel
            // 
            this.access_tokenLabel.AutoSize = true;
            this.access_tokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.access_tokenLabel.Location = new System.Drawing.Point(13, 13);
            this.access_tokenLabel.Name = "access_tokenLabel";
            this.access_tokenLabel.Size = new System.Drawing.Size(92, 16);
            this.access_tokenLabel.TabIndex = 0;
            this.access_tokenLabel.Text = "access_token";
            // 
            // access_token
            // 
            this.access_token.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.access_token.Location = new System.Drawing.Point(16, 33);
            this.access_token.Name = "access_token";
            this.access_token.Size = new System.Drawing.Size(406, 22);
            this.access_token.TabIndex = 1;
            // 
            // guardAvatar
            // 
            this.guardAvatar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardAvatar.Location = new System.Drawing.Point(347, 61);
            this.guardAvatar.Name = "guardAvatar";
            this.guardAvatar.Size = new System.Drawing.Size(75, 23);
            this.guardAvatar.TabIndex = 2;
            this.guardAvatar.Text = "GUARD";
            this.guardAvatar.UseVisualStyleBackColor = true;
            this.guardAvatar.Click += new System.EventHandler(this.startGuardProtect);
            // 
            // loginToken
            // 
            this.loginToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToken.Location = new System.Drawing.Point(160, 61);
            this.loginToken.Name = "loginToken";
            this.loginToken.Size = new System.Drawing.Size(100, 23);
            this.loginToken.TabIndex = 3;
            this.loginToken.Text = "LOGIN TOKEN";
            this.loginToken.UseVisualStyleBackColor = true;
            this.loginToken.Click += new System.EventHandler(this.Login);
            // 
            // Copright
            // 
            this.Copright.AutoSize = true;
            this.Copright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copright.Location = new System.Drawing.Point(13, 64);
            this.Copright.Name = "Copright";
            this.Copright.Size = new System.Drawing.Size(128, 16);
            this.Copright.TabIndex = 4;
            this.Copright.Text = "© Code by Vy Nghia";
            this.Copright.Click += new System.EventHandler(this.CoprightClick);
            // 
            // unGuard
            // 
            this.unGuard.Location = new System.Drawing.Point(266, 61);
            this.unGuard.Name = "unGuard";
            this.unGuard.Size = new System.Drawing.Size(75, 23);
            this.unGuard.TabIndex = 5;
            this.unGuard.Text = "UN-GUARD";
            this.unGuard.UseVisualStyleBackColor = true;
            this.unGuard.Click += new System.EventHandler(this.Un_Guard);
            // 
            // Guard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 102);
            this.Controls.Add(this.unGuard);
            this.Controls.Add(this.Copright);
            this.Controls.Add(this.loginToken);
            this.Controls.Add(this.guardAvatar);
            this.Controls.Add(this.access_token);
            this.Controls.Add(this.access_tokenLabel);
            this.Name = "Guard";
            this.Text = "Avatar Guard";
            this.Load += new System.EventHandler(this.Guard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label access_tokenLabel;
        private System.Windows.Forms.TextBox access_token;
        private System.Windows.Forms.Button guardAvatar;
        private System.Windows.Forms.Button loginToken;
        private System.Windows.Forms.Label Copright;
        private System.Windows.Forms.Button unGuard;
    }
}

