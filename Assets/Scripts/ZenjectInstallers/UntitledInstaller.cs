using Cinemachine;
using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private CameraSelecter _cameraSelecter;

    public override void InstallBindings()
    {
        Container.Bind<Experience>().AsSingle().NonLazy();
        Container.Bind<Inventory>().AsSingle().NonLazy();
        Container.Bind<Grid>().AsSingle().NonLazy();
    }
}