    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Coin : MonoBehaviour
{
    public float speed = 5f; // ความเร็วในการเคลื่อนที่ของเหรียญ

    void Update()
    {
        // เคลื่อนที่เหรียญไปทางซ้าย
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ลบเหรียญเมื่อพ้นหน้าจอ
        if (transform.position.x < -10f) // ปรับค่าตามขนาดหน้าจอของคุณ
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เรียกใช้งานฟังก์ชันเมื่อเหรียญถูกเก็บ
            CoinManager.Instance.OnCoinCollected();
            Destroy(gameObject); // ทำลายเหรียญ
        }
    }
}