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

                Console.Write("Quanti eventi vuoi inserire? ");
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
                    
                    //crea nuovo evento
                    Console.Write("Inserisci il Titolo dell'evento: ");
                    string nome2 = Console.ReadLine();

                    Console.Write("Inserisci la data: ");
                    string dataInput2 = Console.ReadLine();
                    DateOnly data2 = DateOnly.Parse(dataInput2);

                    Console.Write("Inserisci la capienza massima: ");
                    int capienza2 = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        Evento ev = new Evento(nome2, data2, capienza2);
                    }
                    catch (GestoreEventiException e)
                    {
                        Console.WriteLine(e.Message);
                    }




                    //uscita dal ciclo while per la richiesta degli eventi
                    contatore++;
                    if (contatore == sceltaQtyEventi)
                        continua2 = false;
                }

                

            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);
            }

            

            

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



////Stampa lista
//ProgrammaEvento pe = new ProgrammaEvento("programma 1");
//Evento ev = new Evento("prova", new DateOnly(2022, 11, 11), 200);
//Evento ev2 = new Evento("prova2", new DateOnly(2022, 11, 11), 200);
//pe.AggingiEvento(ev);
//pe.AggingiEvento(ev2);

//Console.WriteLine(ProgrammaEvento.StampaLista(pe.ListaEventi(new DateOnly(2022, 11, 11))));

////ContatoreEventi
//ProgrammaEvento pe = new ProgrammaEvento("programma 1");
//Evento ev = new Evento("prova", new DateOnly(2022, 11, 11), 200);
//Evento ev2 = new Evento("prova2", new DateOnly(2022, 11, 11), 200);
//pe.AggingiEvento(ev);
//pe.AggingiEvento(ev2);

//Console.WriteLine(pe.ContatoreEventi());


////Svuota Lista
//ProgrammaEvento pe = new ProgrammaEvento("programma 1");
//Evento ev = new Evento("prova", new DateOnly(2022, 11, 11), 200);
//Evento ev2 = new Evento("prova2", new DateOnly(2022, 11, 11), 200);
//pe.AggingiEvento(ev);
//pe.AggingiEvento(ev2);

//pe.SvuotaLista();


//ProgrammaEvento pe = new ProgrammaEvento("programma 1");
//Evento ev = new Evento("prova", new DateOnly(2022, 11, 11), 200);
//Evento ev2 = new Evento("prova2", new DateOnly(2022, 11, 11), 200);
//pe.AggingiEvento(ev);
//pe.AggingiEvento(ev2);

//Console.WriteLine(pe.StampaProgramma());


