using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : SceneSingleton<Spawner>
{
    private List<Unit> spawnedEnemyUnits = new List<Unit>();
    public List<Unit> SpawnedEnemyUnits => spawnedEnemyUnits;

    private List<Transform> spawnPoints;

    [SerializeField]
    private Transform spawnpointsParent;

    [SerializeField]
    private List<Unit> enemyPrefabs;

    protected override void Awake() {
        base.Awake();
        spawnPoints = spawnpointsParent.GetComponentsInChildren<Transform>().ToList();
    }

    private void Start() {
        SpawnRandomEnemy();
    }

    void SpawnRandomEnemy() {
        SpawnEnemy(GetRandomSpawnPoint(), GetRandomEnemy());
    }

    private Transform GetRandomSpawnPoint() {
        return spawnPoints.ElementAt(Random.Range(0, spawnPoints.Count));
    }

    private Unit GetRandomEnemy() {
        return enemyPrefabs.ElementAt(Random.Range(0, enemyPrefabs.Count));
    }

    public void SpawnEnemy(Transform spawnPoint, Unit enemy) {
        var newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        newEnemy.Died += OnEnemyDied;
        HpBarProvider.Instance.ProvideForUnit(newEnemy);
        spawnedEnemyUnits.Add(newEnemy);


    }

    private void OnEnemyDied(Unit unit) {
        spawnedEnemyUnits.Remove(unit);
        Destroy(unit.gameObject);
        SpawnRandomEnemy();
    }
}
