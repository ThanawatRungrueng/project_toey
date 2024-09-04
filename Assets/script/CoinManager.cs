using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText; // UI TextMeshPro ����Ѻ�ʴ���ṹ
    private int score = 0; // ��ṹ�ͧ������
    public GameObject coinPrefab; // Prefab �ͧ����­
    public Transform[] spawnPoints; // ���˹� Spawn Point
    public float minSpawnRate = 1f; // ����������鹵�������ҧ������ҧ����­
    public float maxSpawnRate = 3f; // ���������٧�ش�����ҧ������ҧ����­
    private float nextSpawn = 0f;

    void Awake()
    {
        // ����� CoinManager �� Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            SpawnCoin();
            nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void OnCoinCollected()
    {
        AddScore(10); // ������ṹ 10 �������­�����
    }
    void SpawnCoin()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // ���ҧ����­�����˹觷��������
        Instantiate(coinPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
        // ���ҧ����­�����˹觷��������
        GameObject spawnedCoin = Instantiate(coinPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ��Ǩ�ͺ����� CoinMover �Դ����������� �������ա���������
        if (spawnedCoin.GetComponent<Coin>() == null)
        {
            spawnedCoin.AddComponent<Coin>();
        }
    }
}
