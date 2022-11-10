using csharp_gestore_eventi.Errori;

public class Conferenza : Evento
{
    public Conferenza(string nome, double prezzo,string titolo, DateOnly data, int capienza) : base(titolo, data, capienza)
    {
        Relatore = nome;
        Prezzo = prezzo;
    }

    string _relatore;
    double _prezzo;
    public string Relatore
    {
        get { return _relatore; }

        set
        {
            if (value == "" || value == null)
            {
                throw new GestoreEventiException("Devi inserire il nome del relatore!");
            }
            _relatore = value;
        }
    }
    public double Prezzo
    {
        get { return _prezzo; }

        set
        {
            if (value <= 0)
            {
                throw new GestoreEventiException("Il prezzo deve essere maggiore di 0 euro");
            }

            _prezzo = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + " - " + Relatore + " - " + Prezzo.ToString("0.00") + " euro";
    }
}