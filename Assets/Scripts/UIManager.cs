using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    private void Awake()
    {
        Instantiate(UI);
    }

    public void UpdateByFrame()
    {


    }

}
