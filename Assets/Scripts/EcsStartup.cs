
using Booster;
using Camera;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Input;
using Player;
using PickableCube;
using Win;

public sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;
    private int lol;
    
    public GameUI gameUI = null;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);
        
        if (!PlayerPrefs.HasKey("level")){
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }
        
        if (!PlayerPrefs.HasKey("score")){
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
        
        systems.ConvertScene();
            
        AddSystems();
        AddInjections();
        AddOneFrames();
        
        systems.Init();
    }

    private void AddInjections()
    {
        systems
            .Inject(gameUI)
            ;
    }

    private void AddOneFrames()
    {
        
    }

    private void AddSystems()
    {
        systems
            .Add(new WinDetectingSystem())
            .Add(new InputSystem())
            .Add(new MovementSystem())
            .Add(new CubeLosingSystem())
            .Add(new CubePickingSystem())
            .Add(new CubePuttingInStackSystem())
            .Add(new CubeFollowingPlayerSystem())
            .Add(new BoosterSystem())
            .Add(new CameraSystem())
            ;
    }

    private void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        if (systems == null) return;
        
        systems.Destroy();
        systems = null;
        
        world.Destroy();
        world = null;
    }
}