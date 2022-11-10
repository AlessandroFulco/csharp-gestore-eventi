using csharp_gestore_eventi.Errori;

public class ImportExportFile
{
    public static void EsportaDati(List<Evento> eventi)
    {
        string path = "C:\\Users\\aless\\Documents\\.NET\\Lezione 10 09- 11-2022\\pomeriggio\\csharp-gestore-eventi\\programmaEventi.csv";
        if (File.Exists(path))
            File.Delete(path);

        StreamWriter file = File.CreateText(path);

        file.WriteLine("data,titolo,relatore,prezzo,capienza massima,posti prenotati");
        foreach (Evento evento in eventi)
        {
            string ev = evento.ToString();
            ev = ev.Replace(" - ", ",");


            if(evento.GetType().ToString() == "Evento")
            {
                ev += ",null,0";
            }
            ev += "," + evento.Capienza + "," + evento.Prenotazioni;

            file.WriteLine(ev);
        }
        file.Close();
    }
}