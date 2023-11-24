namespace Phonebook.Classes;

public class Contact
{
    public List<string> Preference = new List<string>(){"favorit", "normalan", "blokiran"};
    public string NameSurname { get;}
    public int Number { get;}
    public string setPreference { get; set; }

    public Contact(Dictionary<Contact, List<Call>> directory)
    {
        Console.WriteLine("Unesite podatke za novi kontakt: \nIme:");
        
        var enterNameSurname = Console.ReadLine();
        while (enterNameSurname.Equals("")) 
        {
            Console.WriteLine("Unos imena i prezimena je obavezan unesite ime: ");
            enterNameSurname = Console.ReadLine(); 
        }

        Console.WriteLine("Unesite broj telefona formata 10 znamenki:");
        var enterNumber = Console.ReadLine();
        int enterParseNumber = CheckNumberFormat(enterNumber); 
        while (CheckPhoneNumberExists(enterParseNumber, directory))
        {
            Console.WriteLine("Uneseni broj već postoji u imeniku. Unesite novi broj:");
            enterNumber = Console.ReadLine();
            enterParseNumber = CheckNumberFormat(enterNumber);
        }
        
        Console.WriteLine("Unesite željenu preferencu kontakta: favorit, normalan, blokiran");
        var enterPreference = Console.ReadLine();

        setPreference = CheckPreference(enterPreference);
        NameSurname = enterNameSurname;
        Number = enterParseNumber;
        
        
        Console.WriteLine($"Dodali ste kontakt {NameSurname}, broja 0{Number}," +
                          $" preference {setPreference}");
    }

    public Contact(string nameSurname, int number, string preference)
    {
        NameSurname = nameSurname;
        Number = number;
        setPreference = preference;
    }

    string CheckPreference(string enterPreference)
    {
        while (!Preference.Contains(enterPreference.ToLower()))
        {
            Console.WriteLine("Unesite jednu od preferenci: Favorit, Normalan, Blokiran");
            enterPreference = Console.ReadLine();
        }

        return enterPreference;
    }

    int CheckNumberFormat(string enterNumber)
    {
        int parseNumber = CheckIsNumber(enterNumber);
        while (!(parseNumber.ToString().Length == 9 && parseNumber.ToString().StartsWith("9")))
        {
            Console.WriteLine("Unesite broj telefona formata 9 znamenki počevši s 9");
            parseNumber = CheckIsNumber(Console.ReadLine());
        }

        return parseNumber;
    }

    int CheckIsNumber(string enterNumber)
    {
        int parseNumber;
        while (!int.TryParse(enterNumber, out parseNumber)) 
        {
            Console.WriteLine("Broj mora sadržavati samo brojeve: ");
            enterNumber = Console.ReadLine();
        }

        return parseNumber;
    }
    public static bool CheckPhoneNumberExists(int phoneNumber, Dictionary<Contact, List<Call>> directory)
    {
        foreach (var item in directory)
        {
            if (item.Key.Number == phoneNumber)
            {
                return true;
            }
        }
        return false;
    }
    public override string ToString()
    {
        string Output = $"{NameSurname}\t\t0{Number}\t\t{setPreference}";
        return Output;
        
    }
}