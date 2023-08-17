using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    private TankModel _model;
    private TankView _view;
    public TankController(TankModel tankModel,TankView tankView)
    {
        _model = tankModel;
        _view = tankView;

        GameObject.Instantiate(tankView.gameObject);
    }
}
