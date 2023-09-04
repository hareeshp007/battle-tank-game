
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public ParticleSystem BulletExplosion;
    [SerializeField]
    private int travelDistance = 10;
    [SerializeField]
    private Vector3 startPoint;
    [SerializeField]
    private Vector3 endPoint;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private int bulletSpeed = 20;
    [SerializeField]
    private BulletController _controller;
    [SerializeField]
    private GameObject shooterObject;
    [SerializeField]
    private int Damage;
    [SerializeField]
    private ServicePoolBullet servicePoolBullet;
    
    public void SetShooterObject(GameObject tank)
    {
        this.shooterObject = tank;
        Debug.Log("shooterObject :" + shooterObject.name);
    }
    public void SetBulletController(BulletController bulletController,BulletModel bulletModel)
    {
        _controller = bulletController;
        bulletSpeed=bulletModel.speed;
        travelDistance = bulletModel.Duration;
        Damage = bulletModel.damage;
    }
    private void OnEnable()
    {
        if (_controller != null)
        {
            bulletSpeed=_controller.GetSpeed();
            travelDistance=_controller.GetDuration();
        }
        startPoint = transform.position;
        offset = transform.forward * travelDistance;
        endPoint = startPoint + offset;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint, bulletSpeed * Time.deltaTime);
        if ((endPoint - transform.position).sqrMagnitude < 0.1)
        {
            BulletExplosion.Play();
            SoundManager.Instance.Play(Sounds.BulletExplosion);
            gameObject.SetActive(false);
            servicePoolBullet.ReturnItem(this);
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        Debug.Log(collidedObject.name + "  "+ shooterObject.name);

        if (collidedObject.gameObject != shooterObject)
        {
            BulletExplosion.Play();
            SoundManager.Instance.Play(Sounds.BulletExplosion);
            gameObject.SetActive(false);
            servicePoolBullet.ReturnItem(this);
        }

        if (collidedObject.gameObject.GetComponent<IDamegable>() != null && collidedObject.gameObject!=shooterObject )
        {
            Debug.Log("Player is Hit", shooterObject);
            collidedObject.gameObject.GetComponent<IDamegable>().TakeDamage(Damage);
        }
        
    }

    public void SetBulletPool(ServicePoolBullet _servicePoolBullet)
    {
        servicePoolBullet= _servicePoolBullet;
    }
}

