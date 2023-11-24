
using Phonebook.Classes;
List<string> Preferences = new List<string>(){"favorit", "normalan", "blokiran"};
Dictionary<Contact, List<Call>> Directory = new Dictionary<Contact, List<Call>>()
{
    { new Contact("Ivo Ivić", 0123456789, "Favorit"), new List<Call>() },
    { new Contact("Marko Markić", 0123456789, "Favorit"), new List<Call>() },
    { new Contact("Mia Mijić", 0123456789, "Normalan"), new List<Call>() },
    { new Contact("Lea Leić", 0123456789, "Normalan"), new List<Call>() },
    { new Contact("Mate Matić", 0123456789, "Blokiran"), new List<Call>() },

};

int Option = 1;

while (Option != 0)
{
    Console.Clear();
    Console.WriteLine("TELEFONSKI IMENIK:");
    PrintMainMenu();
    Option = CheckOption(Console.ReadLine());
    switch (Option)
    {
        case 1:
            Console.Clear();
            PrintContacts();
            ReturnToMainMessage();
            break;
        case 2:
            Console.Clear();
            Directory.Add(new Contact(Directory), new List<Call>());
            ReturnToMainMessage();
            break;
        case 3:
            Console.Clear();
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Unesite ime i prezime kontakta koji želite izbrisati: ");
                PrintContacts();
                var deleteContact = Console.ReadLine();
                foreach (var item in Directory)
                {
                    if (!item.Key.NameSurname.ToLower().Equals(deleteContact.ToLower()))
                    {
                        Console.Clear();
                        Console.WriteLine($"Kontakt {deleteContact} ne postoji u imeniku. ");
                    }
                    else
                    {
                        Console.WriteLine("Želite li izbrisati kontakt (da/ne): \n" + item.Key);
                        if (Confirm(Console.ReadLine()))
                        {
                            Console.WriteLine($"Kontakt {item.Key.NameSurname} uspiješno izbrisan.");
                            Directory.Remove(item.Key); 
                        }
                        ReturnToMainMessage();
                        Console.Clear();
                        exit = true;
                    }
                }
            }
            break;
        case 4:
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Pretražite kontakt kojem želite mijenjati preferencu: ");
                PrintContacts();
                var editContact = Console.ReadLine();
                if (!CheckContact(editContact))
                {
                    Console.Clear();
                    Console.WriteLine($"Kontakt {editContact} ne postoji u imeniku.");
                }
                else
                {
                    ChangePreference(editContact);
                    ReturnToMainMessage();
                    break;
                }
            }
            break;
        case 5:
            break;
        case 6:
            break;
        case 7:
            Console.Clear();
            Console.WriteLine("Želite li izaći iz aplikacije? (da/ne)");
            if (Confirm(Console.ReadLine())) Option = 0;
            break;
    } 

}

void PrintMainMenu()
{
    Console.WriteLine("1 - Ispis svih kontakata" +
                      "\n2 - Dodaj novi kontakt\n3 - Brisanje kontakta\n4 - Mijenjanje preference kontakta" +
                      "\n5 - Upravljanje kontaktom\n6 - Ispis svih poziva\n7 - Izlaz iz aplikacije"); 
}

int CheckOption(string enterOption)
{
    int enterParsedOption = CheckIsOptionInt(enterOption);
    while (enterParsedOption < 1 || enterParsedOption > 7)
    {
    
        Console.Clear();
        Console.WriteLine("Odaberi jednu od opcija:\n");
        PrintMainMenu();
        enterParsedOption = CheckIsOptionInt(Console.ReadLine());

    }
    return enterParsedOption;
}
int CheckIsOptionInt(string enterOption)
{
    int parsedEnteredOption;
    while (!int.TryParse(enterOption,out parsedEnteredOption))
    {
        Console.Clear();
        Console.WriteLine("Za odabir opcija unesite broj.\n");
        PrintMainMenu();
        enterOption = Console.ReadLine();
    }

    return parsedEnteredOption;
}

bool Confirm(string YesNo)
{
    while (!YesNo.ToLower().Equals("da") && !YesNo.ToLower().Equals("ne"))
    {
        Console.Clear();
        Console.WriteLine("Unesite da ili ne");
        YesNo = Console.ReadLine();
    }
    if (YesNo.ToLower().Equals("da"))
    {
        return true;
    }

    return false;
}

void PrintContacts()
{
    Console.WriteLine("KONTAKTI: \nIme i prezime\t\tBroj telefona\t\tPreferenca");
    foreach (var item in Directory)
    {
        Console.WriteLine(item.Key.ToString());
    }
}
void ReturnToMainMessage(){
    Console.WriteLine("Povratak na glavni izbornik (enter)");
    Console.ReadKey();
    Console.Clear();
}

bool CheckContact(string contactSearch)
{
    foreach (var item in Directory)
    {
        if (item.Key.NameSurname.ToLower().Equals(contactSearch.ToLower()))
        {
            return true;
        }
    }

    return false;
}

bool ChangePreference(string editContact)
{
    foreach (var item in Directory)
    {
        if (item.Key.NameSurname.ToLower().Equals(editContact.ToLower()))
        {
            Console.Clear();
            Console.WriteLine($"Unesite novu preferencu kontakta {item.Key.NameSurname}, trenutna preferenca: {item.Key.setPreference}");
            var newPreference = CheckPreference(Console.ReadLine());
            Console.WriteLine($"Potvrdite mijenjane preference kontakta {item.Key.NameSurname} iz {item.Key.setPreference.ToLower()} u {newPreference.ToLower()} (da/ne)");
            if (Confirm(Console.ReadLine()))
            {
                item.Key.setPreference = newPreference;
                Console.WriteLine("Promjena uspiješna.");
                return true;
            }
            break;
        }
    }

    return false;
}
string CheckPreference(string enterPreference)
{
    while (!Preferences.Contains(enterPreference.ToLower()))
    {
        Console.Clear();
        Console.WriteLine("Unesite jednu od preferenci: Favorit, Normalan, Blokiran");
        enterPreference = Console.ReadLine();
    }
    return enterPreference;
}