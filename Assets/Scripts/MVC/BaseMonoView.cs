using UnityEngine;

namespace VladimirMirMir.MVC
{
    /// <summary>
    /// BaseView for wrapper.
    /// Wrapper is created in order to keep protected Model property. 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class BaseMonoView<TModel> : MonoBehaviour, IView<TModel> where TModel : IModel
    {
        private TModel _model;
        protected TModel Model
        {
            get => (TModel)_model.Copy();
            set => _model = value;
        }

        /// <summary>
        /// Override if needed to make an extra validation
        /// </summary>
        /// <param name="model">Unmodified model</param>
        /// <returns>Validated model</returns>
        protected virtual TModel Validate(TModel model)
        {
            return model;
        }

        public virtual void SetModel(TModel value)
        {
            Model = Validate(value);
            UpdateView();
        }

        public abstract void UpdateView();
    }
}