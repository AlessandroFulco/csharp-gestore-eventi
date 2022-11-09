using csharp_gestore_eventi.Errori;

public class Evento
{
    private string _titolo;
    private DateOnly _data;
    private int _capienza;

    public int Prenotazioni { get; private set; }
    public string Titolo
    {
        get { return _titolo; }
        
        set
        {
            if (value == "")
            {
                throw new GestoreEventiException("Devi inserire il titolo dell'evento");
            }
            _titolo = value;
        }
    }
    public DateOnly Data
    {
        get { return _data; }

        set
        {

            if (_data < new DateOnly())
            {
                throw new GestoreEventiException("La data non puo essere precente a quella di oggi");
            }
            _data = value;
        }
    }
    public int Capienza
    {
        get { return _capienza; }

        private set
        {
            if (value < 0)
            {
                throw new GestoreEventiException("La capienza massima deve essere un numero positivo");
            }

            _capienza = value;
        }
    }

    public Evento(string titolo, DateOnly data, int capienza)
    {
        Titolo = titolo;
        Data = data;
        Capienza= capienza;
        Prenotazioni = 0;
    }



    public void PrenotaPosti(int prenotazione)
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
    }

    public void DisdiciPosti()
    {
        DateOnly actualDate = new DateOnly();
        if (actualDate < Data)
        {
            throw new GestoreEventiException("L'evento è già passato");
        }

        Prenotazioni--;
    }

    public override string ToString()
    {
        string DataFormattata = Data.ToString("dd/MM/yyyy");
        return "L'evento in data:\t" + DataFormattata + "\t, titolo:\t" + Titolo;
    }


    //fine classe
}
