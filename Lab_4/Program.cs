class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string fileName = "text.txt";

        while (true)
        {
            Console.Write("Введіть текст: ");
            string text = Console.ReadLine();
            File.WriteAllText(fileName, text);
            Console.WriteLine();


            char[] fileContent = File.ReadAllText(fileName).ToLower().ToCharArray();
            List<char> listfile = File.ReadAllText(fileName).ToLower().ToList();

            int vowelsCount = CountVowels(fileContent);
            int consonantsCount = CountConsonants(fileContent);
            Console.WriteLine("Array: ");
            Console.WriteLine("Кількість голосних літер: " + vowelsCount);
            Console.WriteLine("Кількість приголосних літер: " + consonantsCount);

            vowelsCount = CountVowels(listfile);
            consonantsCount = CountConsonants(listfile);
            Console.WriteLine("List: ");
            Console.WriteLine("Кількість голосних літер: " + vowelsCount);
            Console.WriteLine("Кількість приголосних літер: " + consonantsCount);

            Console.WriteLine();
            Console.Write("0 для виходу: ");
            text = Console.ReadLine();
            if (text == "0") Environment.Exit(0);
            Console.WriteLine();
        }
    }

    static int CountVowels(char[] charArray)
    {
        List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        int count = 0;
        foreach (char c in charArray)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    static int CountVowels(List<char> charList)
    {
        return CountVowels(charList.ToArray());
    }

    static int CountConsonants(char[] charArray)
    {
        List<char> consonants = new List<char>() { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
        int count = 0;
        foreach (char c in charArray)
        {
            if (consonants.Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    static int CountConsonants(List<char> charList)
    {
        return CountConsonants(charList.ToArray());
    }
}
