using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private Vector3 _direction;
    private float _patrolTimer;

    public EnemyPatrolState(EnemyController controller) : base(controller)
    {
    }

    public override void Enter()
    {
        float randomAngle = Random.Range(0f, 360f);
        float x = Controller.transform.position.x * Mathf.Cos(randomAngle);
        float z = Controller.transform.position.z * Mathf.Sin(randomAngle);
        _direction = new Vector3(x, 0f, z);

        _patrolTimer = Controller.PatrolTime;
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
        _patrolTimer -= Time.deltaTime;

        if (_patrolTimer <= 0f)
        {
            Controller.ChangeState(new EnemyIdleState(Controller, Controller.GetRandomIdleTime()));
        }
    }

    public override void UpdatePhysics()
    {
        Controller.MoveTowards(_direction);
    }
}
