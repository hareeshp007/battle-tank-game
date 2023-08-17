using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController _controller;
    public int Speed { get; }
    public int Health { get; }

    public TankModel(int speed,int health) {
        Speed = speed;
        Health = health;
    
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }
}
