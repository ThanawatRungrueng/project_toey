using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance; // Singleton instance
    public Slider healthSlider; // UI Slider ����Ѻ�ʴ����ʹ
    public int maxHealth = 100; // �ӹǹ���ʹ�٧�ش
    private int currentHealth; // �ӹǹ���ʹ�Ѩ�غѹ

    void Awake()
    {
        // ����� PlayerHealthManager �� Singleton
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
        // ��駤��������鹢ͧ Slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // �������ʹ��е�Ǩ�ͺ�������Թ�մ�ӡѴ

        // �ѻവ Slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Debug.Log("Health: " + currentHealth);
    }
}