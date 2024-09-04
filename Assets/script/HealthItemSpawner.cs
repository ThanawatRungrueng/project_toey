using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemSpawner : MonoBehaviour
{
    public GameObject healthItemPrefab; // Prefab ของไอเทมเพิ่มเลือด
    public Transform[] spawnPoints; // ตำแหน่ง Spawn Point
    public float minSpawnRate = 5f; // เวลาสุ่มขั้นต่ำระหว่างการสร้างไอเทม
    public float maxSpawnRate = 10f; // เวลาสุ่มสูงสุดระหว่างการสร้างไอเทม
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            SpawnHealthItem();
            nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void SpawnHealthItem()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // สร้างไอเทมเพิ่มเลือดที่ตำแหน่งที่สุ่มได้
        GameObject spawnedHealthItem = Instantiate(healthItemPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ตรวจสอบว่ามี HealthItemMover ติดอยู่หรือไม่ ถ้าไม่มีก็เพิ่มเข้าไป
        if (spawnedHealthItem.GetComponent<HealthItemMover>() == null)
        {
            spawnedHealthItem.AddComponent<HealthItemMover>();
        }
    }
}