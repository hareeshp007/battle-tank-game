using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController _controller;
    public void SetBulletController(BulletController bulletController)
    {
        _controller = bulletController;
    }
}
