
using UnityEngine;

public class EnemyController 
{
    private EnemyModel _model;
    private EnemyView _view;
    private EnemyScriptableObject _scriptableObject;

    public EnemyController(EnemyModel model,  EnemyScriptableObject EnemySO,Transform Enemypos)
    {
        _model = model;
        _view = EnemySO.EnemyView;
        _scriptableObject = EnemySO;
        GameObject.Instantiate(_view.gameObject, Enemypos);
    }

}
