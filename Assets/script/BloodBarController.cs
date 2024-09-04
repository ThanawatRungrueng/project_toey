using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBarController : MonoBehaviour
{
    public Slider bloodSlider; // ������§�Ѻ Slider ���س���ҧ
    public float decreaseAmount = 1f; // �ӹǹ���Ŵŧ����Ъ�ǧ����
    public float decreaseInterval = 2f; // ��������㹡��Ŵ���

    void Start()
    {
        // ����� Coroutine ���Ŵ�����ʹ���ʹ
        StartCoroutine(DecreaseBlood());
        bloodSlider.maxValue = 100f;
        bloodSlider.value = 100f;
    }

    IEnumerator DecreaseBlood()
    {
        while (bloodSlider.value > 0)
        {
            // Ŵ���ŧ
            bloodSlider.value -= decreaseAmount;

            // ����������
            yield return new WaitForSeconds(decreaseInterval);
        }
    }
}