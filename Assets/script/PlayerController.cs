using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public Slider bloodSlider; // ������§�Ѻ Slider ����ʴ��дѺ���ʹ
    public float damageAmount = 10f; // �ӹǹ���ʹ���Ŵŧ�����ⴹ�ػ��ä

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded) // ��ԡ�����������͡��ⴴ
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
        // ��Ǩ�ͺ��Ҽ����蹪��Ѻ�ػ��ä
        if (other.CompareTag("Obstacle"))
        {
            // Ŵ���ʹŧ 10 ˹���
            bloodSlider.value -= damageAmount;

            // ��Ǩ�ͺ����ҡ���ʹ�֧ 0 ������������ʹ����
            if (bloodSlider.value <= 0)
            {
                bloodSlider.value = 0;
                // ����ö�����鴷������Ǣ�ͧ�Ѻ��è�������� �� ����ʴ���ͤ��� Game Over ������ʵ�����
                Debug.Log("Game Over");
            }
        }
    }
}
