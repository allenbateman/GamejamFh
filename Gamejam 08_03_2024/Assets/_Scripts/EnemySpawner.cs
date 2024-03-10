using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{

    public float enemyInterval = 3.5f;
    float timer;
    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private List<GameObject> enemyTypes= new List<GameObject>();

    private void Start()
    {
        timer = enemyInterval;
    }

    private void Update()
    {
        timer-= Time.deltaTime;
        if(timer < 0)
        {
            int r = Random.Range(0, spawnPoints.Count-1);
            SpawnEnemy(spawnPoints[r].position);
            timer = enemyInterval;
        }
    }
    void SpawnEnemy(Vector3 position)
    {
        int e = Random.Range(0, enemyTypes.Count-1);
        Instantiate(enemyTypes[e], position, Quaternion.identity);
    }

}
