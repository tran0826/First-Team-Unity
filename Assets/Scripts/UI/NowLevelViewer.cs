using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NowLevelViewer : MonoBehaviour
{
    private Text text;

    [SerializeField]
    private LevelType levelType;

    [SerializeField]
    private bool isNext;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (levelType == LevelType.Interval)
        {
            float temp = 0;
            if (isNext) temp += 1;
            text.text = (temp+GameManager.Instance.playerManager.Interval).ToString();
            
        }
    }
}
