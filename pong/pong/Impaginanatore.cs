using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pong
{
    class Impaginanatore
    {
        private int nr, nc;

        public Impaginanatore(int numero_righe, int numero_colonne)
        {
            nr=numero_righe;
            nc=numero_colonne;
        }
        
        public void testo_a_sinistra(int riga, int margine, String testo)
        {
            if (controllo_rige(riga) && controllo_colonne(margine, testo.Length))
            {
                Console.SetCursorPosition(margine, riga);
                Console.Write(testo);
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("errore nella stampa della riga " + riga);
            }
        }

        public void testo_a_destra(int riga, int margine, String testo)
        {
            if (controllo_rige(riga) && controllo_colonne(margine, testo.Length))
            {
                Console.SetCursorPosition((nc - (testo.Length + margine)), riga);
                Console.Write(testo);
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("errore nella stampa della riga " + riga);
            }
        }

        public void testo_al_centro(int riga, String testo)
        {
            if (controllo_rige(riga) && controllo_colonne(0, testo.Length))
            {
                Console.SetCursorPosition(((nc - testo.Length) / 2), riga);
                Console.Write(testo);
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("errore nella stampa della riga " + riga);
            }
        }

        private bool controllo_rige(int r)
        {
            if(r >= 0 && r < nr)
                return true;
            else
                return false;
        }
        private bool controllo_colonne(int c, int lungezza)
        {
            if(c >= 0 && lungezza+c < nc)
                return true;
            else
                return false;
        }
    }
}
