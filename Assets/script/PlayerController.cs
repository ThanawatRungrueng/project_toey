using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public Slider bloodSlider; // เชื่อมโยงกับ Slider ที่แสดงระดับเลือด
    public float damageAmount = 10f; // จำนวนเลือดที่ลดลงเมื่อโดนอุปสรรค

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded) // คลิกเมาส์ซ้ายเพื่อกระโดด
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าผู้เล่นชนกับอุปสรรค
        if (other.CompareTag("Obstacle"))
        {
            // ลดเลือดลง 10 หน่วย
            bloodSlider.value -= damageAmount;

            // ตรวจสอบถ้าหากเลือดถึง 0 หรือไม่มีเลือดแล้ว
            if (bloodSlider.value <= 0)
            {
                bloodSlider.value = 0;
                // สามารถเพิ่มโค้ดที่เกี่ยวข้องกับการจบเกมที่นี่ เช่น การแสดงข้อความ Game Over หรือรีสตาร์ทเกม
                Debug.Log("Game Over");
            }
        }
    }
}
