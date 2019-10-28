using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    float alpha = 1;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        float time =(float) GameObject.Find("GameManager").GetComponent<TimeManager>().PauseDeltaTime();
        bool transFlag = GameObject.Find("GameManager").GetComponent<SharedValue>().TransFlag;
        if (transFlag == true)
        {
            alpha += time/3.0f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
        else if(alpha>0)
        {
            alpha -= time;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
    }
}
