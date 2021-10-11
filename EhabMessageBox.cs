using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using advanceEnterface;

namespace EhabMessage
{
    public partial class EhabMessageBox : Form
    {

        //the desing vars
        EhabBUttons btnBlue, btnRed, btnGray;
        Label lbltext;
        EhabBUttons btnE;
        FontAwesome.Sharp.IconPictureBox iconpictureBox1;
        //PictureBox pictureBox1;
        //Panel panel1;
        string text, titel;
        MessageBoxButtons mbButtons;
        MessageBoxIcon mbIcons;
        MessageBoxDefaultButton mbDefault;
        DialogResult result;
        public EhabMessageBox(string Titel,string Text, MessageBoxButtons btnMessage,MessageBoxIcon icon,MessageBoxDefaultButton defult)
        {
            InitializeComponent();
            desing();
            text = Text;
            titel = Titel;
             mbButtons= btnMessage;
             mbIcons= icon ;
            mbDefault = defult;
            btnE = new EhabBUttons();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Text = titel;
            lbltext.Text = text;

            /// manege the icons using font awesome 
            if (mbIcons == MessageBoxIcon.Error)
            {
                iconpictureBox1.IconChar = FontAwesome.Sharp.IconChar.Times;
                iconpictureBox1.IconColor = Color.Red;
                iconpictureBox1.IconSize = 30;
                iconpictureBox1.SizeMode = new PictureBoxSizeMode();
            }
            
            else if (mbIcons == MessageBoxIcon.Information)
            {
                iconpictureBox1.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
                iconpictureBox1.IconColor = Color.DarkBlue;
                iconpictureBox1.IconSize = 30;
                iconpictureBox1.SizeMode = new PictureBoxSizeMode();
            }

            else if (mbIcons == MessageBoxIcon.Question)
            {
                iconpictureBox1.IconChar = FontAwesome.Sharp.IconChar.Question;
                iconpictureBox1.IconColor = Color.MediumPurple;
                iconpictureBox1.IconSize = 30;
                iconpictureBox1.SizeMode = new PictureBoxSizeMode();
            }
            else if (mbIcons == MessageBoxIcon.Warning)
            {
                iconpictureBox1.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                iconpictureBox1.IconColor = Color.YellowGreen;
                iconpictureBox1.IconSize = 30;
                iconpictureBox1.SizeMode = new PictureBoxSizeMode();
            }
            else
                iconpictureBox1.IconChar = FontAwesome.Sharp.IconChar.None;


            if(mbButtons==MessageBoxButtons.OK)
            {
                btnBlue.Text = "Ok";
                btnBlue.Click += delegate
                {
                    result = DialogResult.OK;
                    this.Dispose();
                };
                btnGray.Visible = false;
                btnRed.Visible = false;
            }
            else if(mbButtons==MessageBoxButtons.RetryCancel)
            {
                btnRed.Visible = false;
                btnBlue.Location = new Point(116, 103);
                btnGray.Location = new Point(240, 103);

                //Button Event
                btnBlue.Click += delegate
                {
                    result = DialogResult.Retry;
                    this.Dispose();
                };
                btnGray.Click += delegate
                {
                    result = DialogResult.Cancel;
                    this.Dispose();
                };
            }
            else if(mbButtons==MessageBoxButtons.YesNoCancel)
            {
                btnBlue.BackColor = Color.Green;
                btnBlue.Text = "Yes";
                btnBlue.Location = new Point(36, 103);
                btnRed.Text = ">No";
                btnRed.Location = new Point(158, 103);
                btnGray.Text = "Cancel";
                btnGray.Location = new Point(285, 103);


                //Button Event
                btnBlue.Click += delegate
                {
                    result = DialogResult.Yes;
                    this.Dispose();
                };
                btnRed.Click += delegate
                {
                    result = DialogResult.No;
                    this.Dispose();
                };
                btnGray.Click += delegate
                {
                    result = DialogResult.Cancel;
                    this.Dispose();
                };

            }
            else if(mbButtons== MessageBoxButtons.AbortRetryIgnore)
            {
                btnRed.Text = "Abort";
                btnRed.Location=new Point(36, 103);
                btnBlue.BackColor = Color.Blue;
                btnBlue.Text = "Retry";
                btnBlue.Location=new Point(158, 103);
                btnGray.Text = "Ignore";
                btnGray.Location = new Point(285, 103);


                //Button Event
                btnBlue.Click += delegate
                {
                    result = DialogResult.Retry;
                    this.Dispose();
                };
                btnRed.Click += delegate
                {
                    result = DialogResult.Abort;
                    this.Dispose();
                };
                btnGray.Click += delegate
                {
                    result = DialogResult.Ignore;
                    this.Dispose();
                };
            }
            else
            {
                btnBlue.BackColor = Color.Green;
                btnBlue.Text = "Ok";
                btnBlue.Location = new Point(116, 103);
                btnGray.Text = ">Cancel";
                btnGray.Location = new Point(240, 103);
                btnRed.Visible = false;


                //Button Event
                btnBlue.Click += delegate
                {
                    result = DialogResult.Yes;
                    this.Dispose();
                };
               
                btnGray.Click += delegate
                {
                    result = DialogResult.No;
                    this.Dispose();
                };
            }
            if(mbDefault== MessageBoxDefaultButton.Button1)
            {
                btnBlue.Focus();
            }
            else if (mbDefault== MessageBoxDefaultButton.Button2)
            {
                btnRed.Focus();
            } else if (mbDefault== MessageBoxDefaultButton.Button3)
            {
                btnGray.Focus();
            }
            else
            {
                btnBlue.Focus();
            }
        }




        //show methods
        //Frist OverLoad
        static public DialogResult Show(string txt)
        {
            using (EhabMessageBox frm = new EhabMessageBox("Message", txt, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)) 
            {
                frm.ShowDialog();
                return frm.result;
            }

        }
        static public DialogResult Show(string ti,string txt)
        {
            using (EhabMessageBox frm = new EhabMessageBox(ti, txt, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }
        static public DialogResult Show(string txt,MessageBoxButtons messageBtn)
        {
            using (EhabMessageBox frm = new EhabMessageBox("EhabMessage", txt, messageBtn, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }
        static public DialogResult Show(string txt, MessageBoxIcon messageIcon)
        {
            using(EhabMessageBox frm=new EhabMessageBox("EhabMessage",txt,MessageBoxButtons.OKCancel,messageIcon,MessageBoxDefaultButton.Button1))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }
        static public DialogResult Show(string txt,string tit, MessageBoxIcon messageIcon)
        {
            using(EhabMessageBox frm=new EhabMessageBox(tit,txt,MessageBoxButtons.OKCancel,messageIcon,MessageBoxDefaultButton.Button1))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }
        static public DialogResult Show(string ti,string txt,MessageBoxButtons messageBtn)
        {
            using(EhabMessageBox frm=new EhabMessageBox(ti,txt,messageBtn,MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }
        static public DialogResult Show( string txt, MessageBoxButtons messageBtn, MessageBoxIcon messageIcon,MessageBoxDefaultButton def)
        {
            using (EhabMessageBox frm = new EhabMessageBox("EhabMessage", txt, messageBtn, messageIcon,def))
            {
                frm.ShowDialog();
                return frm.result;
            }

        }
        static public DialogResult Show(string ti,string txt,MessageBoxButtons messageBtn,MessageBoxIcon messageIcon, MessageBoxDefaultButton def)
        {
            using(EhabMessageBox frm=new EhabMessageBox(ti,txt,messageBtn,messageIcon,def))
            {
                frm.ShowDialog();
                return frm.result;
            }
            
        }

        //End of Show Functions


        ///the design
        void desing()
        {
            btnBlue = new Button();
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatAppearance.BorderSize = 0;
            this.btnBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.btnBlue.ForeColor = System.Drawing.Color.White;
            this.btnBlue.Location = new System.Drawing.Point(156, 103);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(88, 36);
            this.btnBlue.TabIndex = 0;
            this.btnBlue.Text = ">Retry";
            this.btnBlue.UseVisualStyleBackColor = false;
            // 
            // btnGray
            // 
            btnGray = new Button();
            this.btnGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGray.FlatAppearance.BorderSize = 0;
            this.btnGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGray.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.btnGray.ForeColor = System.Drawing.Color.White;
            this.btnGray.Location = new System.Drawing.Point(285, 103);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(76, 36);
            this.btnGray.TabIndex = 0;
            this.btnGray.Text = "Cancel";
            this.btnGray.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            
            // 
            // lbltext
            // 
            lbltext = new Label();
            this.lbltext.AutoSize = false;
            lbltext.ForeColor = Color.White;
            this.lbltext.Location = new System.Drawing.Point(47, 49);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(353, 51);
            this.lbltext.TabIndex = 3;
            this.lbltext.Text = "label1";
            // 
            // pictureBox1
            // 
            iconpictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconpictureBox1.Location = new System.Drawing.Point(12, 19);
            this.iconpictureBox1.Name = "pictureBox1";
            this.iconpictureBox1.Size = new System.Drawing.Size(41, 29);
            this.iconpictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
           
            // 
            // btnRed
            // 
            btnRed = new EhabBUttons();

            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.BorderSize = 2;
            btnRed.borderrdius = 10;
            
            this.btnRed.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.btnRed.ForeColor = System.Drawing.Color.White;
            this.btnRed.Location = new System.Drawing.Point(28, 103);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(88, 36);
            this.btnRed.TabIndex = 0;
            this.btnRed.Text = "Abort";
            this.btnRed.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 160);
            this.BackColor = Color.FromArgb(26, 40, 50);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.lbltext);
            this.Controls.Add(this.iconpictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
         
            ((System.ComponentModel.ISupportInitialize)(this.iconpictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

      
    }
}
