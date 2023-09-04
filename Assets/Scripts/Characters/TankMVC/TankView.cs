using System;
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour,IDamegable
{
    public static event Action<int> AchevementsUnlock;
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private ParticleSystem tankExplosion;
    [SerializeField] private Transform shootPoint;

    private TankController playerController;
    public BulletServices bulletServices { get; private set; }
    private int bulletCount = 0;
    private float verticalInput;
    private float horizontalInput;
    private bool fireInput = false;

    public float ExplosionDuration = 5f;
    private bool soundOn;

    public UIManager uIManager { get; private set; }
    private void Start()
    {
        uIManager.GUIupdateHealth(playerController.getHealth());
    }
    public Rigidbody GetPlayerRigidBody()
    {
        return this.playerRigidBody;
    }
    public Transform GetshootPoint()
    {
        return this.shootPoint;
    }

    public int GetHealth()
    {
        return playerController.PlayerModel.Health;
    }
    public void SetTankController(TankController tankController)
    {
        playerController = tankController;
    }
    private void Update()
    {
        HandleInputs();
        
        playerController.Rotate(horizontalInput);
        if (fireInput)
        {
            bulletServices.Shoot(shootPoint,this.gameObject);
            bulletCount++;
            checkAchevement();
        }
    }

    private void checkAchevement()
    {
        if(bulletCount == 10||bulletCount==25 || bulletCount == 50)
        {
            AchevementsUnlock?.Invoke(bulletCount);
        }
    }

    private void FixedUpdate()
    {
        
        playerController.Move(verticalInput);
    }

    private void HandleInputs()
    {
        fireInput = Input.GetKeyDown(KeyCode.Space);
        verticalInput = Input.GetAxis("Vertical1");
        horizontalInput = Input.GetAxis("Horizontal1");
    }

    public void TakeDamage(int Damage)
    {
        playerController.TakeDamage(Damage);
        int health =playerController.getHealth();
        uIManager.GUIupdateHealth(health);
    }

    public void SetBulletService(BulletServices _bulletservices)
    {
        bulletServices = _bulletservices;
    }

    public void death()
    {
        tankExplosion.Play();
        uIManager.MainMenuActive();
        SoundManager.Instance.Play(Sounds.PlayerDied);
        StartCoroutine(Die());
        
    }
    public IEnumerator Die()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(ExplosionDuration);
        this.gameObject.SetActive(false);
        Debug.Log("Player is Dead_view");
    }

    internal void setUIManager(UIManager _uIManager)
    {
        Debug.Log("UI manager connection");
        uIManager = _uIManager;
    }

}
