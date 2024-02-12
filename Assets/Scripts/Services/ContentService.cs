using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace DefaultNamespace
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ContentService : IInitializable, IDisposable
    {
        private AsyncOperationHandle<IList<Object>> _prewarmHandler;

        #region Initialize and Dispose

        public async void Initialize()
        {
            await InitializeAddressable();
            await UpdateCatalogs();
            await Prewarm();
        }

        public void Dispose()
        {
            if (_prewarmHandler.IsValid())
            {
                Addressables.Release(_prewarmHandler);
                _prewarmHandler = default;
            }
        }

        #endregion

        #region Private Methods

        private async UniTask InitializeAddressable()
        {
            await Addressables.InitializeAsync();
        }

        private async UniTask UpdateCatalogs()
        {
            var catalogs = await Addressables.CheckForCatalogUpdates().Task;
            if (catalogs.Count > 0)
                await Addressables.UpdateCatalogs(catalogs).Task;
        }

        private async UniTask Prewarm(string label = "prewarm")
        {
            Assert.IsFalse(_prewarmHandler.IsValid());
            _prewarmHandler = Addressables.LoadAssetsAsync(label, (Action<Object>)null);
            await _prewarmHandler.Task;
        }

        #endregion

        #region Public Methods

        public T LoadAssetAsync<T>(string resourceId)
        {
            return Addressables.LoadAssetAsync<T>(resourceId).WaitForCompletion();
        }

        public bool IsResourceExist<T>(string resourceId)
        {
            foreach (var resourceLocator in Addressables.ResourceLocators)
                if (resourceLocator.Locate(resourceId, typeof(T), out _))
                    return true;

            return false;
        }

        #endregion
    }
}