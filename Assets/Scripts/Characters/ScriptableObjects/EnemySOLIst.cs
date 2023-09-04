
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/Enemy/EnemyList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] EnemyObjects;
}