using System;
using UnityEngine;

public class BulletServices : MonoBehaviour
{
    public BulletScriptableObjectList BulletList;
    public BulletController BulletController;
    public BulletView bulletPrefab;
    public BulletModel bulletModel;
    public BulletScriptableObject bulletObject;
    public TankService PlayerService;
    void Awake()
    {
        Bullet();
    }
    private void Bullet()
    {
        int bulletIndex = UnityEngine.Random.Range(0, BulletList.bulletObjects.Length);
        this.bulletObject = BulletList.bulletObjects[bulletIndex];
        bulletModel = new BulletModel(bulletObject);
        BulletController = new BulletController(bulletModel, bulletObject);
        bulletPrefab = bulletObject.bulletView;
        bulletPrefab.SetBulletController(BulletController,bulletModel);
    }

    /*private void createBullet()
    {
        BulletView bulletView = GameObject.Instantiate<BulletView>(bulletView);
        bulletView.gameObject.SetActive(false);
        SetTransform(bulletView, newTransform);
        return bulletView;
    }*/

    public void createBullet(BulletType bulletType)
    {
        
        BulletScriptableObject bullet = BulletList.bulletObjects[(int)bulletType];

    }
    public void Shoot(Transform shootPoint)
    {
        //Transform shootPoint = PlayerService.PlayerController.PlayerView.GetshootPoint();
        //Bullet();
        BulletView bullet = GameObject.Instantiate<BulletView>(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.SetShooterObject(this.gameObject);
    }
}
