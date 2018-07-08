using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    class MenuComponent
    {
        string Text;

        public MenuComponent(string text)
        {
            Text = text;
        }
    }

    class MenuItem : MenuComponent
    {
        public MenuItem(string text) : base(text)
        {
        }
    }

    class Menu : MenuComponent
    {
        public List<MenuComponent> Components;

        public Menu(string text) : base(text)
        {
            Components = new List<MenuComponent>();
        }
    }

    abstract class Shape
    {
        public abstract string Draw();
    }

    class Circle : Shape
    {
        public override string Draw()
        {
            return "Circle";
        }
    }

    class Triange : Shape
    {
        public override string Draw()
        {
            return "Triange";
        }
    }

    abstract class ShapeDecorator : Shape
    {
        public Shape Shape;

        public ShapeDecorator(Shape shape)
        {
            Shape = shape;
        }
    }

    class ColorDecorator : ShapeDecorator
    {
        string Color;
        public ColorDecorator(string color, Shape shape) : base(shape)
        {
            Color = color;
        }

        public override string Draw()
        {
            return Color + " " + Shape.Draw();
        }
    }


    class Driver
    {
        //static void Main(string[] args)
        //{
        //    //Menu fileMenu = new Menu("File");
        //    //fileMenu.Components.Add(new MenuItem("Open"));
        //    //fileMenu.Components.Add(new MenuItem("Close"));
        //    //fileMenu.Components.Add(new MenuItem("Save"));
        //    //Menu recentMenu = new Menu("Recent");
        //    //fileMenu.Components.Add(recentMenu);

        //    Circle c = new Circle();
        //    Console.WriteLine(c.Draw());

        //    Triange t = new Triange();
        //    Console.WriteLine(t.Draw());

        //    ColorDecorator cd = new ColorDecorator("red", c);
        //    Console.WriteLine(cd.Draw());
        //}
    }
}
