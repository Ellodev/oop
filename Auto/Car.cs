using System.Security.Cryptography;
using System.Windows;

namespace Auto;

public class Car
{
    internal int PS { get; }
    int AktuelleGeschwindigkeit { get; set; }
    private int AktuellerGang { get; set; }
    bool IstMotorGestartet { get; set; }
    private string Marke { get; set; }
    int TankFuellstand { get; set; }

    internal Car(string marke, int ps)
    {
        Marke = marke;
        PS = ps;
    }

    internal void Auftanken()
    {
        if (!IstMotorGestartet)
        {
            TankFuellstand = 100;
            Console.Write("getankt");
        }
    }

    internal void Bremse()
    {
        AktuelleGeschwindigkeit = AktuelleGeschwindigkeit - 10;
    }

    internal void GibGas()
    {
        if (IstMotorGestartet && AktuelleGeschwindigkeit < 50 + PS / 4)
        {
            AktuelleGeschwindigkeit += PS / 10;
            TankFuellstand = TankFuellstand - AktuelleGeschwindigkeit * PS / 1000;
        }

        if (TankFuellstand < 0)
        {
            IstMotorGestartet = false;
            Console.WriteLine("Motor aus.");
        }
    }

    internal void Hupe()
    {
        // TODO: Add sound
    }

    internal void SchalteMotorAus()
    {
        IstMotorGestartet = false;
    }

    internal void StarteMotor()
    {
        if (TankFuellstand > 0)
        {
            IstMotorGestartet = true;
            Console.WriteLine(IstMotorGestartet);
        }
        else
        {
            MessageBox.Show("Du musst zuerst das Auto tanken", "Error");
        }
    }
    public override string ToString()
    {
        return Marke;
    }

    public int GetAktuelleGeschwindigkeit()
    {
        return AktuelleGeschwindigkeit;
    }

    public int GetTankFuellstand()
    {
        return TankFuellstand;
    }

    public bool GetMotorState()
    {
        return IstMotorGestartet;
    }

    public int GetAktuellerGang()
    {
        return AktuellerGang;
    }
    
}