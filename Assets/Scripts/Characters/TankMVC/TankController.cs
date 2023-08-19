using System;
using UnityEngine;

public class TankController 
{
    private TankModel _model;
    private TankView _view;
    public TankController(TankModel tankModel,TankScriptableObject tankSO)
    {
        _model = tankModel;
        _view = tankSO.tankView;
        _view.SetTankController(this);
        Vector3 TankTransform = tankSO.tankTransform;
        GameObject.Instantiate(_view.gameObject,TankTransform,Quaternion.identity);
         
    }

    public void move(Joystick joystick1)
    {
        Tank tank = _view.gameObject.GetComponent<Tank>();
        tank.SetJoystick(joystick1);
    }
}
