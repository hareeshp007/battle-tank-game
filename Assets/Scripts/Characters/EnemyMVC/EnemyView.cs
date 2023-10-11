
using System;
using System.Collections;
using Tanks.tank;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour,IDamegable
{
    public EnemyController _EnemyController { get; private set; }
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public ParticleSystem EnemyExplosion;
    [SerializeField]
    private float PSDelay;
    private float playerSqrDistance;
    [SerializeField]
    private float chaseSqrRadius = 900f;
    [SerializeField]
    private float attackSqrRadius = 100f;
    public Transform centrePoint; //centre of the area the agent wants to move around in
                                  //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    public bool EnemyisMoving { get; private set; }
    [SerializeField]
    private TankView player;
    [SerializeField]
    private BulletServices bulletServices;

    [SerializeField]
    private EnemyStates currentState;
    private EnemyIdleState idleState;
    [SerializeField]
    private EnemyPatrolling patrolState;
    [SerializeField]
    private EnemyAttackState attackState;
    [SerializeField]
    private EnemyChaseState chaseState;
    
    public Transform shootPoint;

    [SerializeField]
    private float speed;
    private int health;
    [SerializeField]
    private UIManager uIManager;
    public EnemyServices enemyServices { get; private set; }
    public float ShootDelay { get; private set; }

    private float timer;

    void Start()
    {
        Init();
    }
    private void Init()
    {
        patrolState = GetComponent<EnemyPatrolling>();
        attackState = GetComponent<EnemyAttackState>();
        chaseState = GetComponent<EnemyChaseState>();
        EnemyisMoving = true;
        currentState = patrolState;
        currentState.OnEnterState();
        agent = GetComponent<NavMeshAgent>();
        timer = 0;
    }
    public TankView GetTankView()
    {
        return player;
    }

    void Update()
    {
        currentState.OnUpdateState();    
        if(currentState.GetState() == Enemystate.AttackState)
        {
            
        }
    }
    private void FixedUpdate()
    {
        CheckStateChanges();
    }

    private void CheckStateChanges()
    {
        playerSqrDistance = (this.transform.position - player.transform.position).sqrMagnitude;

        if (playerSqrDistance < attackSqrRadius)
        {
            if (currentState.GetState() != Enemystate.AttackState)
                ChangeState(attackState);
        }
        else if (playerSqrDistance < chaseSqrRadius)
        {
            if (currentState.GetState() != Enemystate.ChaseState)
                ChangeState(chaseState);
        }
        else
        {
            if (currentState.GetState() != Enemystate.PatrolState)
                ChangeState(patrolState);
        }
    }
    private void ChangeState(EnemyStates enemyStates)
    {
        currentState.OnExitState();
        currentState= enemyStates;
        Debug.Log("Current EnemyState :" + currentState.GetState().ToString());
        currentState.OnEnterState();
    }
    public void SetEnemyController(EnemyController enemyController,TankView tank)
        {
        _EnemyController = enemyController;
        speed=_EnemyController.GetSpeed();
        health = _EnemyController.GetHealth();
        Debug.Log("EnemyController-EnemyView Connection Established" + _EnemyController.ToString());
        _EnemyController.SetBulletServices(this);
        player = tank;
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
    public void Died()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        EnemyExplosion.Play();
        agent.SetDestination(transform.position);
        EnemyisMoving = false;
        uIManager.GUIEnemyDied();
        StartCoroutine(Death());
    }
    public IEnumerator Death()
    {       
        yield return new WaitForSeconds(PSDelay);
        //particle effect
        Destroy(this.gameObject);
    }
    public void Patrol()
    {
        Debug.Log("Entered patrolview");
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

    public void SetPatrolPosition(Transform patrolPosition, int patrolRadius)
    {
        centrePoint =this.gameObject.transform;
        range= patrolRadius;
    }

    public EnemyController GetEnemyController()
    {
        return _EnemyController;
    }

    public void shoot()
    {
       bulletServices.Shoot(shootPoint,this.gameObject);
    }


    public void setBulletService(BulletServices _bulletServices,UIManager _uIManager)
    {
        bulletServices= _bulletServices;
        uIManager=_uIManager;
    }

    public void Chase()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemypos = transform.position;
        Vector3 newEnemyPos = Vector3.MoveTowards(enemypos, playerPos, speed * Time.deltaTime);
        transform.LookAt(playerPos);
        transform.position = newEnemyPos;
    }

    public void Attack(float delay)
    {
        Vector3 playerPos = player.transform.position;
        this.transform.LookAt(playerPos);
        ShootDelay = delay;
        timer += Time.deltaTime;
        if (timer > ShootDelay)
        {
            this.shoot();
            timer = 0;
        }

        
    }
    public void TakeDamage(int damage) {
        health -= damage;
        if (health < 0)
        {
            SoundManager.Instance.Play(Sounds.EnemyDeath);
            Died();
        }
        
    }
}
