using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10; // �ӹǹ���ʹ���������������������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ��Ǩ�ͺ��� PlayerHealthManager instance �١��˹�������ҧ�١��ͧ
            if (PlayerHealthManager.Instance != null)
            {
                PlayerHealthManager.Instance.AddHealth(healthAmount);
                Destroy(gameObject); // ���������
            }
            else
            {
                Debug.LogError("PlayerHealthManager instance is not set.");
            }
        }
    }
}