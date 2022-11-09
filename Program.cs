using csharp_gestore_eventi.Errori;



//Console.WriteLine("Creazione evento");





Console.WriteLine("Benventuo nel programma");
Console.WriteLine();

bool continua = true;
while (continua)
{
    Console.WriteLine();
    Console.WriteLine("Scegli la voce di menu'");
    Console.WriteLine();
    Console.WriteLine("1. Crea nuovo evento");
    Console.WriteLine();

    int sceltaUtente = Convert.ToInt32(Console.ReadLine());

    switch (sceltaUtente)
    {
        case 1:
            //crea nuovo evento
            Console.Write("Inserisci il Titolo dell'evento: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci la data: ");
            string dataInput = Console.ReadLine();
            DateOnly data = DateOnly.Parse(dataInput);

            Console.Write("Inserisci la capienza massima: ");
            int capienza = Convert.ToInt32(Console.ReadLine());
            try
            {
                Evento evento = new Evento(nome, data, capienza);

                //TODO: gestire eccezioni
                Console.WriteLine("Quanti posti desideri prenotare?");
                int inputUtente = Convert.ToInt32(Console.ReadLine());
                evento.PrenotaPosti(inputUtente);
                Console.WriteLine(evento.StampaCapienzaPrenotazioni());

                Console.WriteLine();
                

                bool disdire = true;
                while (disdire)
                {
                    Console.WriteLine("Vuoi disdire dei posti (si/no)? ");
                    string scelta = Console.ReadLine();
                    if (scelta == "si")
                    {
                        Console.WriteLine("Indica il numero dei posti che vuoi disdire: ");
                        int inputDisdirePosti = Convert.ToInt32(Console.ReadLine());

                        evento.DisdiciPosti(inputDisdirePosti);
                        Console.WriteLine(evento.StampaCapienzaPrenotazioni());
                    }
                    else
                    {
                        disdire = false;
                        Console.WriteLine();
                        Console.WriteLine("Ok va bene!");
                    }
                }
                Console.WriteLine();


                //Console.WriteLine(evento.ToString());
            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e);
            }

            
            

            break;

        case 2:
            //esci dal programma

            continua = false;
            break;

        default:
            Console.WriteLine("Opzione non esistente");
            break;
    }
}