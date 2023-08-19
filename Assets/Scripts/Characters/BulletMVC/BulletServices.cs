using UnityEngine;

public class BulletServices : MonoBehaviour
{
    public BulletView bulletView;
    public BulletScriptableObjectList BulletList;
    void Start()
    {
        createNewBullet();
    }
    private void createNewBullet()
    {
        BulletScriptableObject bullet = BulletList.bulletObjects[0];
        BulletModel model = new BulletModel(bullet);
        BulletController controller=new BulletController(model,bullet);
    }
}
