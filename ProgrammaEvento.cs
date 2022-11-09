using csharp_gestore_eventi.Errori;
public class ProgrammaEvento
{
    //proprietà
    public string Titolo { get; set; }
    List<Evento> Eventi { get; set; }

    //costruttore
    public ProgrammaEvento(string titolo)
    {
        Titolo = titolo;
        Eventi = new List<Evento>();
    }

    //metodi
    public void AggingiEvento(Evento ev)
    {
        Evento evento = ev;

        Eventi.Add(evento);
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

    public static void StampaLista(List<Evento> lista)
    {
        //algoritmo
    }

    public int ContatoreEventi()
    {
        int contatore = 0;

        //algoritmo

        return contatore;
    }

    public void SvuotaLista()
    {
        //algoritmo
    }

    public string StampaProgramma()
    {
        //algoritmo
        return " ";
    }
    

    //fine classe
}
    
