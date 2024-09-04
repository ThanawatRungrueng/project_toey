using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText; // UI TextMeshPro สำหรับแสดงคะแนน
    private int score = 0; // คะแนนของผู้เล่น
    public GameObject coinPrefab; // Prefab ของเหรียญ
    public Transform[] spawnPoints; // ตำแหน่ง Spawn Point
    public float minSpawnRate = 1f; // เวลาสุ่มขั้นต่ำระหว่างการสร้างเหรียญ
    public float maxSpawnRate = 3f; // เวลาสุ่มสูงสุดระหว่างการสร้างเหรียญ
    private float nextSpawn = 0f;

    void Awake()
    {
        // ทำให้ CoinManager เป็น Singleton
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
        AddScore(10); // เพิ่มคะแนน 10 ต่อเหรียญที่เก็บ
    }
    void SpawnCoin()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        // สร้างเหรียญที่ตำแหน่งที่สุ่มได้
        Instantiate(coinPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
        // สร้างเหรียญที่ตำแหน่งที่สุ่มได้
        GameObject spawnedCoin = Instantiate(coinPrefab, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);

        // ตรวจสอบว่ามี CoinMover ติดอยู่หรือไม่ ถ้าไม่มีก็เพิ่มเข้าไป
        if (spawnedCoin.GetComponent<Coin>() == null)
        {
            spawnedCoin.AddComponent<Coin>();
        }
    }
}
