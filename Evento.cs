using csharp_gestore_eventi.Errori;

public class Evento
{
    public int Prenotazioni { get; private set; }
    public string Titolo
    {
        get { return Titolo; }

        set
        {
            if(Titolo == "")
            {
                throw new GestoreEventiException("Devi inserire il titolo dell'evento");
            }
            
            Titolo = value;
        }
    }
    public DateOnly Data
    {
        get { return Data; }

        set
        {
            if(Data < new DateOnly())
            {
                throw new GestoreEventiException("La data non puo essere precente a quella di oggi");
            }

            Data = value;
        }
    }
    public int Capienza
    {
        get { return Capienza; }

        private set
        {
            if(value < 0)
            {
                throw new GestoreEventiException("La capienza massima deve essere un numero positivo");
            }

            Capienza = value;
        }
    }

    public Evento(string titolo, DateOnly data, int capienza)
    {
        Prenotazioni = 0;
        Titolo = titolo;
        Data = data;
        Capienza= capienza;
    }



    public string PrenotaPosti(int prenotazione)
    {
       

        DateOnly actualDate = new DateOnly();
        if(actualDate < Data)
        {
            throw new GestoreEventiException("L'evento è già passato");
        }

        if(Prenotazioni >= Capienza)
        {
            throw new GestoreEventiException("L'evento non ha posti disponibili");
        }

        Prenotazioni++;



        return "Prenotazione avvenuta con successo";
    }


    //fine classe
}
