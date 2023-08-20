using UnityEngine;

public class BulletView : MonoBehaviour
{
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
    public void SetShooterObject(GameObject tank)
    {
        this.shooterObject = tank;
    }
    public void SetBulletController(BulletController bulletController,BulletModel bulletModel)
    {
        _controller = bulletController;
        bulletSpeed=bulletModel.speed;
        travelDistance = bulletModel.Duration;

    }
    private void Start()
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.gameObject != shooterObject.gameObject)
        {
            Destroy(gameObject);
        }

        if (collidedObject.CompareTag("PlayerTank") && shooterObject.CompareTag("EnemyTank"))
        {
            Debug.Log("Player is Hit", shooterObject.gameObject);
            collidedObject.gameObject.GetComponent<TankView>().Death(shooterObject.gameObject);
        }
        else if (collidedObject.CompareTag("EnemyTank") && shooterObject.CompareTag("PlayerTank"))
        {
            collidedObject.gameObject.GetComponent<EnemyView>().Death();
            Destroy(collidedObject.gameObject, 0.5f);
        }
    }
}

