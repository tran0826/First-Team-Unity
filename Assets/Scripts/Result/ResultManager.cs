using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tools;

public class ResultManager : MonoBehaviour
{
    private static ResultManager instance;

    private double fadeoutTime = 0;

    private List<int> score;


    public static ResultManager Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(ResultManager);

                instance = (ResultManager)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.LogError(t + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    public TimeManager timeManager;
    public SharedValue sharedValue;


    virtual protected void Awake()
    {
        CheckInstance();
        CSVWriter file = new CSVWriter();
        score = file.LogLoad("score");
        score.Sort((a, b) => b - a);
        for(int i = 0; i < 5; i++)
        {
            score.Add(0);
        }
        
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as ResultManager;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        timeManager.UpdateByFrame();

        if (Input.GetMouseButtonUp(0))
        {
            sharedValue.TransFlag = true;
        }

        Debug.Log("ResultManager");
        if (sharedValue.TransFlag == true)
        {
            Debug.Log(fadeoutTime);
            if (fadeoutTime >= 3)
            {
                SceneManager.LoadScene("Title");
            }
            fadeoutTime += timeManager.PauseDeltaTime();
        }
    }

    public int GetScore(int rank)
    {
        return score[rank];
    }
}
