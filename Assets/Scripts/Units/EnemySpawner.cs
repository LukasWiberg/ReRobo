using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {
    public Tile tile;
    public GameObject enemy;

    public float spawnDelay = 2;
    private float sinceLastSpawn;

    private void Start() {
        sinceLastSpawn = spawnDelay;
    }

    private void Update() {
        sinceLastSpawn += Time.deltaTime;
        if(sinceLastSpawn>spawnDelay) {
            SpawnEnemy();
            sinceLastSpawn = 0;
        }
    }

    private void SpawnEnemy() {
        GameObject go = Instantiate(enemy, transform.position, transform.rotation, transform);
        go.GetComponent<BaseEnemy>().reGrid = tile.grid;
    }
}
