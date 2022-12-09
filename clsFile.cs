using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.IO;
using System.Windows.Forms; //per le finestre di dialogo

namespace clsFile_ns
{
    class clsFile
    {
        //campi privati
        private string filename;
        private bool modificato;
        //property
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        public bool Modificato
        {
            get
            {
                return modificato;
            }
            set
            {
                modificato = value;
            }
        }
        //costruttore/i
        public clsFile()
        {
            this.Filename = "";
            this.Modificato = false;
        }
        //metodi privati
        private string leggiFile()
        {
            string testo = "";
            if (filename != "")
            {
                StreamReader sr = new StreamReader(filename);
                testo = sr.ReadToEnd();
                sr.Close();
                modificato = false;
            }
            return testo;
        }
        private void scriviFile(string testo)
        {
            if (filename != "")
            {
                StreamWriter sw = new StreamWriter(filename, false);
                sw.Write(testo);
                sw.Close();
                modificato = false;
            }
        }
        //metodi pubblici
        public string apri()
        {
            string testo = "";
            OpenFileDialog dlgApri = new OpenFileDialog();
            dlgApri.Filter = "Pagina HTML (*.html;*.htm)|*.html;*.htm|" +
                "Tutti i file (*.*)|*.*";
            dlgApri.Title = "EditorHTML - Apri";
            dlgApri.InitialDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);
            DialogResult ris;
            ris = dlgApri.ShowDialog();
            if (ris == DialogResult.OK)
            {
                Filename = dlgApri.FileName;
                testo = leggiFile();
            }
            return testo;
        }
        public void salvaConNome(string testo)
        {
            SaveFileDialog dlgSalva = new SaveFileDialog();
            dlgSalva.Filter = "Pagina HTML (*.html;*.htm)|*.html;*.htm|" +
                "Tutti i file (*.*)|*.*";
            dlgSalva.Title = "EditorHTML - Salva";
            DialogResult ris;
            ris = dlgSalva.ShowDialog();
            if (ris == DialogResult.OK)
            {
                Filename = dlgSalva.FileName;
                scriviFile(testo);
            }
        }
        public void salva(string testo)
        {
            if (modificato)
                if (filename != "")
                    scriviFile(testo);
                else
                    salvaConNome(testo);
        }
        public string getFileNameRelativo()
        {
            //ritorna nome file + estensione
            string s = "";
            if (filename != "")
            {
                //s = Path.GetFileName(Filename);
                //
                //oppure
                //c:\\desktop\\pippo.html
                int pos = Filename.LastIndexOf('\\');
                s = Filename.Substring(pos + 1);
            }
            else
                s = "senza nome";
            return s;
        }
        public string getFileName()
        {
            //ritorna il percorso completo
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
