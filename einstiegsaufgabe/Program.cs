namespace einstiegsaufgabe;

class Program
{
    static void Main(string[] args)
    {
        string[] marke = { "Audi", "Porsche", "Opel" };
        string[] farbe = { "Blau", "Gelb", "Rot" };
        int[] geschwindigkeit = { 280, 300, 220 };

        for (int i = 0; i < geschwindigkeit.Length; i++)
        {
            Console.WriteLine($"Das Auto ist von der Marke: {marke[i]}, hat die Farbe: {farbe[i]} und hat eine max-geschwindigkeit von: {geschwindigkeit[i]}");
        }
    }
}