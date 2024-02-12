namespace VladimirMirMir.MVC
{
    public interface IController
    {
        IView CreateView(string resourceId);
        IView<TModel> CreateView<TModel>(string resourceId) where TModel : IModel;
        void UpdateView<TModel>(IView<TModel> view, TModel model) where TModel : IModel;
        void CloseView(IView view);
    }
}