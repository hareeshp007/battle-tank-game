using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController _controller;
    public int Speed { get; }
    public int Health { get; }
    public TankType TankType { get; }

    public TankModel(int speed,int health) {
        Speed = speed;
        Health = health;
    
    }
    public TankModel(TankScriptableObject tankSO)
    {
        Speed=(int)tankSO.speed;
        Health=(int)tankSO.health;
        TankType = tankSO.TankType;
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }
}
