using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType type;
    public int speed;
    public int duration;
    public int damage;
    public EnemyView EnemyView;
}
[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/Enemy/EnemyList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] EnemyObjects;
}