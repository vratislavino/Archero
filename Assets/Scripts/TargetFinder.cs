using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetFinder : MonoBehaviour
{
    private Spawner spawnerRef;

    private void Awake() {
        spawnerRef = Spawner.Instance;
    }

    public Unit GetClosestEnemy() {
        if(spawnerRef.SpawnedEnemyUnits.Count > 0) {

            var ordered = spawnerRef.SpawnedEnemyUnits.OrderBy(x => Vector3.Distance(transform.position, x.transform.position));
            return ordered.First();
        }
        return null;
    }

}
