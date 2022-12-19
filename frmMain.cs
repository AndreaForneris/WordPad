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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controllaModificato() && filemanager.Filename == "")
                e.Cancel = true;
        }

        private void rtxtFoglio_TextChanged(object sender, EventArgs e)
        {
            filemanager.Modificato = true;
        }

/*---------------------------MenuStrip--------------------------------------*/
/*File*/
    /*nuovo*/
       private void nuovoToolStripMenuItem_Click(object sender, EventArgs e) => nuovo();
    /*apri*/
        private void apriToolStripMenuItem_Click(object sender, EventArgs e) => apri();
    /*salva*/
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e) => salva();
    /*salva con nome*/
        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filemanager.salvaConNome(rtbFoglio);
            this.Text = filemanager.getFileNameRelativo() + " - WordPad";
        }
    /*esci*/
        private void esciToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

/*Modifica*/
    /*annulla*/
        private void annullaToolStripMenuItem_Click(object sender, EventArgs e) => annulla();
    /*ripristina*/
        private void ripristinaToolStripMenuItem_Click(object sender, EventArgs e) => ripristina();
    /*taglia*/
        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e) => taglia();
    /*copia*/
        private void copiaToolStripMenuItem_Click(object sender, EventArgs e) => copia();
    /*incolla*/
        private void incollaToolStripMenuItem_Click(object sender, EventArgs e) => incolla();
    /*seleziona tutto*/
        private void selezionatuttoToolStripMenuItem_Click(object sender, EventArgs e) => rtbFoglio.SelectAll();

/*----------------------------ToolStrip----------------------------------------*/
    /*nuovo*/
        private void nuovoToolStripButton_Click(object sender, EventArgs e) => nuovo();
    /*apri*/
        private void apriToolStripButton_Click(object sender, EventArgs e) => apri();
    /*salva*/
        private void salvaToolStripButton_Click(object sender, EventArgs e) => salva();
    /*annulla*/
        private void annullaToolStripButton_Click(object sender, EventArgs e) => annulla();
    /*ripristina*/
        private void ripristinaToolStripButton_Click(object sender, EventArgs e) => ripristina();
    /*taglia*/
        private void tagliaToolStripButton_Click(object sender, EventArgs e) => taglia();
    /*copia*/
        private void copiaToolStripButton_Click(object sender, EventArgs e) => copia();
    /*incolla*/
        private void incollaToolStripButton_Click(object sender, EventArgs e) => incolla();
    /*colore font*/
        private void colorToolStripButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                rtbFoglio.SelectionColor = colorDialog1.Color;
        }
    /*stile font*/
        private void fontToolStripButton_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                rtbFoglio.SelectionFont = fontDialog1.Font;
        }
    /*grassetto*/
        private void fgToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Font new1, old1;
                old1 = rtbFoglio.SelectionFont;
                if (old1.Bold)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Bold);

                rtbFoglio.SelectionFont = new1;
            }
            catch (Exception)
            {
            }
        }
    /*corsivo*/
        private void fcToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Font new1, old1;
                old1 = rtbFoglio.SelectionFont;
                if (old1.Italic)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Italic);

                rtbFoglio.SelectionFont = new1;
            }
            catch (Exception)
            {
            }
        }
    /*sottolineato*/
        private void fsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Font new1, old1;
                old1 = rtbFoglio.SelectionFont;
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);

                rtbFoglio.SelectionFont = new1;
            }
            catch (Exception){}
        }
    /*barrato*/
        private void fbToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Font new1, old1;
                old1 = rtbFoglio.SelectionFont;
                if (old1.Strikeout)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Strikeout);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Strikeout);

                rtbFoglio.SelectionFont = new1;
            }
            catch (Exception){}
        }
    /*allineamento sinistra*/
        private void alToolStripButton_Click(object sender, EventArgs e)
        {
            checkedYN("l");
            impaginazione("l", 0);
        }
    /*allineamento centrato*/
        private void acToolStripButton_Click(object sender, EventArgs e)
        {
            checkedYN("c");
            if (acToolStripButton.Checked)
                impaginazione("c", 0);
            else
                impaginazione("l", 0);
        } 
    /*allineamento destra*/
        private void adToolStripButton_Click(object sender, EventArgs e)
        {
            checkedYN("r");
            if (adToolStripButton.Checked)
                impaginazione("r", 0);
            else
                impaginazione("l", 0);
        }
    /*allineamento giustificato*/
        private void agToolStripButton_Click(object sender, EventArgs e)
        {
            checkedYN("g");
            if (agToolStripButton.Checked)
                impaginazione("l", 150);
            else
                impaginazione("l", 0);
        }
    /*elenco*/
        private void elencoToolStripButton_Click(object sender, EventArgs e)
        {
            rtbFoglio.SelectionBullet = !rtbFoglio.SelectionBullet;
        }
    /*info*/
        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 abBox = new AboutBox1();
            abBox.ShowDialog();
        }

/*-----------------------------Sottoprogrammi-------------------------------------*/
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
            }
        }

        private void nuovo()
        {
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

        private void annulla() => rtbFoglio.Undo();

        private void ripristina() => rtbFoglio.Redo();

        private void taglia() => rtbFoglio.Cut();

        private void copia() => rtbFoglio.Copy();

        private void incolla() => rtbFoglio.Paste();

        private void checkedYN(string b)
        {
            switch (b)
            {
                case "r":
                    alToolStripButton.Checked = false;
                    acToolStripButton.Checked = false;
                    agToolStripButton.Checked = false;
                    break;
                case "l":
                    adToolStripButton.Checked = false;
                    acToolStripButton.Checked = false;
                    agToolStripButton.Checked = false;
                    break;
                case "c":
                    adToolStripButton.Checked = false;
                    alToolStripButton.Checked = false;
                    agToolStripButton.Checked = false;
                    break;
                case "g":
                    adToolStripButton.Checked = false;
                    acToolStripButton.Checked = false;
                    alToolStripButton.Checked = false;
                    break;
            }
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

        private bool controllaModificato()
        {
            bool annulla = false;
            if (filemanager.Modificato)
            {
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
    }
}
