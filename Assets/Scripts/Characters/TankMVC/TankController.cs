using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    private TankModel _model;
    private TankView _view;
    public TankController(TankModel tankModel,TankScriptableObject tankSO)
    {
        _model = tankModel;
        _view = tankSO.tankView;
        Vector3 TankTransform = tankSO.tankTransform;
        GameObject.Instantiate(_view.gameObject,TankTransform,Quaternion.identity);
         
    }

}
