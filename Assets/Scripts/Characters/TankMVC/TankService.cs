using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    public TankScriptableObject[] tankConfig;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            CreateNewTank(i);
        }
    }

    private void CreateNewTank(int i)
    {
        TankScriptableObject tank = tankConfig[i];
        TankModel model = new TankModel(tank);
        TankController tankController=new TankController(model,tank);
    }

   
}
