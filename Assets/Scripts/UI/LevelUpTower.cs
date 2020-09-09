﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class LevelUpTower : MonoBehaviour
{

    public TowerType levelTowerType;

    private int nowTowerLevel = 0;

    [SerializeField]
    private Sprite CanLevelUp;
    [SerializeField]
    private Sprite CannotLevelUp;

    private bool LevelUpFlag = false;

    [SerializeField]
    private AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (nowTowerLevel == Define.MAX_LEVEL) return;
        if (LevelUpFlag==false&&GameManager.Instance.playerManager.Experience >= Define.LEVEL_UP_TABLE[nowTowerLevel])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = CanLevelUp;
            LevelUpFlag = true;
        }
        else if(GameManager.Instance.playerManager.Experience < Define.LEVEL_UP_TABLE[nowTowerLevel])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = CannotLevelUp;
            LevelUpFlag = false;
        }
    }
    public void onClickAct()
    {
        if (nowTowerLevel == Define.MAX_LEVEL) return;

        if (GameManager.Instance.playerManager.Experience >= Define.LEVEL_UP_TABLE[nowTowerLevel])
        {
            GameManager.Instance.playerManager.Experience -= Define.LEVEL_UP_TABLE[nowTowerLevel];
            nowTowerLevel += 1;
            if (levelTowerType == TowerType.Fire)
            {
                GameManager.Instance.sharedValue.FireLevel++;
            }else if (levelTowerType == TowerType.Water)
            {
                GameManager.Instance.sharedValue.WaterLevel++;
            }
            else if (levelTowerType == TowerType.Thunder)
            {
                GameManager.Instance.sharedValue.ThunderLevel++;
            }
            else if (levelTowerType == TowerType.Normal)
            {
                GameManager.Instance.sharedValue.NormalLevel++;
            }
            GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(sound);
            LevelUpFlag = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = CannotLevelUp;
        }


    }
}
