using csharp_gestore_eventi.Errori;
public class ProgrammaEvento
{
    private string _titolo;
    //proprietà
    public string Titolo
    {
        get { return _titolo; }

        set
        {
            if (value == "" || value == null)
            {
                throw new GestoreEventiException("Devi inserire il titolo del programma eventi");
            }
            _titolo = value;
        }
    }
    List<Evento> Eventi { get; set; }

    //costruttore
    public ProgrammaEvento(string titolo)
    {
        Titolo = titolo;
        Eventi = new List<Evento>();
    }

    //metodi

    public List<Evento> ListaEventi()
    {
        return Eventi;
    }
    public bool AggingiEvento(Evento ev)
    {
        Evento evento = ev;
        if (evento.Data < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new GestoreEventiException("La data non può essere precedente a quella di oggi");
        }

        if (evento == null)
        {
            throw new GestoreEventiException("Devi inserire l'evento per poter andare avanti");
        }

        Eventi.Add(evento);
        return true;
    }

    public List<Evento> ListaEventi(DateOnly data)
    {
        List<Evento> result = new List<Evento>();


        foreach(Evento ev in Eventi)
        {
            if(ev.Data == data)
            {
                result.Add(ev);
            }
        }
        
        if(result.Count <= 0)
        {
            throw new GestoreEventiException("Non ci sono eventi in quella data");
        }
        
        return result;
    }

    //da testare
    public static string StampaLista(List<Evento> eventi)
    {
        List<Evento> lista = eventi;
        string result = "";
        foreach(Evento ev in lista)
        {
            result += "Titolo:\t" + ev.Titolo + ",\tdata:\t" + ev.Data + ",\tcapienza:\t" + ev.Capienza + ",\tposti prenotati:\t" + ev.Prenotazioni +"\n";
        }
            return result;

    }

    public string ContatoreEventi()
    {
        int contatore = 0;

        //foreach(Evento ev in Eventi)
        //{
        //    contatore++;
        //}

        contatore = Eventi.Count;

        return "Il numero di eventi nel programma è: " + contatore;
    }

    public string SvuotaLista()
    {
        Eventi = new List<Evento>();
        return "Gli eventi sono stati cancellati con successo";
    }

    public string StampaProgramma()
    {
        string result = "Nome programma evento: " + Titolo + "\n";

        foreach(Evento ev in Eventi)
        {
            result +=  "\t" + ev.ToString() + "\n";
        }

        return result;
    }
    

    //fine classe
}
    
