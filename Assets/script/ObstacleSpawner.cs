using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array �ͧ�ػ��ä
    public Transform[] spawnPoints; // ���˹� Spawn Point
    public float minSpawnRate = 1f; // ����������鹵�������ҧ������ҧ�ػ��ä
    public float maxSpawnRate = 3f; // ���������٧�ش�����ҧ������ҧ�ػ��ä
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

        // ���ҧ�ػ��ä�����˹觷��������
        GameObject spawnedObstacle = Instantiate(obstacles[randomObstacleIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ��Ǩ�ͺ����� ObstacleMover �Դ����������� �������ա���������
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
        // ����͹����ػ��ä价ҧ����
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ź�ػ��ä����;�˹�Ҩ�
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}