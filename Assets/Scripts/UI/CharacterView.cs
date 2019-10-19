using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterView : MonoBehaviour
{

    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite summon;
    [SerializeField]
    private Sprite damaged;

    [SerializeField]
    private GameObject summonEffect;

    private float hp;
    private int summonNum;

    private float t;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        t = 0;
        hp = GameManager.Instance.sharedValue.Hp;
        summonNum = GameManager.Instance.towerManager.CountTower();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        t +=(float) GameManager.Instance.timeManager.PauseDeltaTime();
        int nowSummonNum = GameManager.Instance.towerManager.CountTower();
        if (summonNum < nowSummonNum)
        {
            t = 0;
            spriteRenderer.sprite = summon;
            Instantiate(summonEffect, gameObject.transform);
        }
        summonNum = nowSummonNum;

        float nowHp = GameManager.Instance.sharedValue.Hp;
        if (hp > nowHp)
        {
            t = 0;
            spriteRenderer.sprite = damaged;
        }
        hp = nowHp;

        if (t >= 1.5f) spriteRenderer.sprite = normal;


    }
    

}
