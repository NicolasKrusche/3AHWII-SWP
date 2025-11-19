class Bruch
{
    private int ganz;
    private int zaehler;
    private int nenner;

    public Bruch(string bruchtext)
    {
        if (string.IsNullOrWhiteSpace(bruchtext))
            throw new ArgumentException("Bruchtext darf nicht leer sein.");

        string[] teile1 = bruchtext.Split(' ');
        if (teile1.Length != 2)
            throw new FormatException($"Format muss 'Ganzzahl Zähler/Nenner' sein, z.B. '1 1/2', erhalten: '{bruchtext}'");

        if (!int.TryParse(teile1[0], out this.ganz))
            throw new FormatException($"Ganzzahl '{teile1[0]}' ist keine gültige Ganzzahl");

        string[] teile = teile1[1].Split('/');
        if (teile.Length != 2)
            throw new FormatException($"Bruch muss im Format 'Zähler/Nenner' sein, z.B. '1/2', erhalten: '{teile1[1]}'");

        if (!int.TryParse(teile[0], out this.zaehler))
            throw new FormatException($"Zähler '{teile[0]}' ist keine gültige Ganzzahl");

        if (!int.TryParse(teile[1], out this.nenner))
            throw new FormatException($"Nenner '{teile[1]}' ist keine gültige Ganzzahl");

        if (this.nenner == 0)
            throw new ArgumentException("Nenner darf nicht 0 sein");

        this.kurzeBruch();
    }

    public Bruch(int ganz, int zaehler, int nenner)
    {
        if (nenner == 0)
            throw new ArgumentException("Nenner darf nicht 0 sein");

        this.ganz = ganz;
        this.zaehler = zaehler;
        this.nenner = nenner;

        this.kurzeBruch();
    }

    private void kurzeBruch()
    {
        int ggt = GGT(this.zaehler, this.nenner);

        this.zaehler /= ggt;
        this.nenner /= ggt;

        if (this.zaehler >= this.nenner)
        {
            this.ganz += this.zaehler / this.nenner;
            this.zaehler = this.zaehler % this.nenner;
        }
    }

    private int GGT(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public Bruch addiere(Bruch b)
    {
        int gemeinsamerNenner = this.nenner * b.nenner;
        int neuerZaehler = (this.zaehler * b.nenner) + (b.zaehler * this.nenner);
        int neuerGanz = this.ganz + b.ganz + neuerZaehler / gemeinsamerNenner;
        int neuerBruchZaehler = neuerZaehler % gemeinsamerNenner;

        int ggt = GGT(neuerBruchZaehler, gemeinsamerNenner);
        neuerBruchZaehler /= ggt;
        gemeinsamerNenner /= ggt;

        return new Bruch(neuerGanz, neuerBruchZaehler, gemeinsamerNenner);
    }

    public override string ToString()
    {
        if (this.zaehler == 0)
        {
            return $"{this.ganz}";
        }
        else
        {
            return $"{this.ganz} {this.zaehler}/{this.nenner}";
        }
    }
}