﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    float alpha = 0;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleManager.Instance.transFlag == true)
        {
            alpha += (float)TitleManager.Instance.timeManager.DeltaTime();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
    }
}