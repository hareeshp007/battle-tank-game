using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController _controller;
    public void SetTankController(TankController tankController)
    {
        _controller = tankController;
    }
}
