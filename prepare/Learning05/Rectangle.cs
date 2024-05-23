public class Rectangle : Shape 
{

    public double _length;
    public double _width;

    public Rectangle(string _color, double _length, double _width) : base(_color)
    {
        this._length = _length;
        this._width = _width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}