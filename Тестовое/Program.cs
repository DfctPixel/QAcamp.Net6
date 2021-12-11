
// See https://aka.ms/new-console-template for more information


Начало:
Console.WriteLine("Формат ввода координат- XпробелY\n");
Point A, B, C;
try
{
    Console.Write("Точка А: ");
    string[] a = Console.ReadLine().Split(' ');
    A = new(Convert.ToDouble(a[0]), Convert.ToDouble(a[1]));

    Console.Write("Точка B: ");
    a = Console.ReadLine().Split(' ');
    B = new(Convert.ToDouble(a[0]), Convert.ToDouble(a[1]));

    Console.Write("Точка C: ");
    a = Console.ReadLine().Split(' ');
    C = new(Convert.ToDouble(a[0]), Convert.ToDouble(a[1]));


    if ((A.X == B.X && B.X == C.X) || (A.Y == B.Y && B.Y == C.Y))
    {
        Console.WriteLine("\nТочки образуют линию, вводи другое\nЖми любую кнопку");
        Console.ReadKey();
        Console.Clear();
        goto Начало;
    }

}
catch (Exception)
{
    Console.WriteLine("\nТак не надо...вводи так - ±0.0пробел±0.0\nЖми любую кнопку");
    Console.ReadKey();
    Console.Clear();
    goto Начало;
}


Triangle Bermuda = new (A,B,C);
Console.WriteLine("\nТреугольник со сторонами AB|{0:0.00}, BC|{1:0.00}, AC|{2:0.00} и \nпериметром {3:0.00} ед. - {4}, {5}, {6}", 
    Bermuda.AB, Bermuda.BC, Bermuda.AC, TriangleOps.Perimeter(Bermuda),TriangleOps.IsEquilateral(Bermuda), 
    TriangleOps.IsIsosceles(Bermuda), TriangleOps.IsRight(Bermuda));

Console.Write("\nЧетные до {0:0}: ", Math.Round(TriangleOps.Perimeter(Bermuda)));
for (int i = 0; i <= Math.Round(TriangleOps.Perimeter(Bermuda)); i++)
{
    if (i % 2 == 0)
        Console.Write("{0} ", i);
}


Console.WriteLine("\n");
Console.ReadKey();

struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public Point (double X, double Y)
    {
        this.X = X; this.Y = Y;
    }
}
class Triangle
{
    public Point A { get; set; }
    public Point B { get; set; }
    public Point C { get; set; }
    public double AB { get; set; }
    public double BC { get; set; }
    public double AC { get; set; }
    public Triangle(Point A, Point B, Point C)
    {
      this.A = A; this.B = B; this.C = C;
      this.AB = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
      this.BC = Math.Sqrt(Math.Pow(B.X - C.X, 2) + Math.Pow(B.Y - C.Y, 2));
      this.AC = Math.Sqrt(Math.Pow(A.X - C.X, 2) + Math.Pow(A.Y - C.Y, 2));
    }
}
static class TriangleOps
{
    public static string IsRight(Triangle t)
    {
        if (Math.Abs(Math.Pow(t.AC, 2) - (Math.Pow(t.AB, 2) + Math.Pow(t.BC, 2))) < 0.1)
            return "прямоугольный";
        else if (Math.Abs(Math.Pow(t.AB, 2) - (Math.Pow(t.AC, 2) + Math.Pow(t.BC, 2))) < 0.1)
            return "прямоугольный";
        else if (Math.Abs(Math.Pow(t.BC, 2) - (Math.Pow(t.AC, 2) + Math.Pow(t.AB, 2))) < 0.1)
            return "прямоугольный";
        else return "не прямоугольный";
    }
    public static string IsEquilateral (Triangle t) => ((t.AB == t.AC) && (t.AB == t.BC)) ? "равносторонний" : "не равносторонний";
    public static string IsIsosceles(Triangle t) => ((t.AB == t.AC) || (t.AB == t.BC) || (t.AC == t.BC)) ? "равнобедренный" : "не равнобедренный";
    public static double Perimeter(Triangle t) => t.AB + t.AC + t.BC; 
}

