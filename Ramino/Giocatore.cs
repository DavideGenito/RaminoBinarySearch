namespace Ramino
{
    public class Giocatore
    {
        public string Nome { get; set; }
        private int?[] _punteggi;


        public int NumeroPartite
        {
            get
            {
                return _punteggi.Length;
            }
        }

        public int PunteggioMassimo
        {
            get
            {
                if (_punteggi[NumeroPartite - 1] == null)
                {
                    throw new ArgumentException("Non hai finito le partite");
                }
                else
                {
                    return _punteggi[NumeroPartite - 1] ?? 0;
                }
            }
        }

        public Giocatore(string nome, int partite)
        {
            Nome = nome;
            _punteggi = new int?[partite];
        }

        public void MemorizzaPunteggioPartita(int punteggio, int partita)
        {
            if (punteggio < 0 || punteggio > 100) throw new ArgumentOutOfRangeException("punteggio errato");
            if (partita < 1 || partita > NumeroPartite) throw new ArgumentOutOfRangeException("numero partita errato");
            if (partita > 1 && _punteggi[partita - 2] == null) throw new ArgumentException($"non è possibile salvare il punteggio per la partita {partita} perchè non è ancora stato definito il punteggio della partita {partita - 1}");

            if (partita == 1)
                _punteggi[partita - 1] = punteggio;
            else
                _punteggi[partita - 1] = _punteggi[partita - 2] + punteggio;
        }

        public int? RicercaPartitaPerPunteggio(int punteggioDaCercare)
        {
            if (punteggioDaCercare < 0 || punteggioDaCercare > 100) throw new ArgumentOutOfRangeException("punteggio errato");
            int inizio = 0;
            int fine = NumeroPartite - 1;

            while (inizio <= fine)
            {
                int meta = (inizio + fine) / 2;

                if (_punteggi[meta] == punteggioDaCercare)
                {
                    return meta;
                }
                else if (_punteggi[meta] != null && _punteggi[meta] > punteggioDaCercare)
                {
                    fine = meta - 1;
                }
                else
                {
                    inizio = meta + 1;
                }
            }

            return null;
        }

    }
}
