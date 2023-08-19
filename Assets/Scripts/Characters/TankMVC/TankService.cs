using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    //public TankScriptableObject[] tankConfig;
    public TankScriptableObjectList tankConfig;
    // Start is called before the first frame update
    void Start()
    {
            CreateNewTank();
    }

    private void CreateNewTank()
    {
        
        TankScriptableObject tank = tankConfig.tankObjects[0];
        TankModel model = new TankModel(tank);
        TankController tankController=new TankController(model,tank);
    }

   
}
