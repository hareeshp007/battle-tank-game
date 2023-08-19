using System;
using UnityEngine;

public class TankController 
{
    private TankModel _model;
    private TankView _view;
    private GameObject TankClone;
    public CharacterController characterController;
    public TankController(TankModel tankModel,TankScriptableObject tankSO)
    {
        _model = tankModel;
        _view = tankSO.tankView;
        _view.SetTankController(this);
        Vector3 TankTransform = tankSO.tankTransform;
        GameObject TankClone=GameObject.Instantiate(_view.gameObject,TankTransform,Quaternion.identity);
        CharacterController characterController=TankClone.GetComponent<CharacterController>();
    }

    public void move(Joystick joystick1)
    {
        Tank tank = _view.gameObject.GetComponent<Tank>();
        tank.SetJoystick(joystick1);
    }
    
}
