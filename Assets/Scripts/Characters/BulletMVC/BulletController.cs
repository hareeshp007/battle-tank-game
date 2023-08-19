using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletModel _bulletmodel;
    private BulletView _bulletview;
    private BulletScriptableObject _bulletscript;
    public BulletController(BulletModel bulletModel,BulletScriptableObject BulletSO)
    {
        _bulletmodel = bulletModel;
        _bulletscript = BulletSO;
        GameObject.Instantiate(_bulletscript.bulletView);
    }
    
}
