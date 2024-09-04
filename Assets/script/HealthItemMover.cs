using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemMover : MonoBehaviour
{
    public float speed = 5f; // ความเร็วในการเคลื่อนที่ของไอเทม

    void Update()
    {
        // เคลื่อนที่ไอเทมไปทางซ้าย
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ลบไอเทมเมื่อพ้นหน้าจอ
        if (transform.position.x < -10f) // ปรับค่าตามขนาดหน้าจอของคุณ
        {
            Destroy(gameObject);
        }
    }
}
