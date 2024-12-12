using Ramino;
namespace RaminoMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroGiocatori = 4;
            int numeroPartite = 5;

            Torneo torneo = new Torneo(numeroGiocatori, numeroPartite);

            Random random = new Random();
            for (int i = 1; i <= numeroPartite; i++)
            {
                Console.WriteLine($"Partita {i}:");
                for (int giocatore = 1; giocatore <= numeroGiocatori; giocatore++)
                {
                    int punteggio = random.Next(0, 101);

                    torneo.punteggioGiocatoreInPartita(giocatore, punteggio, i);
                    Console.WriteLine($"Giocatore {giocatore}: {punteggio} punti");
                }
            }

            string[] vincitori = torneo.vincita();
            Console.WriteLine("\nVincitori del torneo:");
            foreach (string vincitore in vincitori)
            {
                Console.WriteLine(vincitore);
            }

            int punteggioDaVerificare = random.Next(0, 100*numeroPartite+1);
            Console.WriteLine($"\nPunteggio da verificare: {punteggioDaVerificare}");

            for (int i = 1; i <= numeroGiocatori; i++)
            {
                int? partita = torneo.cercaPunteggioGiocatore(i, punteggioDaVerificare);
                if (partita != null)
                {
                    Console.WriteLine($"Il Giocatore {i} ha ottenuto esattamente {punteggioDaVerificare} punti nella partita {partita + 1}");
                }
                else
                {
                    Console.WriteLine($"Il Giocatore {i} non ha mai ottenuto esattamente {punteggioDaVerificare} punti.");
                }
            }
        }
    }

}
