using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    public float enemyInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spwanEnemy(enemyInterval, enemy));
    }

    private IEnumerator spwanEnemy (float interval, GameObject gameObject)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), Random.Range(6f,6), 0), Quaternion.identity);
        StartCoroutine(spwanEnemy(interval, enemy));
    }
}
