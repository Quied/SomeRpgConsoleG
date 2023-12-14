using System;
using System.Collections.Generic;
using System.Diagnostics;

class TKeyBase
{
    public int Id { get; set; }
}

class TValueBase
{
    public int Id { get; set; }
}

class Magazine : TKeyBase
{
    public string Title { get; set; }
    public Frequency Frequency { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Circulation { get; set; }
    public List<Article> Articles { get; set; }

    public Magazine(string title, Frequency frequency, DateTime releaseDate, int circulation)
    {
        Title = title;
        Frequency = frequency;
        ReleaseDate = releaseDate;
        Circulation = circulation;
        Articles = new List<Article>();
    }

    public Magazine() : this("Default Title", Frequency.Monthly, DateTime.Now, 10000) { }
}

enum Frequency
{
    Weekly,
    Monthly,
    Yearly
}

class Article : TKeyBase
{
    public string Title { get; set; }
    public double Rating { get; set; }

    public Article(string title, double rating)
    {
        Title = title;
        Rating = rating;
    }

    public Article() : this("Default Article", 0.0) { }
}

class TValue : TValueBase
{
    public TKeyBase TKeyReference { get; set; }
}

class TestCollections
{
    private List<TKeyBase> listTKey;
    private List<string> listString;
    private Dictionary<TKeyBase, TValue> dictionaryTKey;
    private Dictionary<string, TValue> dictionaryString;

    public TestCollections(int numElements)
    {
        GenerateCollections(numElements);
    }

    private void GenerateCollections(int numElements)
    {
        listTKey = new List<TKeyBase>();
        listString = new List<string>();
        dictionaryTKey = new Dictionary<TKeyBase, TValue>();
        dictionaryString = new Dictionary<string, TValue>();

        for (int i = 0; i < numElements; i++)
        {
            TKeyBase key = new TKeyBase { Id = i };
            TValue value = new TValue { Id = i, TKeyReference = key };

            listTKey.Add(key);
            listString.Add(key.ToString());
            dictionaryTKey[key] = value;
            dictionaryString[key.ToString()] = value;
        }
    }

    public void TestSearch(int elementIndex)
    {
        TKeyBase keyToSearch = listTKey[elementIndex];

        SearchAndPrint("List<TKey>", () => listTKey.Contains(keyToSearch));
        SearchAndPrint("List<string>", () => listString.Contains(keyToSearch.ToString()));
        SearchAndPrint("Dictionary<TKey, TValue>", () => dictionaryTKey.ContainsKey(keyToSearch));
        SearchAndPrint("Dictionary<string, TValue>", () => dictionaryString.ContainsKey(keyToSearch.ToString()));
    }

    private void SearchAndPrint(string collectionName, Func<bool> searchFunction)
    {
        Console.Write($"Searching in {collectionName}...");
        var stopwatch = Stopwatch.StartNew();
        bool result = searchFunction();
        stopwatch.Stop();
        Console.WriteLine($" Result: {result}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
    }
}

class MagazineCollection
{
    private List<Magazine> magazines;

    public MagazineCollection()
    {
        magazines = new List<Magazine>();
    }

    public void AddMagazine(Magazine magazine)
    {
        magazines.Add(magazine);
    }

    public void PrintMagazines()
    {
        foreach (var magazine in magazines)
        {
            Console.WriteLine(magazine);
        }
        Console.WriteLine();
    }

    public void SortByTitle()
    {
        magazines.Sort((m1, m2) => string.Compare(m1.Title, m2.Title, StringComparison.Ordinal));
        PrintMagazines();
    }

    public void SortByReleaseDate()
    {
        magazines.Sort((m1, m2) => m1.ReleaseDate.CompareTo(m2.ReleaseDate));
        PrintMagazines();
    }

    public void SortByCirculation()
    {
        magazines.Sort((m1, m2) => m1.Circulation.CompareTo(m2.Circulation));
        PrintMagazines();
    }

    public void MaxAverageRating()
    {
        double maxRating = magazines.Max(m => m.Articles.Any() ? m.Articles.Average(a => a.Rating) : 0.0);
        Console.WriteLine($"Max Average Rating: {maxRating}");
    }

    public void FilterByFrequency(Frequency frequency)
    {
        var filteredMagazines = magazines.Where(m => m.Frequency == frequency).ToList();
        Console.WriteLine($"Magazines with {frequency} frequency:");
        foreach (var magazine in filteredMagazines)
        {
            Console.WriteLine(magazine);
        }
        Console.WriteLine();
    }

    public void GroupByAverageRating()
    {
        var groupedMagazines = magazines.GroupBy(m => m.Articles.Any() ? m.Articles.Average(a => a.Rating) : 0.0);
        Console.WriteLine("Grouped Magazines by Average Rating:");
        foreach (var group in groupedMagazines)
        {
            Console.WriteLine($"Average Rating: {group.Key}");
            foreach (var magazine in group)
            {
                Console.WriteLine($"  {magazine}");
            }
        }
        Console.WriteLine();
    }
}

class Solution
{
    static void Main()
    {
        // Variant 1
        Console.WriteLine("Variant 1:");
        TestCollections testCollections1 = new TestCollections(1000000);
        testCollections1.TestSearch(0);
        testCollections1.TestSearch(500000);
        testCollections1.TestSearch(999999);
        testCollections1.TestSearch(2000000);

        // Variant 2
        Console.WriteLine("\nVariant 2:");
        MagazineCollection magazineCollection = new MagazineCollection();
        magazineCollection.AddMagazine(new Magazine("Magazine1", Frequency.Weekly, DateTime.Now, 5000));
        magazineCollection.AddMagazine(new Magazine("Magazine2", Frequency.Monthly, DateTime.Now.AddMonths(-1), 8000));
        magazineCollection.AddMagazine(new Magazine("Magazine3", Frequency.Yearly, DateTime.Now.AddYears(-1), 10000));
        magazineCollection.PrintMagazines();

        Console.WriteLine("Sorting by Title:");
        magazineCollection.SortByTitle();

        Console.WriteLine("Sorting by Release Date:");
        magazineCollection.SortByReleaseDate();

        Console.WriteLine("Sorting by Circulation:");
        magazineCollection.SortByCirculation();

        magazineCollection.MaxAverageRating();
        magazineCollection.FilterByFrequency(Frequency.Monthly);
        magazineCollection.GroupByAverageRating();
    }
}
