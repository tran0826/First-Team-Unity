using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectBehaivour : MonoBehaviour
{
    private float t;


    private void Awake()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t +=(float) GameManager.Instance.timeManager.PauseDeltaTime();
        if (t >= 1f) GameManager.Instance.destroyManager.AddDestroyList(gameObject);
    }
}
