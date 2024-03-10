using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyList = new List<GameObject>();
    [SerializeField]
    List<Transform> spawnPointsList= new List<Transform>();

    int currentRound;
    public float timeBetweenRounds;
    AnimationCurve curveEnemySpawnCount;


    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
