using static Program;

class Program
{
    public class TFraction
    {
        public int x, y;

        public TFraction()
        {
            x = 1;
            y = 1;
        }

        public TFraction(int a, int b)
        {
            x = a;
            if (b == 0) y = 1;
            else y = b;
            reduceFraction(x, y);
        }

        public TFraction(TFraction obj)
        {
            x = obj.x;
            y = obj.y;
        }

        public virtual void setData()
        {
            Console.Write("Введіть чисельник: ");
            x = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Введіть знаменник (не 0): ");
                y = Convert.ToInt32(Console.ReadLine());
            } while (y == 0);
            reduceFraction(x, y);
        }

        public virtual void getData()
        {
            Console.WriteLine(x + "/" + y);
        }

        public void reduceFraction(int a, int b)
        {
            int c;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            a = Math.Abs(a);
            x /= a; y /= a;
        }

        public static TFraction operator +(TFraction fr1, TFraction fr2)
        {
            TFraction fr = new TFraction();
            fr.x = fr1.x * fr2.y + fr2.x * fr1.y;
            fr.y = fr1.y * fr2.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TFraction operator -(TFraction fr1, TFraction fr2)
        {
            TFraction fr = new TFraction();
            fr.x = fr1.x * fr2.y - fr2.x * fr1.y;
            fr.y = fr1.y * fr2.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TFraction operator *(TFraction fr1, TFraction fr2)
        {
            TFraction fr = new TFraction();
            fr.x = fr1.x * fr2.x;
            fr.y = fr1.y * fr2.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TFraction operator /(TFraction fr1, TFraction fr2)
        {
            TFraction fr = new TFraction();
            fr.x = fr1.x * fr2.y;
            fr.y = fr1.y * fr2.x;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }
    }

    public class TMixFraction : TFraction
    {
        public int z;
        public TMixFraction()
        {
            x = 1;
            y = 1;
            z = 1;
        }

        public TMixFraction(int a, int b, int c)
        {
            x = a;
            if (b == 0) y = 1;
            else y = b;
            z = c;
            z += x / y;
            x = x % y;
            reduceFraction(x, y);
        }

        public TMixFraction(TMixFraction obj)
        {
            x = obj.x;
            y = obj.y;
            z = obj.z;
        }

        public override void setData()
        {
            Console.Write("Введіть чисельник: ");
            x = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Введіть знаменник (не 0): ");
                y = Convert.ToInt32(Console.ReadLine());
            } while (y == 0);
            Console.Write("Введіть цілу частину: ");
            z = Convert.ToInt32(Console.ReadLine());
            z += x / y;
            x = x % y;
            reduceFraction(x, y);
        }

        public override void getData()
        {
            Console.WriteLine(z + " " + x + "/" + y);
        }

        public static TMixFraction operator +(TMixFraction fr1, TMixFraction fr2)
        {
            TMixFraction fr = new TMixFraction();
            fr1.x += fr1.z * fr1.y;
            fr2.x += fr2.z * fr2.y;
            fr.x = fr1.x * fr2.y + fr2.x * fr1.y;
            fr.y = fr1.y * fr2.y;
            fr.z = fr.x / fr.y;
            fr.x = fr.x % fr.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TMixFraction operator -(TMixFraction fr1, TMixFraction fr2)
        {
            TMixFraction fr = new TMixFraction();
            fr1.x += fr1.z * fr1.y;
            fr2.x += fr2.z * fr2.y;
            fr.x = fr1.x * fr2.y - fr2.x * fr1.y;
            fr.y = fr1.y * fr2.y;
            fr.z = fr.x / fr.y;
            fr.x = fr.x % fr.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TMixFraction operator *(TMixFraction fr1, TMixFraction fr2)
        {
            TMixFraction fr = new TMixFraction();
            fr1.x += fr1.z * fr1.y;
            fr2.x += fr2.z * fr2.y;
            fr.x = fr1.x * fr2.x;
            fr.y = fr1.y * fr2.y;
            fr.z = fr.x / fr.y;
            fr.x = fr.x % fr.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

        public static TMixFraction operator /(TMixFraction fr1, TMixFraction fr2)
        {
            TMixFraction fr = new TMixFraction();
            fr1.x += fr1.z * fr1.y;
            fr2.x += fr2.z * fr2.y;
            fr.x = fr1.x * fr2.y;
            fr.y = fr1.y * fr2.x;
            fr.z = fr.x / fr.y;
            fr.x = fr.x % fr.y;
            fr.reduceFraction(fr.x, fr.y);
            return fr;
        }

    }

    static void Main(string[] args)
    {
        TFraction fr1 = new TFraction(6, 8);
        TFraction fr2 = new TFraction(1, 2);
        TFraction fr3 = new TFraction();
        TFraction fr4 = new TFraction(fr2);

        fr3.setData();

        Console.Write(" fr1: "); fr1.getData();
        Console.Write(" fr2: "); fr2.getData();
        Console.Write(" fr3: "); fr3.getData();
        Console.Write(" fr4: "); fr4.getData();

        Console.Write(" fr1 + fr2: "); (fr1 + fr2).getData();
        Console.Write(" fr2 - fr1: "); (fr2 - fr1).getData();
        Console.Write(" fr4 * fr3: "); (fr4 * fr3).getData();

        TMixFraction fr5 = new TMixFraction();
        TMixFraction fr6 = new TMixFraction(10, 4, 1);
        fr5.setData();

        Console.Write(" fr5: "); fr5.getData();
        Console.Write(" fr6: "); fr6.getData();

        Console.Write(" fr6 / fr5: "); (fr6 / fr5).getData();
    }
}
