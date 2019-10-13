using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEffectBehaviour : MonoBehaviour
{
    private double t;
    private float red, green, blue, alpha;
    private float x, y;

    private void Awake()
    {
        t = 0;
        red = 1.0f;
        green = 1.0f;
        blue = 1.0f;
        alpha = 1.0f;
        x = 0;y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += GameManager.Instance.timeManager.PauseDeltaTime();
        if (t > 2f)
        {
            Debug.Log("summon");
            GameManager.Instance.destroyManager.AddDestroyList(gameObject);
        }
        float deltaT = (float)GameManager.Instance.timeManager.PauseDeltaTime();

        if(t>=1.5)alpha *= 0.8f;
        if(x<=1)x += 2f * deltaT;
        if(y<=1)y += 2f * deltaT;
        

        gameObject.transform.Rotate(0, 0, 4);
        this.transform.localScale = new Vector3(x, y, 1);
        this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);

    }
}
