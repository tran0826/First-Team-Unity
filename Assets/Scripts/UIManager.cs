using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    private GameObject ui;

    private void Awake()
    {
       ui= Instantiate(UI);
    }

    public void UpdateByFrame()
    {
        if (GameManager.Instance.sharedValue.TransFlag == true)
        {
            GameManager.Instance.destroyManager.AddDestroyList(ui);
        }

    }

}
