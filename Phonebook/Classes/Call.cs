namespace Phonebook.Classes;

public class Call
{
    List<string> Status = new List<string>(){"u tijeku", "propušten", "završen"};
    public Guid Id { get; }
    public DateTime Time { get; }
    public string setStatus { get; set; }

    public Call(DateTime time, string status)
    {
        Id = new Guid();
        Time = time;
        setStatus = CheckStatus(status);
    }
    string CheckStatus(string enterStatus)
    {
        while (!Status.Contains(enterStatus.ToLower()))
        {
            Console.WriteLine("Unesite jedan od statusa poziva: U tijeku, Propušten, Završen");
            enterStatus = Console.ReadLine();
        }

        return enterStatus;
    }
}