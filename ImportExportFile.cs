using csharp_gestore_eventi.Errori;

public class ImportExportFile
{
    public static void EsportaDati(List<Evento> eventi)
    {
        try
        {
            string path = "C:\\Users\\aless\\Documents\\.NET\\Lezione 10 09- 11-2022\\pomeriggio\\csharp-gestore-eventi\\programmaEventi.csv";
            if (File.Exists(path))
                File.Delete(path);

            StreamWriter file = File.CreateText(path);

            file.WriteLine("data;titolo;relatore;prezzo;capienza massima;posti prenotati");
            foreach (Evento evento in eventi)
            {
                string ev = evento.ToCsv();


                if (evento.GetType().ToString() == "Evento")
                {
                    ev += ";null;0";
                }
                ev += ";" + evento.Capienza + ";" + evento.Prenotazioni;

                file.WriteLine(ev);
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public static List<Evento> ImportaDati()
    {
        List<Evento> eventi = new List<Evento>();
        
        string path = "C:\\Users\\aless\\Documents\\.NET\\Lezione 10 09- 11-2022\\pomeriggio\\csharp-gestore-eventi\\programmaEventi.csv";
        StreamReader file = File.OpenText(path);
        file.ReadLine();

        while (!file.EndOfStream)
        {
            try
            {

                string riga = file.ReadLine();

                string[] info = riga.Split(";");

                if (info[2] == "null")
                {
                    DateOnly data = DateOnly.Parse(info[0]);
                    string titolo = info[1];
                    int capienza = Convert.ToInt32(info[4]);
                    int prenotazioni = Convert.ToInt32(info[5]);
                    Evento evento = new Evento(titolo, data, capienza);
                    evento.PrenotaPosti(prenotazioni);
                    eventi.Add(evento);
                }
                else
                {
                    DateOnly data = DateOnly.Parse(info[0]);
                    string titolo = info[1];
                    string relatore = info[2];
                    double prezzo = Convert.ToDouble(info[3]);
                    int capienza = Convert.ToInt32(info[4]);
                    int prenotazioni = Convert.ToInt32(info[5]);
                    Conferenza conferenza = new Conferenza(relatore, prezzo, titolo, data, capienza);
                    conferenza.PrenotaPosti(prenotazioni);
                    eventi.Add(conferenza);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        file.Close();
        return eventi;
    }
}