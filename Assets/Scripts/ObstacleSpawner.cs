﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the spawning of obstacles
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle = null;
    [SerializeField] private GameObject Coin = null;
    [SerializeField] private float SpawnIntervalObstacle = 1;
    [SerializeField] private float SpawnIntervalCoin = 2;
    private float NextSpawnObstacle = 0;
    private float NextSpawnCoin = 0;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Time.time >= NextSpawnObstacle)
        {
            NextSpawnObstacle = Time.time + SpawnIntervalObstacle;
            Vector3 SpawnPos = new Vector3(8, Random.Range(-3, 3), 0);

            Instantiate(Obstacle, SpawnPos, Quaternion.identity);
        }

        //spawn coins that increases score by 10 upon collecting
        if (Time.time >= NextSpawnCoin)
        {
            NextSpawnCoin = Time.time + SpawnIntervalCoin;
            Vector3 CoinPos = new Vector3(0, Random.Range(-3.55f, 3.55f));

            Instantiate(Coin, CoinPos, Quaternion.identity);
        }
    }

}
