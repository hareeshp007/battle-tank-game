
using System;
using UnityEngine;

public class TankService : MonoBehaviour
{
    //public TankView tankView;
    //public TankScriptableObject[] tankConfig;
    public Joystick joystickMove;
    public TankScriptableObjectList tankConfig;
    public TankController controller;
    void Start()
    {
           CreateNewTank();
        TankMovement();

    }
    private void Update()
    {
        
    }
    private void CreateNewTank()
    {
        
        TankScriptableObject tank = tankConfig.tankObjects[0];
        TankModel model = new TankModel(tank);
        controller = new TankController(model,tank);
    }
    private void TankMovement()
    {
        controller.move(joystickMove);
    }


}
