
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/Tank/TankList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankObjects;
}
