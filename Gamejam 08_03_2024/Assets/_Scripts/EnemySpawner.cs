using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public float enemyInterval = 3.5f;
    public ObjectPool<Enemy> _pool;

    [SerializeField]
    private Enemy fireEnemy;
    [SerializeField]
    private Enemy earthEnemy;
    [SerializeField]
    private Enemy waterEnemy;

    private void Start()
    {
        _pool = new ObjectPool<Enemy>(createEnemy, onTakeEnemyFromPool, onReturnEnemyToPool, onDestroyEnemy, true, 15, 30);
        StartCoroutine(spwanEnemy(enemyInterval));
    }

    private IEnumerator spwanEnemy(float interval)
    {
        yield return new WaitForSeconds(interval);
        _pool.Get();
        StartCoroutine(spwanEnemy(interval));
    }


    private Enemy createEnemy()
    {
        float randomChance = Random.Range(0.0f, 1.0f);
        if (randomChance < 0.33f)
        {
            Enemy newEnemy = Instantiate(fireEnemy, new Vector3(Random.Range(-5f, 5), Random.Range(6f, 6), 0), Quaternion.identity);
            newEnemy.setPool(_pool);
            return newEnemy;
        }
        else if(randomChance < 0.66f)
        {
            Enemy newEnemy = Instantiate(earthEnemy, new Vector3(Random.Range(-5f, 5), Random.Range(6f, 6), 0), Quaternion.identity);
            newEnemy.setPool(_pool);
            return newEnemy;
        }
        else
        {
            Enemy newEnemy = Instantiate(waterEnemy, new Vector3(Random.Range(-5f, 5), Random.Range(6f, 6), 0), Quaternion.identity);
            newEnemy.setPool(_pool);
            return newEnemy;
        }

        
    }

    private void onTakeEnemyFromPool(Enemy enemy)
    {
        enemy.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(6f, 6), 0);
        enemy.transform.rotation = Quaternion.identity;

        enemy.gameObject.SetActive(true);
    }

    private void onReturnEnemyToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void onDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

}




//[SerializeField]
//private GameObject enemy;

//public float enemyInterval = 3.5f;

//// Start is called before the first frame update
//void Start()
//{
//    StartCoroutine(spwanEnemy(enemyInterval, enemy));
//}

//private IEnumerator spwanEnemy(float interval, GameObject gameObject)
//{
//    yield return new WaitForSeconds(interval);
//    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(6f, 6), 0), Quaternion.identity);
//    StartCoroutine(spwanEnemy(interval, enemy));
//}