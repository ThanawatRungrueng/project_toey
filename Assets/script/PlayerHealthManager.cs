using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance; // Singleton instance
    public Slider healthSlider; // UI Slider สำหรับแสดงเลือด
    public int maxHealth = 100; // จำนวนเลือดสูงสุด
    private int currentHealth; // จำนวนเลือดปัจจุบัน

    void Awake()
    {
        // ทำให้ PlayerHealthManager เป็น Singleton
        if (Instance == null)
        {
            Instance = this;
            currentHealth = maxHealth;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ตั้งค่าเริ่มต้นของ Slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // เพิ่มเลือดและตรวจสอบไม่ให้เกินขีดจำกัด

        // อัปเดต Slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Debug.Log("Health: " + currentHealth);
    }
}