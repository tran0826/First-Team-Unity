using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualManager : MonoBehaviour
{
    private static ManualManager instance;

    private double fadeoutTime = 0;


    public static ManualManager Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(ManualManager);

                instance = (ManualManager)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.LogError(t + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    public TimeManager timeManager;
    public DestroyManager destroyManager;
    public SharedValue sharedValue;


    virtual protected void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as ManualManager;
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
        destroyManager.UpdateByFrame();

        Debug.Log("manualManager");
        if (sharedValue.TransFlag == true)
        {
            Debug.Log(fadeoutTime);
            if (fadeoutTime >= 3)
            {
                SceneManager.LoadScene("Title");
            }
            fadeoutTime += timeManager.PauseDeltaTime();
            gameObject.GetComponent<AudioSource>().volume = (float)((3.0 - fadeoutTime) / 3.0);
        }
    }
}
