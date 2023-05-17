class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Спосіб задати чотирикутник:");
            Console.WriteLine("1. Сторони");
            Console.WriteLine("2. Вершини");
            Console.WriteLine("3. Вихід");

            int method = int.Parse(Console.ReadLine());
            Quadrilateral quad = new Quadrilateral();

            switch (method)
            {
                case 1:
                    do
                    {
                        Console.Write("Введіть 4 сторони чотирикутника: ");
                        string[] sidesInput = Console.ReadLine().Split(' ');
                        double a = double.Parse(sidesInput[0]);
                        double b = double.Parse(sidesInput[1]);
                        double c = double.Parse(sidesInput[2]);
                        double d = double.Parse(sidesInput[3]);
                        quad.SetSides(a, b, c, d);
                        if (!quad.Convexity()) Console.WriteLine("Чотирикутник неопуклий\n");
                    } while (!quad.Convexity());
                    break;

                case 2:
                    do
                    {
                        Console.WriteLine("Введіть координати вершин:");
                        Console.Write("1 вершина: ");
                        string[] v1Input = Console.ReadLine().Split(' ');
                        double x1 = double.Parse(v1Input[0]);
                        double y1 = double.Parse(v1Input[1]);
                        Console.Write("2 вершина: ");
                        string[] v2Input = Console.ReadLine().Split(' ');
                        double x2 = double.Parse(v2Input[0]);
                        double y2 = double.Parse(v2Input[1]);
                        Console.Write("3 вершина: ");
                        string[] v3Input = Console.ReadLine().Split(' ');
                        double x3 = double.Parse(v3Input[0]);
                        double y3 = double.Parse(v3Input[1]);
                        Console.Write("4 вершина: ");
                        string[] v4Input = Console.ReadLine().Split(' ');
                        double x4 = double.Parse(v4Input[0]);
                        double y4 = double.Parse(v4Input[1]);
                        quad.SetVertices(x1, y1, x2, y2, x3, y3, x4, y4);
                        if (!quad.Convexity()) Console.Write("Чотирикутник неопуклий");
                    } while (!quad.Convexity());
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Площа: " + quad.Area());
            Console.WriteLine("Периметр: " + quad.Perimeter());
            Console.WriteLine("Тип: " + quad.TypeOf());
            Console.WriteLine();
        }
    }
}
