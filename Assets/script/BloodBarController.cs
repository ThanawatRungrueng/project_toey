using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBarController : MonoBehaviour
{
    public Slider bloodSlider; // เชื่อมโยงกับ Slider ที่คุณสร้าง
    public float decreaseAmount = 1f; // จำนวนที่ลดลงในแต่ละช่วงเวลา
    public float decreaseInterval = 2f; // ระยะเวลาในการลดค่า

    void Start()
    {
        // เริ่ม Coroutine ที่ลดค่าหลอดเลือด
        StartCoroutine(DecreaseBlood());
        bloodSlider.maxValue = 100f;
        bloodSlider.value = 100f;
    }

    IEnumerator DecreaseBlood()
    {
        while (bloodSlider.value > 0)
        {
            // ลดค่าลง
            bloodSlider.value -= decreaseAmount;

            // รอระยะเวลา
            yield return new WaitForSeconds(decreaseInterval);
        }
    }
}