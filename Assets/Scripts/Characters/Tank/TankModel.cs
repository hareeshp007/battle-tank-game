using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController _controller;
    public TankModel() {
        
    
    }
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }
}
