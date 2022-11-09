using csharp_gestore_eventi.Errori;

public class Evento
{
    //attributi
    private string _titolo;
    private DateOnly _data;
    private int _capienza;

    //Proprietà
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

            if (value < DateOnly.FromDateTime(DateTime.Now))
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
            if (value <= 0)
            {
                throw new GestoreEventiException("La capienza massima deve essere un numero positivo");
            }

            _capienza = value;
        }
    }

    //costruttore
    public Evento(string titolo, DateOnly data, int capienza)
    {
        Titolo = titolo;
        Data = data;
        Capienza= capienza;
        Prenotazioni = 0;
    }

    //metodi
    public void PrenotaPosti(int numero)
    {
        if(DateOnly.FromDateTime(DateTime.Now) > Data)
        {
            throw new GestoreEventiException("L'evento è già passato");
        }

        if(Capienza < Prenotazioni + numero)
        {
            throw new GestoreEventiException("L'evento non ha posti disponibili");
        }

        Prenotazioni += numero;
        Capienza -= numero;
    }

    public void DisdiciPosti(int numero)
    {
        if (DateOnly.FromDateTime(DateTime.Now) > Data)
        {
            throw new GestoreEventiException("L'evento è già passato");
        }

        Prenotazioni -= numero;
        Capienza += numero;
    }

    public override string ToString()
    {
        string DataFormattata = Data.ToString("dd/MM/yyyy");
        return "L'evento in data:\t" + DataFormattata + "\t titolo:\t" + Titolo;
    }

    public string StampaCapienzaPrenotazioni()
    {
        return "Numero di posti prenotati = "+ Prenotazioni +"\nNumero di posti disponibili = " + Capienza ;
    }

    //fine classe
}