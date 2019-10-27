using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private static TitleManager instance;

    private bool transFlag = false;

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
       
    }
}
