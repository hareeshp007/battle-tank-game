using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType type;
    public int speed;
    public int duration;
    public int damage;
    public BulletView bulletView;
}

