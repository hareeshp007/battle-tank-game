
using Tanks.tank;
using UnityEngine;

public class EnemyAttackState : EnemyStates
{

    [SerializeField]
    private float delay;

    public override void OnEnterState()
    {
        UnityEngine.Debug.Log("Attacking Enter");
    }
    public override void OnExitState()
    {

    }
    public override void OnUpdateState()
    {
      _EnemyView.Attack(delay);
    }
    public override Enemystate GetState()
    {
        return Enemystate.AttackState;
    }
}
