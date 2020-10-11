﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberOfObjectsToSpawn;
    public Rigidbody objectToSpawn;

    public float timeOffset = 2f;
    private float timer;
    private bool spawning;

    private void Start()
    {
        timer = timeOffset;
    }

    private void Update()
    {
        if (spawning)
        {
            if (timer <= 0f)
            {
                if (numberOfObjectsToSpawn > 0)
                {
                    Rigidbody p = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                    p.velocity = transform.forward * 10;
                }
                numberOfObjectsToSpawn--;
                timer = timeOffset;
            }
            timer -= Time.deltaTime;
            if (numberOfObjectsToSpawn <= 0) spawning = false;
        }
    }

    public void SpawnObjects(int numObjects)
    {
        if (!spawning)
        {
            spawning = true;
            numberOfObjectsToSpawn = numObjects;
        }
    }

}