using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemSpawner : MonoBehaviour
{
    public GameObject healthItemPrefab; // Prefab �ͧ�����������ʹ
    public Transform[] spawnPoints; // ���˹� Spawn Point
    public float minSpawnRate = 5f; // ����������鹵�������ҧ������ҧ����
    public float maxSpawnRate = 10f; // ���������٧�ش�����ҧ������ҧ����
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

        // ���ҧ�����������ʹ�����˹觷��������
        GameObject spawnedHealthItem = Instantiate(healthItemPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ��Ǩ�ͺ����� HealthItemMover �Դ����������� �������ա���������
        if (spawnedHealthItem.GetComponent<HealthItemMover>() == null)
        {
            spawnedHealthItem.AddComponent<HealthItemMover>();
        }
    }
}