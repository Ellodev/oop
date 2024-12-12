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
    private int TankFuellstand { get; set; }

    internal Car(string marke, int ps)
    {
        Marke = marke;
        PS = ps;
    }

    internal void Auftanken()
    {
        for (int i = 0; i < 100; i++)
        {
            if (!IstMotorGestartet && TankFuellstand < 100)
            {
                TankFuellstand++;
            }
        }
    }

    internal void Bremse()
    {
        if (AktuelleGeschwindigkeit > 20)
        {
            AktuelleGeschwindigkeit = AktuelleGeschwindigkeit - (AktuelleGeschwindigkeit / 5);
        }
        else
        {
            AktuelleGeschwindigkeit = AktuelleGeschwindigkeit - 10;
        }
        if (AktuelleGeschwindigkeit < 0)
        {
            AktuelleGeschwindigkeit = 0;
        }
        GangSchalten();
    }

    internal void GibGas()
    {
        if (IstMotorGestartet && AktuelleGeschwindigkeit < 100 + PS / 3)
        {
            AktuelleGeschwindigkeit += PS / 10;
            TankFuellstand = TankFuellstand - AktuelleGeschwindigkeit * PS / 10000;
            GangSchalten();
        }

        if (TankFuellstand < 0)
        {
            IstMotorGestartet = false;
            Bremse();
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

    internal void GangSchalten()
    {
        if (AktuelleGeschwindigkeit < 10)
        {
            AktuellerGang = 1;
        }
        else if (AktuelleGeschwindigkeit >= 11 && AktuelleGeschwindigkeit < 21)
        {
            AktuellerGang = 2;
        }
        else if (AktuelleGeschwindigkeit >= 21 && AktuelleGeschwindigkeit < 41)
        {
            AktuellerGang = 3;
        }
        else if (AktuelleGeschwindigkeit >= 41 && AktuelleGeschwindigkeit < 71)
        {
            AktuellerGang = 4;
        }
        else if (AktuelleGeschwindigkeit >= 71 && AktuelleGeschwindigkeit < 101)
        {
            AktuellerGang = 5;
        }
        else if (AktuelleGeschwindigkeit > 101)
        {
            AktuellerGang = 6;
        }

    }
    
}