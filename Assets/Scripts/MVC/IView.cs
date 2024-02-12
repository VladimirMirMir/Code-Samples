namespace VladimirMirMir.MVC
{
    /// <summary>
    /// Represents most simple view - it needs no model to be viewed.
    /// </summary>
    public interface IView
    {
    }
    
    // ReSharper disable once TypeParameterCanBeVariant
    /// <summary>
    /// Represents any view, that needs data to display properly.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IView<TModel> : IView where TModel : IModel
    {
        void SetModel(TModel value);
    }
}