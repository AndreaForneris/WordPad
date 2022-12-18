using clsFile_ns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WordPad
{
    public partial class frmMain : Form
    {
        clsFile filemanager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            filemanager = new clsFile();
            this.Text = filemanager.getFileNameRelativo() + " - WordPad";
            filemanager.Modificato = false;
        }

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuovo();
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apri();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salva();
        }

        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filemanager.salvaConNome(rtbFoglio);
            this.Text = filemanager.getFileNameRelativo() + " - WordPad";
        }

        private void rtxtFoglio_TextChanged(object sender, EventArgs e)
        {
            filemanager.Modificato = true;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool annulla = false;
            annulla = controllaModificato();
            if (annulla)
            {
                e.Cancel = true;
            }
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            nuovo();
        }
        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            apri();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            salva();
        }

        private bool controllaModificato()
        {
            bool annulla = false;
            if (filemanager.Modificato)
            {
                //chiedo se si vuole salvare il documento aperto
                string nomeFile = filemanager.getFileName();
                DialogResult ris;
                ris = MessageBox.Show("Salvare le modifiche a " +
                    nomeFile, "WordPad", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (ris == DialogResult.Yes)
                    filemanager.salva(rtbFoglio);
                else if (ris == DialogResult.Cancel)
                    annulla = true;
            }
            return annulla;
        }
        private void apri()
        {
            bool annulla = false;
            annulla = controllaModificato();
            if (!annulla)
            {
                OpenFileDialog dlgApri = new OpenFileDialog();
                dlgApri.Filter = "Documento WordPad (*.rft;*.rft)|*.rft;*.rft|" +
                    "Documento Office (*.docx;*.docx)|*.docx;*.docx|"
                    + "Tutti i file (*.*)|*.*";
                dlgApri.Title = "WordPad - Apri";
                dlgApri.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DialogResult ris;
                ris = dlgApri.ShowDialog();
                if (ris == DialogResult.OK)
                {
                    filemanager.Filename = dlgApri.FileName;
                    rtbFoglio.LoadFile(filemanager.getFileName());
                }
                this.Text = filemanager.getFileNameRelativo() + " - WordPad";
                //s = filemanager.apri();
                //if (s != "")
                //{
                //    //rtbFoglio.Text = s;
                //    rtbFoglio.LoadFile(filemanager.getFileName());
                //    filemanager.Modificato = false;
                //}
                //this.Text = filemanager.getFileNameRelativo() + " - WordPad";
            }
        }
        private void nuovo()
        {
            //bool annulla = false;
            //annulla = controllaModificato();
            if (!controllaModificato())
            {
                rtbFoglio.Text = "";
                this.Text = "Documento - WordPad";
                filemanager.Modificato = false;
                filemanager.Filename = "";
            }
        }
        private void salva()
        {
            filemanager.salva(rtbFoglio);
            this.Text = filemanager.getFileNameRelativo() + " - WordPad";
        }

        private void annulla()
        {
            rtbFoglio.Undo();
        }
        private void ripristina()
        {
            rtbFoglio.Redo();
        }
        private void taglia()
        {
            rtbFoglio.Cut();
        }
        private void copia()
        {
            rtbFoglio.Copy();
        }
        private void incolla()
        {
            rtbFoglio.Paste();
        }

        private void annullaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annulla();
        }

        private void ripristinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ripristina();
        }

        private void annullaToolStripButton_Click(object sender, EventArgs e)
        {
            annulla();
        }

        private void ripristinaToolStripButton_Click(object sender, EventArgs e)
        {
            ripristina();
        }

        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taglia();
        }

        private void copiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copia();
        }

        private void incollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            incolla();
        }

        private void tagliaToolStripButton_Click(object sender, EventArgs e)
        {
            taglia();
        }

        private void copiaToolStripButton_Click(object sender, EventArgs e)
        {
            copia();
        }

        private void incollaToolStripButton_Click(object sender, EventArgs e)
        {
            incolla();
        }

        private void selezionatuttoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbFoglio.SelectAll();
        }

        private void colorToolStripButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbFoglio.SelectionColor = colorDialog1.Color;
            }
        }

        private void fontToolStripButton_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbFoglio.SelectionFont = fontDialog1.Font;
            }
        }

        private void elencoToolStripButton_Click(object sender, EventArgs e)
        {
            rtbFoglio.SelectionBullet = !rtbFoglio.SelectionBullet;
        }

        private void alToolStripButton_Click(object sender, EventArgs e)
        {
            impaginazione("l", 0);
        }

        private void acToolStripButton_Click(object sender, EventArgs e)
        {
            impaginazione("c", 0);
        }

        private void adToolStripButton_Click(object sender, EventArgs e)
        {
            impaginazione("r", 0);
        }

        private void agToolStripButton_Click(object sender, EventArgs e)
        {
            impaginazione("l", 150);
        }

        private void impaginazione(string al, int mr)
        {
            switch (al)
            {
                case "r":
                    rtbFoglio.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                case "l":
                    rtbFoglio.SelectionAlignment = HorizontalAlignment.Left;
                    break;
                case "c":
                    rtbFoglio.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                default:
                    rtbFoglio.SelectionAlignment = HorizontalAlignment.Left;
                    break;
            }

            rtbFoglio.SelectionIndent = mr;
            rtbFoglio.SelectionRightIndent = mr;
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 abBox = new AboutBox1();
            abBox.ShowDialog();
        }


    }
}
