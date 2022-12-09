using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Es06_EditorHTML
{
    class clsStampa
    {
        //oggetto principale per la gestione della classe
        private PrintDocument prn = new PrintDocument();
        //finestre di dialogo per la configurazione
        //dell'oggetto printDialog
        private PageSetupDialog dlgSetup = new PageSetupDialog();
        private PrintDialog dlgStampa=new PrintDialog();
        private PrintPreviewDialog dlgAnteprima=new PrintPreviewDialog();
        //
        private string userText;
        private Font userFont;
        //costruttore
        public clsStampa()
        {
            //parametri di default
            //1 unit = 1/100 di pollice = 0,254 mm
            prn.DefaultPageSettings.Margins.Left = 79;//79*0,254=20 mm
            prn.DefaultPageSettings.Margins.Right = 79;
            prn.DefaultPageSettings.Margins.Top = 100;
            prn.DefaultPageSettings.Margins.Bottom = 100;
            prn.PrinterSettings.Copies = 1;
            //collego le finestre di dialogo all'oggetto
            //principale PrintDocument
            dlgSetup.Document = prn;
            dlgAnteprima.Document = prn;
            dlgStampa.Document=prn;
            dlgSetup.EnableMetric = true;
            //
            prn.PrintPage += new PrintPageEventHandler(prn_printPage);
        }

        private void prn_printPage(object sender, PrintPageEventArgs e)
        {
            //Questo evento viene richiamato in corrispondenza:
            //-metodo prn.Print()
            //-Ok sull'anteprima di stampa
            //
            //la pagina di stampa è vista come un oggetto grafico sul quale 
            //posso agire con le GDI+
            SolidBrush b = new SolidBrush(Color.Black);
            int x = prn.DefaultPageSettings.Margins.Left;
            int y = prn.DefaultPageSettings.Margins.Top;
            int w = prn.DefaultPageSettings.PaperSize.Width;
            int h = prn.DefaultPageSettings.PaperSize.Height;
            Rectangle rec = new Rectangle(x, y, w, h);
            //metodo che esegue fisicamente la stampa
            e.Graphics.DrawString(userText,userFont,b,rec); //non disegna il rettangolo
            //per disegnare il rettangolo
            Pen penna = new Pen(Color.Red, 10);
            e.Graphics.DrawRectangle(penna, rec);
        }
        //metodi pubblici
        public void impostaPagina()
        {
            dlgSetup.ShowDialog();
            //In corrispondenza dell'ok i valori
            //impostati vengono automaticamente copiati dentro prn
        }
        public void anteprima(string testo,Font carattere)
        {
            this.userText = testo;
            this.userFont = carattere;
            dlgAnteprima.ShowDialog();
        }
        public void stampa(string testo,Font carattere)
        {
            this.userText = testo;
            this.userFont = carattere;
            //l'utente può decidere se stampare o annullare
            DialogResult ris;
            ris = dlgAnteprima.ShowDialog();
            if (ris == DialogResult.OK)
                prn.Print();
        }
    }
}
