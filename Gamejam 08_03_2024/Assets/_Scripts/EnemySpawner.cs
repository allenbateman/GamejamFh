using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{

    public int startEnemyCount;
    public float enemyInterval = 3.5f;
    float timer;
    public ObjectPool<Enemy> _pool;

    [SerializeField]
    private Enemy fireEnemy;
    [SerializeField]
    private Enemy earthEnemy;
    [SerializeField]
    private Enemy waterEnemy;


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
            int r = Random.Range(0, spawnPoints.Count);
            SpawnEnemy(spawnPoints[r].position);
            timer = enemyInterval;
        }
    }
    void SpawnEnemy(Vector3 position)
    {
        int e = Random.Range(0, enemyTypes.Count);
        Instantiate(enemyTypes[e], position, Quaternion.identity);
    }

}
