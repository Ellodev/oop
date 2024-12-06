namespace Tannenbaum;

public class Tanne
{
    public int Stammbreite { get; set; }
    public int Stammhoehe { get; set; }
    public  int Kronehoehe { get; set; }
    public string Zeichnung { get; set; }

    public void Zeichne()
    {
        Zeichnung = string.Empty;

        // Krone
        for (int i = 1; i <= Kronehoehe; i++)
        {
            int spaces = Kronehoehe - i;
            Zeichnung += new string(' ', spaces);
            
            int stars = i * 2 - 1;
            Zeichnung += new string('*', stars);
            
            Zeichnung += "\n";
        }

        // Stamm
        for (int i = 1; i <= Stammhoehe; i++)
        {
            int spaces = (Kronehoehe * 2 - 1 - Stammbreite) / 2;
            Zeichnung += new string(' ', spaces);
            
            Zeichnung += new string('*', Stammbreite);
            
            Zeichnung += "\n";
        }
    }

}