
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyServices : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptableObjectList EnemyList;
    public Transform[] Spawnpos;
    [SerializeField]
    private float destroyDelay;
    private EnemyController controller;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private BulletServices bulletServices;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private int EnemiesCount;
    private void Start()
    {
        EnemiesCount = Spawnpos.Length;
        CreateEnemies();
    }
    private void CreateEnemies()
    {
        foreach(Transform i in Spawnpos)
        {
            CreateEnemy(i); 
        }
        uiManager.GUIupdateEnemies(enemies.Count);
        //EnemyScriptableObject Enemy = EnemyList.EnemyObjects[0];
        // EnemyModel enemyModel = new EnemyModel(Enemy);
        //EnemyController controller = new EnemyController(enemyModel, Enemy);
    }
    private void CreateEnemy(Transform pos)
    {
        EnemyScriptableObject Enemy = EnemyList.EnemyObjects[0];
        EnemyModel enemyModel = new EnemyModel(Enemy);
        controller = new EnemyController(enemyModel, Enemy,pos,enemies,bulletServices,uiManager);
    }
    public IEnumerator KillAllEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Debug.Log("Destroying GameObject"+ enemy.name);
            Destroy(enemy);
            yield return new WaitForSeconds(destroyDelay);
        }
    }
    public List<GameObject> GetEnemies()
    {
        return enemies;
    }
    public void EnemyDied()
    {
        if(enemies.Count > 0)
        {
            EnemiesCount--;
            uiManager.GUIupdateEnemies(EnemiesCount);
        }
        else
        {
            Debug.Log("All Enemies Died");
            uiManager.GameWonMenu();
        }
        
    }
}
