using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPause : MonoBehaviour
{
    [SerializeField]
    private Sprite start;
    [SerializeField]
    private Sprite stop;
    [SerializeField]
    private AudioClip shiori;
    [SerializeField]
    private AudioClip bookOpen;

    private bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timeManager.DeltaTime() == 0)
        {
            if (!isStop)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = start;
                isStop = true;
                GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(bookOpen);
            }
        }
        else
        {
            isStop = false;
        }
        
    }
    public void onClickAct()
    {
        Debug.Log("Click");
        if (isStop)
        {
            GameManager.Instance.timeManager.Resume();
            gameObject.GetComponent<SpriteRenderer>().sprite = stop;
            GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(shiori);
        }
    }
}
