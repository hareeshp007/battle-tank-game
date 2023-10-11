
using System;
using UnityEngine;
using UnityEngine.Analytics;

public class TankService : MonoBehaviour
{

    [SerializeField]
    private TankScriptableObjectList tankConfig;
    public CameraFollow CameraFollow;
    public TankController PlayerController { get; private set; }
    public BulletServices _BulletServices;
    [SerializeField]
    private TankView playerView;
    [SerializeField]
    private TankModel playerModel;
    [SerializeField]
    private TankScriptableObject playerObject;
    [SerializeField]
    private TankView playerPrefab;

    [SerializeField]
    private UIManager UIManager;
    

    private void Awake()
    {
        int tankIndex = UnityEngine.Random.Range(0, tankConfig.tankObjects.Length);
        this.playerObject = tankConfig.tankObjects[tankIndex];
        CreateTank();
    }

    private void CreateTank()
    {
        this.playerModel = new TankModel(playerObject);
        this.playerPrefab = playerObject.tankView;
        this.playerView = GameObject.Instantiate<TankView>(playerPrefab);
        this.playerView.setUIManager(UIManager);
        this.PlayerController = new TankController(playerModel, playerView);
        this.playerView.SetBulletService(_BulletServices);
        CameraFollow.SetTarget(this.playerView.gameObject.transform);
    }
    public TankView GetPlayer()
    {
        return this.playerView;
    }

}
