using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderAController : EnemyController
{
    [SerializeField] private float fleeingZoneRadius = 10f;

    public override void Initialize(EnemiesManager enemiesManager, PlayerController player)
    {
        base.Initialize(enemiesManager, player);

        OnDeath += CreateFleeingZone;
    }

    private void CreateFleeingZone(EnemyController controller, Transform deathSource)
    {
        foreach (EnemyController enemy in EnemiesManager.EnemiesCloseTo(this, fleeingZoneRadius))
        {
            enemy.EnemyDiedClose(deathSource);
        }
    }

    public override void EnemyDiedClose(Transform source)
    {
        base.EnemyDiedClose(source);

        ChangeState(new EnemyFleeFromState(this, source));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, fleeingZoneRadius);
    }
}
