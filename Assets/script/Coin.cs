    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Coin : MonoBehaviour
{
    public float speed = 5f; // ��������㹡������͹���ͧ����­

    void Update()
    {
        // ����͹�������­价ҧ����
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ź����­����;�˹�Ҩ�
        if (transform.position.x < -10f) // ��Ѻ��ҵ����Ҵ˹�Ҩͧ͢�س
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���¡��ҹ�ѧ��ѹ���������­�١��
            CoinManager.Instance.OnCoinCollected();
            Destroy(gameObject); // ���������­
        }
    }
}