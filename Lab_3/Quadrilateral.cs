using static Quadrilateral;

public class Quadrilateral : IQuadrilateralBySides, IQuadrilateralByVertices
{
    private double[] sides = new double[4];
    private double[] angles = new double[4];

    public Quadrilateral(double a, double b, double c, double d)
    {
        sides[0] = a;
        sides[1] = b;
        sides[2] = c;
        sides[3] = d;

        angles[0] = Math.Acos((a * a + d * d - b * b - c * c) / (2 * a * d));
        angles[1] = Math.Acos((b * b + a * a - c * c - d * d) / (2 * b * a));
        angles[2] = Math.Acos((c * c + b * b - d * d - a * a) / (2 * c * b));
        angles[3] = Math.Acos((d * d + c * c - a * a - b * b) / (2 * d * c));
    }

    public Quadrilateral() { }
    public Quadrilateral(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        double a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        double b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
        double c = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
        double d = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));

        sides[0] = a;
        sides[1] = b;
        sides[2] = c;
        sides[3] = d;

        double[] v1 = { x2 - x1, y2 - y1 };
        double[] v2 = { x3 - x2, y3 - y2 };
        double[] v3 = { x4 - x3, y4 - y3 };
        double[] v4 = { x1 - x4, y1 - y4 };
        angles[0] = AngleBetween(v4, v1);
        angles[1] = AngleBetween(v1, v2);
        angles[2] = AngleBetween(v2, v3);
        angles[3] = AngleBetween(v3, v4);
    }

    public void SetSides(double a, double b, double c, double d)
    {
        Quadrilateral quad = new Quadrilateral(a, b, c, d);
        sides = quad.sides;
        angles = quad.angles;
    }

    public void SetVertices(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        Quadrilateral quad = new Quadrilateral(x1, y1, x2, y2, x3, y3, x4, y4);
        sides = quad.sides;
        angles = quad.angles;
    }

    public double Area()
    {
        double s = (sides[0] + sides[1] + sides[2] + sides[3]) / 2;
        double area = Math.Sqrt((s - sides[0]) * (s - sides[1]) * (s - sides[2]) * (s - sides[3]));
        return area;
    }

    public double Perimeter()
    {
        double perimeter = sides[0] + sides[1] + sides[2] + sides[3];
        return perimeter;
    }

    public bool Convexity()
    {
        if (angles[0] < Math.PI && angles[1] < Math.PI && angles[2] < Math.PI && angles[3] < Math.PI)
            return true;
        else
            return false;
    }

    public string TypeOf()
    {
        if (sides[0] == sides[2] && sides[1] == sides[3])
        {
            if (angles[0] == Math.PI / 2)
            {
                if (sides[0] == sides[1]) return "Квадрат";
                return "Прямокутник";
            }
            else
                return "Паралелограм";
        }
        else
            return "Трапеція";
    }

    private double AngleBetween(double[] vector1, double[] vector2)
    {
        double dotProduct = vector1[0] * vector2[0] + vector1[1] * vector2[1];
        double magnitude1 = Math.Sqrt(vector1[0] * vector1[0] + vector1[1] * vector1[1]);
        double magnitude2 = Math.Sqrt(vector2[0] * vector2[0] + vector2[1] * vector2[1]);

        double angle = Math.Acos(dotProduct / (magnitude1 * magnitude2));

        return angle;
    }

    public interface IQuadrilateralBySides
    {
        void SetSides(double a, double b, double c, double d);
    }

    public interface IQuadrilateralByVertices
    {
        void SetVertices(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);
    }
}
