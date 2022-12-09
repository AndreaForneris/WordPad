using clsFile_ns;
using Es06_EditorHTML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public partial class frmMain : Form
    {
        clsStampa printManager;
        clsFile filemanager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            printManager = new clsStampa();
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
            filemanager.salvaConNome(rtbFoglio.Text);
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
                    filemanager.salva(rtbFoglio.Text);
                else if (ris == DialogResult.Cancel)
                    annulla = true;
            }
            return annulla;
        }
        private void apri()
        {
            bool annulla = false;
            string s;
            annulla = controllaModificato();
            if (!annulla)
            {
                s = filemanager.apri();
                if (s != "")
                {
                    //rtbFoglio.Text = s;
                    rtbFoglio.LoadFile(filemanager.getFileName());
                    filemanager.Modificato = false;
                }
                this.Text = filemanager.getFileNameRelativo() + " - WordPad";
            }
        }
        private void nuovo()
        {
            bool annulla = false;
            annulla = controllaModificato();
            if (!annulla)
            {
                rtbFoglio.Text = "";
                this.Text = "Documento - WordPad";
                filemanager.Modificato = false;
            }
        }
        private void salva()
        {
            filemanager.salva(rtbFoglio.Text);
            this.Text = filemanager.getFileNameRelativo() + " - WordPad";
        }

        private void annulla()
        {
            rtbFoglio.Undo();
        }
        private void ripristina()
        {
            //SendKeys.Send("^+z"); //ctrl+z
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

    }
}
