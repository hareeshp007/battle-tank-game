using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController _controller;
    private TankScriptableObject _tankScriptableObject;
    public int Speed { get; }
    public int Health { get; }
    public float Rotationspeed { get; }
    public TankType TankType { get; }

    public TankModel(int speed,int health) {
        Speed = speed;
        Health = health;
    
    }
    public TankModel(TankScriptableObject tankSO)
    {
        _tankScriptableObject = tankSO;
        Speed=(int)tankSO.speed;
        Health=(int)tankSO.health;
        Rotationspeed=(int)tankSO.rotationspeed;
        TankType = tankSO.TankType;
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }

    public int SpeedLive { get{ return (int)_tankScriptableObject.speed; } }
}
