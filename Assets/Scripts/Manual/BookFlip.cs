using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookFlip : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;

    public void WhenBookFlip()
    {
        ManualManager.Instance.GetComponent<AudioSource>().PlayOneShot(audioClip);

    }


}
