using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.IO;
using System.Windows.Forms;

namespace clsFile_ns
{
    class clsFile
    {
        private string filename;
        private bool modificato;

        public string Filename
        {
            get{return filename;}
            set{filename = value;}
        }
        public bool Modificato
        {
            get{return modificato;}
            set{modificato = value;}
        }

        public clsFile()
        {
            this.Filename = "";
            this.Modificato = false;
        }

        public void salvaConNome(RichTextBox rtb)
        {
            SaveFileDialog dlgSalva = new SaveFileDialog();
            dlgSalva.Filter = "Documento WordPad (*.rft;*.rft)|*.rft;*.rft|" +
                "Documento Office (*.docx;*.docx)|*.docx;*.docx|"
                + "Tutti i file (*.*)|*.*";
            dlgSalva.Title = "WordPad - Salva";
            DialogResult ris;
            ris = dlgSalva.ShowDialog();
            if (ris == DialogResult.OK)
            {
                Filename = dlgSalva.FileName;
                rtb.SaveFile(filename);
            }
        }

        public void salva(RichTextBox rtb)
        {
            if (modificato)
            {
                if (filename == "")
                    salvaConNome(rtb);
                else
                    rtb.SaveFile(filename);
            }
        }

        public string getFileNameRelativo()
        {
            string s = "";
            if (filename != "")
            {
                int pos = Filename.LastIndexOf('\\');
                s = Filename.Substring(pos + 1);
            }
            else
                s = "Documento";
            return s;
        }

        public string getFileName()
        {
            string s = "";
            if (filename != "")
            {
                s = Filename;
            }
            else
                s = "senza nome";
            return s;
        }
    }
}
