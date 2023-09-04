using UnityEngine;

public class ServicePoolBullet : ServicePool<BulletView>
{
    [SerializeField]
    private BulletView bulletPrefab;
    protected override BulletView CreateItem()
    {
        BulletView bulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
        bulletView.gameObject.SetActive(false);
        bulletView.SetBulletPool(this);
        return bulletView;
    }
    public BulletView shoot(Transform shootpos, GameObject shooter,BulletView _bulletPrefab)
    {
        bulletPrefab = _bulletPrefab;   
        BulletView bullet= GetItem();
        bullet.gameObject.transform.position =shootpos.position;
        bullet.gameObject.transform.rotation =shootpos.rotation;
        bullet.gameObject.SetActive(true);
        return bullet;
    }
}
