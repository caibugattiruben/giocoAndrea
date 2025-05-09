void generoCarta(int tentativi, List<string> valori, List<string> seme,List<string> mano)
{
    mano.Clear();
    Random rdn = new Random();
    for (int i = 0; i < tentativi + 1; i++)
    {
        string carta = valori[rdn.Next(0, 14)];
        carta += ","+seme[rdn.Next(0, 4)];
        mano.Add(carta);
        carta = "";
    }
    foreach(string s in mano)
    {
        Console.WriteLine(s);
    }
}
bool indovina(List<string> mano,List<string> valori,List<string> seme)
{
    string[] mano1=mano.ToArray();
    foreach(string s in mano1)
    {
        Console.WriteLine(s);
    }
    Console.WriteLine("Scegli una carta, le carte sono "+mano1.Length);
    int risposta = int.Parse(Console.ReadLine());
    risposta--;
    string max = mano1[0];
    Console.WriteLine(max);
    string max1=mano1[2];
    Console.WriteLine(max1);
    foreach (string s in mano1)
    {
        string[] carta = s.Split(',');
        if (valori.IndexOf(carta[0]) > valori.IndexOf(max))
        {
            return true;
        }
        else if (valori.IndexOf(carta[0]) == valori.IndexOf(max)&& seme.IndexOf(carta[0]) > seme.IndexOf(max1))
        {
            return true;
        }
        else if(valori.IndexOf(carta[0]) == valori.IndexOf(max) && seme.IndexOf(carta[0]) < seme.IndexOf(max1))
        {
            return false;
        }
        else if(valori.IndexOf(carta[0]) < valori.IndexOf(max))
        {
            return false;
        }
    }
    return false;
}
List<string> valori = new List<string>(["1", "2","3","4","5","6","7","8","9","10","J","Q","K","A"]);
List<string> seme = new List<string>(["P", "F", "Q", "C"]);
List<string> mano = new List<string>();
bool chiudi = true;
int tentativi = 1;
Random rdn=new Random();
while (chiudi!=false)
{   
    
    generoCarta(tentativi,valori, seme, mano);
    bool indovinato = indovina(mano,valori,seme);
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
