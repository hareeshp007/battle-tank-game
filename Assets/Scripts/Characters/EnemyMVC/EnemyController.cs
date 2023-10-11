

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController 
{
    public EnemyModel _model { get; private set; }
    public EnemyView _view { get; private set; }
    private EnemyScriptableObject _scriptableObject;
    private TankView Player;
    private BulletServices _bulletServices;
    private UIManager _manager;

    public EnemyController(EnemyModel model,  EnemyScriptableObject EnemySO,Transform Enemypos, List<GameObject> enemies,BulletServices bulletServices,UIManager uiManager,TankService tankService)
    {
        _bulletServices = bulletServices;
        _manager = uiManager;
        _model = model;
        _view = EnemySO.EnemyView;
        _scriptableObject = EnemySO;
        TankView player = tankService.GetPlayer();
        _view.SetEnemyController(this,player);
        _view.SetPatrolPosition(EnemySO.PatrolPosition, EnemySO.PatrolRadius);
        GameObject enemy= GameObject.Instantiate(_view.gameObject, Enemypos);
        enemies.Add(enemy);
        Debug.Log(enemies.Count);
        
    }
    public void SetBulletServices(EnemyView view)
    {
        view.setBulletService(_bulletServices,_manager);
    }
    public EnemyView GetEnemyview()
    {
        return _view;
    }
    public void Patrol()
    {
        _view.Patrol();
    }
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public float Attack(float timer,float delay)
    {
        Player= _view.GetTankView();
        Vector3 playerPos = Player.transform.position;
        _view.transform.LookAt(playerPos);
        if (timer > delay)
        {
            _view.shoot();
            return 0;
        }
        return timer + Time.deltaTime;
    }

    public float GetSpeed()
    {
        return _model.speed;
    }
    public void TakeDamage(int damage)
    {
        int health = _model.health - damage;
        health = health >= 0 ? health : 0;
        _model.SetHealth(health);
        Debug.Log(_view.name + ": " + health);
        if (health == 0)
        {
            _view.Died();
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Enemy Died");
        
    }

    public int GetHealth()
    {
       return _model.health;
    }
}
