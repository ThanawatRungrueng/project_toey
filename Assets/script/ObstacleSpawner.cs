using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array ของอุปสรรค
    public Transform[] spawnPoints; // ตำแหน่ง Spawn Point
    public float minSpawnRate = 1f; // เวลาสุ่มขั้นต่ำระหว่างการสร้างอุปสรรค
    public float maxSpawnRate = 3f; // เวลาสุ่มสูงสุดระหว่างการสร้างอุปสรรค
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            SpawnObstacle();
            nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void SpawnObstacle()
    {
        int randomObstacleIndex = Random.Range(0, obstacles.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // สร้างอุปสรรคที่ตำแหน่งที่สุ่มได้
        GameObject spawnedObstacle = Instantiate(obstacles[randomObstacleIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ตรวจสอบว่ามี ObstacleMover ติดอยู่หรือไม่ ถ้าไม่มีก็เพิ่มเข้าไป
        if (spawnedObstacle.GetComponent<ObstacleMover>() == null)
        {
            spawnedObstacle.AddComponent<ObstacleMover>();
        }
    }
}

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // เคลื่อนที่อุปสรรคไปทางซ้าย
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ลบอุปสรรคเมื่อพ้นหน้าจอ
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}