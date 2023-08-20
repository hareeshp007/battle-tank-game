using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
       private EnemyController _EnemyController;
        public void SetEnemyController(EnemyController enemyController)
        {
            _EnemyController = enemyController;
        }

    internal void Death()
    {
        throw new NotImplementedException();
    }
}
