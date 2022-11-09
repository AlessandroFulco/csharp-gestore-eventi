public class ProgrammaEvento
{
    //proprietà
    public string Titolo { get; set; }
    List<Evento> eventi { get; set; }

    //costruttore
    public ProgrammaEvento(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }

    //metodi
    public void AggingiEventoLista(Evento evento)
    {

        //algoritmo
        
    }

    public List<Evento> ListaEventi(DateOnly data)
    {
        List<Evento> lista = new List<Evento>();

        //algoritmo

        return lista;
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
    
