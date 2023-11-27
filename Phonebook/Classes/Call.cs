namespace Phonebook.Classes;

public class Call
{
    List<string> Status = new List<string>(){"u tijeku", "završen", "propušten"};
    public DateTime Time { get; }
    private string setStatus { get; set; }

    public Call(DateTime time, string status)
    {
        Time = time;
        setStatus = status;
    }

    public Call(Dictionary<Contact, List<Call>> directory)
    {
        Random random = new Random();
        int randomStatus = random.Next(3);
        setStatus = Status[randomStatus];
        if (FindCallInProgress(directory))
        {
            Console.WriteLine("Već postoji poziv u tijeku, poziv završen");
            setStatus = "završen";
            Time=DateTime.Now;
            Console.WriteLine("Želite li prekinuti već postojeći poziv u tijeku? (da/ne)");
            if (Confirm(Console.ReadLine()))
            {
               EndCallInProgress(directory); 
            }            
            return;
        }

        Console.WriteLine($"Status poziva: {setStatus}");
        if (setStatus.Equals("završen"))
        {
            Console.Clear();
            Console.WriteLine($"Poziv završen, trajanje {random.Next(20)} sekunda");
        }
        
        Time = DateTime.Now;
    }
    
    public override string ToString()
    {
        string output = $"{Time:dd-MM-yyyy hh:mm:ss}\t\t{setStatus}";
        return output;
    }

    bool FindCallInProgress(Dictionary<Contact, List<Call>> directory)
    {
        foreach (var item in directory)
        {
            foreach (var call in item.Value)
            {
                if (call.setStatus.Equals("u tijeku"))
                {
                    return true;
                }
            }
        }

        return false;
    }

    void EndCallInProgress(Dictionary<Contact, List<Call>> directory)
    {
        foreach (var item in directory)
        {
            foreach (var call in item.Value)
            {
                if (call.setStatus.Equals("u tijeku"))
                {
                    call.setStatus = "završen";
                }
            }
        }
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
}