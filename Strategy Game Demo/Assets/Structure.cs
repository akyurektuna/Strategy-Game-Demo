
public abstract class Structure
{
    string name { get; }
    int dimensionX { get; }
    int dimensionY { get;  }

    public abstract void destroy();
    public abstract string structureInfo();
}
