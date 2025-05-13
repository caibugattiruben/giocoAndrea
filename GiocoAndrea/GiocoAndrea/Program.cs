void generoCarta(int tentativi, List<string> valori, List<string> seme,List<string> mano)
{
    mano.Clear();
    Random rdn = new Random();
    for (int i = 0; i < tentativi + 1; i++)
    {
        string carta = valori[rdn.Next(0, 13)];
        carta += ","+seme[rdn.Next(0, 4)];
        if (!mano.Contains(carta))
        {
            mano.Add(carta);
        }
        carta = "";
    }
}
bool indovina(List<string> mano,List<string> valori,List<string> seme)
{
    string[] mano1=mano.ToArray();
    Console.WriteLine("Scegli una carta, le carte sono "+mano1.Length);
    int risposta = int.Parse(Console.ReadLine());
    risposta--;
    string[] carta = mano1[0].Split(',');
    string max = carta[0];
    string max1 = carta[1];
    foreach (string s in mano1)
    {
        if(s.Length > 0)
        {
            string[] carta1 = s.Split(',');
            string maxC = carta1[0];
            string max1S = carta1[1];
            if(valori.IndexOf(maxC)> valori.IndexOf(max))
            {
                max = maxC;
                max1 = max1S;
            }
            else if(valori.IndexOf(maxC) == valori.IndexOf(max) && seme.IndexOf(max1S) > seme.IndexOf(max1))
            {
                max1 = max1S;
            }
        }
    }
    if (mano1[risposta] == max + "," + max1)
    {
        return true;
    }
    return false;
}
List<string> valori = new List<string>(["2","3","4","5","6","7","8","9","y","J","Q","K","A"]);
List<string> seme = new List<string>(["Picche", "Fiori", "Quadri", "Cuori"]);
List<string> mano = new List<string>();
bool chiudi = true;
int tentativi = 1,giro=2;
Random rdn=new Random();
while (chiudi!=false)
{      
    generoCarta(tentativi,valori, seme, mano);
    bool indovinato = indovina(mano,valori,seme);
    if (indovinato == true)
    {
        Console.WriteLine("Hai indovinato!!!");
        tentativi++;
        giro++;
    }
    else
    {
        Console.WriteLine("Mi dispiace non hai indovinato");
        tentativi = 1;
        giro = 2;
    }
    Console.WriteLine("Le carte erano:");
    foreach (string s in mano)
    {
        if (mano.IndexOf(s) == mano.Count-1)
        {
            if (s[0] == 'y')
            {
                Console.Write("10 ");
            }
            else
            {
                Console.Write(s[0]+" ");
            }
            Console.Write(s[2]);
        }
        else
        {
            if (s[0] == 'y')
            {
                Console.Write("10 ");
            }
            else
            {
                Console.Write(s[0]+" ");
            }
            Console.Write(s[2]+" | ");
        }
    }
    Console.WriteLine();
    if (giro == 52)
    {
        chiudi = false;
        Console.WriteLine("COMPLIMENTI HAI VINTO IL GIOCO");
    }
    if (indovinato == false)
    {
        Console.WriteLine("hai perso vuoi chiudere si o no");
        string risp = Console.ReadLine();
        if (risp == "si")
        {
            chiudi = false;
        }
        else
        {
            Console.WriteLine("Ok allora buona fortuna");
        }
        
    }
}