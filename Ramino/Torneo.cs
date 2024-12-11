namespace Ramino
{
    public class Torneo
    {
        private Giocatore[] _giocatori;

        public Torneo(int numeroGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[numeroGiocatori];
            for (int i = 1; i <= numeroGiocatori; i++)
            {
                _giocatori[i - 1] = new Giocatore(i.ToString(), numeroPartite);
            }
        }

        public Torneo(string[] nomiGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[nomiGiocatori.Length];
            int i = 0;
            foreach (string nome in nomiGiocatori)
            {
                _giocatori[i] = new Giocatore(nome, numeroPartite);
                i += 1;
            }
        }

        public string[] vincita()
        {
            int max = 0;
            int numPlayer = 1;
            for (int i = 0; i < _giocatori.Length; i++)
            {
                if (_giocatori[i].PunteggioMassimo > max)
                {
                    max = _giocatori[i].PunteggioMassimo;
                    numPlayer = 1;
                }
                else if (_giocatori[i].PunteggioMassimo == max)
                {
                    numPlayer++;
                }
            }

            string[] risultato = new string[numPlayer];
            int counter = 0;

            for (int i = 0; i < _giocatori.Length; i++)
            {
                if (_giocatori[i].PunteggioMassimo == max)
                {
                    risultato[counter] = _giocatori[i].Nome;
                    counter++;
                }
            }

            return risultato;
        }

        public void punteggioGiocatoreInPartita(int posizioneGiocatore, int punteggio, int numeroPartita)
        {
            if (posizioneGiocatore > _giocatori.Length || posizioneGiocatore <= 0) throw new ArgumentOutOfRangeException("Il valore posizione giocatore non è valido");

            _giocatori[posizioneGiocatore - 1].MemorizzaPunteggioPartita(punteggio, numeroPartita);

        }

        public int? cercaPunteggioGiocatore(int posizioneGiocatore, int punteggio)
        {
            if (posizioneGiocatore > _giocatori.Length || posizioneGiocatore <= 0) throw new ArgumentOutOfRangeException("Il valore posizione giocatore non è valido");
            return _giocatori[posizioneGiocatore - 1].RicercaPartitaPerPunteggio(punteggio);
        }

    }
}
