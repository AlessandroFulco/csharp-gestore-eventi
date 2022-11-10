using csharp_gestore_eventi.Errori;


Console.WriteLine("Benventuo nel programma");
Console.WriteLine();

bool continua = true;
while (continua)
{
    Console.WriteLine();
    Console.WriteLine("Scegli la voce di menu'");
    Console.WriteLine();
    Console.WriteLine("1. Milestone 1 - 3");
    Console.WriteLine("2. Milestone 4");
    Console.WriteLine("3. Esci");
    Console.WriteLine();


    Console.Write("Inserisci il numero: ");
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
                Console.WriteLine(e.Message);
            }
            break;

        case 2:
            Console.WriteLine();
            string inputNome = "";
            try
            {
                
                Console.Write("Inserisci il nome del programma eventi: ");
                inputNome = Console.ReadLine();

                ProgrammaEvento pe = new ProgrammaEvento(inputNome);

                Console.Write("Indica il numero di eventi da inserire: ");
                int sceltaQtyEventi = Convert.ToInt32(Console.ReadLine());
                //TODO: Controllare stringa vuota
                if(sceltaQtyEventi == 0)
                {
                    throw new GestoreEventiException("Devi inserire almeno un evento!");
                }
                int contatore = 0;
                bool continua2 = true;
                while (continua2)
                {
                    Console.WriteLine();
                    //crea nuovo evento
                    Console.Write("Inserisci il Titolo del " + (contatore + 1) + "° evento: ");
                    string nome2 = Console.ReadLine();

                    Console.Write("Inserisci la data: ");
                    string dataInput2 = Console.ReadLine();
                    DateOnly data2 = DateOnly.Parse(dataInput2);

                    Console.Write("Inserisci la capienza massima: ");
                    int capienza2 = Convert.ToInt32(Console.ReadLine());

                    Evento ev = null;
                    try
                    {
                        ev = new Evento(nome2, data2, capienza2);
                        if (pe.AggingiEvento(ev))
                            contatore++;
                    }
                    catch (GestoreEventiException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    
                    //uscita dal ciclo while per la richiesta degli eventi
                    if (contatore == sceltaQtyEventi)
                        continua2 = false;
                    Console.WriteLine();
                }

                Console.WriteLine(pe.ContatoreEventi());
                Console.WriteLine(pe.StampaProgramma());

                Console.Write("Inserisci la data in cui vuoi sapere che eventi ci sono: ");
                string dataInput3 = Console.ReadLine();
                DateOnly data3 = DateOnly.Parse(dataInput3); 

                Console.WriteLine(ProgrammaEvento.StampaLista(pe.ListaEventi(data3)));

                //Console.WriteLine("Premere invio per eliminare tutti gli eventi dal programma");
                //Console.ReadLine();
                //Console.WriteLine(pe.SvuotaLista());

                //crea nuova Conferenza
                Console.Write("Inserisci il nome della conferenza: ");
                string nomeConferenza = Console.ReadLine();

                Console.Write("Inserisci la data: ");
                string dataInputConferenza = Console.ReadLine();
                DateOnly dataConferenza = DateOnly.Parse(dataInputConferenza);

                Console.Write("Inserisci la capienza massima: ");
                int capienzaConferenza = Convert.ToInt32(Console.ReadLine());

                Console.Write("Inserisci il nome del relatore: ");
                string relatoreConferenza = Console.ReadLine();

                Console.WriteLine("Inserisci il prezzo del biglietto della conferenza: ");
                double costoConferenza = Convert.ToDouble(Console.ReadLine());
                
                Conferenza conferenza = new Conferenza(relatoreConferenza, costoConferenza, nomeConferenza, dataConferenza, capienzaConferenza);

                Console.WriteLine();

                Console.WriteLine(conferenza.ToString());
            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Premere invio per tornare al menu' principale");
            Console.ReadLine();
            Console.Clear();
            break;

        case 3:
            //esci dal programma
            continua = false;
            break;

        default:
            Console.WriteLine("Opzione non esistente");
            break;
    }
}
