using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10; // จำนวนเลือดที่เพิ่มขึ้นเมื่อเก็บไอเทม

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ตรวจสอบว่า PlayerHealthManager instance ถูกกำหนดค่าอย่างถูกต้อง
            if (PlayerHealthManager.Instance != null)
            {
                PlayerHealthManager.Instance.AddHealth(healthAmount);
                Destroy(gameObject); // ทำลายไอเทม
            }
            else
            {
                Debug.LogError("PlayerHealthManager instance is not set.");
            }
        }
    }
}