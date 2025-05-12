void generoCarta(int tentativi, List<string> valori, List<string> seme,List<string> mano)
{
    mano.Clear();
    Random rdn = new Random();
    for (int i = 0; i < tentativi + 1; i++)
    {
        string carta = valori[rdn.Next(0, 14)];
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
List<string> valori = new List<string>(["1", "2","3","4","5","6","7","8","9","y","J","Q","K","A"]);
List<string> seme = new List<string>(["Picche", "Fiori", "Quadri", "Cuori"]);
List<string> mano = new List<string>();
bool chiudi = true;
int tentativi = 1;
Random rdn=new Random();
while (chiudi!=false)
{   
    
    generoCarta(tentativi,valori, seme, mano);
    bool indovinato = indovina(mano,valori,seme);
    Console.WriteLine("Le carte erano:");
    foreach(string s in mano)
    {
        if (s == (mano.Count-1).ToString())
        {
            Console.Write(s);
        }
        else
        {
            Console.Write(s + " | ");
        }
    }
    Console.WriteLine();
    if (indovinato == true)
    {
        Console.WriteLine("Hai indovinato!!!");
        tentativi++;
    }
    else
    {
        Console.WriteLine("Mi dispiace non hai indovinato");
        tentativi = 1;
    }
    
}
