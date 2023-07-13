using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class Shape
{
    private string name;
    protected abstract double Area { get; }
    protected Shape(string name)
    {
        this.name = name;
    }
    public override string ToString()
    {
        return $"{name}: {Area:N2}";
    }
}
class Square : Shape
{
    protected double Length { get; }
    protected override double Area { get { return Length * Length; } }
    public Square(string name, double length) : base(name)
    {
        this.Length = length;
    }
}
class Circle : Square
{
    protected override double Area { get { return (Math.PI * Length * Length); } }
    public Circle(string name, double length) : base(name, length) { }
}
class Rectangle : Shape
{
    protected double Width { get; }
    protected double Length { get; }
    protected override double Area { get { return Width * Length; } }
    public Rectangle(string name, double length, double width) : base(name)
    {
        this.Width = width;
        this.Length = length;
    }
}
class Ellipse : Rectangle
{
    protected override double Area { get { return Math.PI * Width * Length; } }
    public Ellipse(string name, double length, double width) : base (name, length, width) { }
}
class Triangle : Rectangle
{
    protected override double Area { get { return 0.5 * Width * Length; } }
    public Triangle(string name, double length, double width) : base(name, length, width) { }
}
class Diamond : Rectangle
{
    protected override double Area { get { return Width * Length; } }
    public Diamond(string name, double length, double width) : base(name, length, width) { }
}
class Program
{
    public static void Main()
    {
        //although Shape is an abstract is can be used as a reference type
        //any child class of Shape is also a Shape
        double length = 2;
        double width = 3;
        List<Shape> shapes = new List<Shape>
        {
            new Square($"square – len:{length}", length),
            new Circle($"circle – rad: {length}", length),
            new Rectangle($"rectangle – wid:{length}, len:{width}", length, width),
            new Triangle($"triangle – bas:{length}, hei:{width}", length, width),
            //doubling width and length
            new Triangle($"triangle – bas:{length *= 2}, hei:{width *= 2}", length,
            width),
            new Square($"square – len:{length}", length),
            new Circle($"circle – rad: {length}", length),
            new Rectangle($"rectangle – wid:{length}, len:{width}", length, width),
            new Ellipse($"ellipse – min:{length}, maj:{width}", length, width),
            new Diamond($"diamond – min:{length}, maj:{width}", length, width)
        };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
}
