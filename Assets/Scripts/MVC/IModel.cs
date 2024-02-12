namespace VladimirMirMir.MVC
{
    /// <summary>
    /// Represents a pure data, that might be needed for view to display.
    /// Best practice for IModel to be a struct.
    /// </summary>
    public interface IModel
    {
        bool Equals(IModel otherModel);
        IModel Copy();
    }
}