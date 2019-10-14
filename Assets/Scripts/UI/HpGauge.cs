using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpGauge : MonoBehaviour
{

    private float hp;
    private Slider slider;
    private float targetHp;



    // Start is called before the first frame update
    void Start()
    {
        hp = GameManager.Instance.sharedValue.Hp;
        targetHp = hp;
        slider = this.GetComponent<Slider>();
        slider.maxValue = hp;
    }

    // Update is called once per frame
    void Update()
    {
        targetHp = GameManager.Instance.sharedValue.Hp;
        hp += (targetHp - hp) * 0.1f;
        slider.value = hp;
    }
}
