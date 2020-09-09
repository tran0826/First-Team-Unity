using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private static TitleManager instance;

    public Scene NextScene = Scene.Title;
    private double fadeoutTime = 0;


    public static TitleManager Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(TitleManager);

                instance = (TitleManager)FindObjectOfType(t);
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
            instance = this as TitleManager;
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

        Debug.Log("titleManager");
        if (sharedValue.TransFlag == true)
        {
            Debug.Log(fadeoutTime);
            if (fadeoutTime >= 3)
            {
                if (NextScene == Scene.Game)
                {
                    SceneManager.LoadScene("MainGame");
                }else if (NextScene == Scene.Manual)
                {
                    SceneManager.LoadScene("Manual");
                }
                else if (NextScene == Scene.Exit)
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
                    UnityEngine.Application.Quit();
#endif
                }
            }
            fadeoutTime += timeManager.PauseDeltaTime();
            GameObject.Find("BGM").GetComponent<AudioSource>().volume = (float)((3.0 - fadeoutTime) / 3.0);
        }
    }
}
