﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPointerMouseUI : MonoBehaviour
{
    private string choose;
    private string text;
    [SerializeField]
    private AudioClip move;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>().text;
        choose = "- " + text + " -";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMousePointer()
    {
        gameObject.GetComponent<Text>().text = choose;
        GameObject.Find("BGM").GetComponent<AudioSource>().PlayOneShot(move);

    }
    public void ExitMousePointer()
    {
        gameObject.GetComponent<Text>().text = text;
    }
}
