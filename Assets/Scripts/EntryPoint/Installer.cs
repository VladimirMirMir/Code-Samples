using DefaultNamespace;
using Zenject;

public class Installer : MonoInstaller
{
    private void InstallServices()
    {
        Container.Bind<ContentService>().FromNew().NonLazy();
    }
    
    public override void InstallBindings()
    {
        InstallServices();
    }
}