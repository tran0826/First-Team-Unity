using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuUI : MonoBehaviour
{
    private string choose;
    private string text;
    [SerializeField]
    private AudioClip move;
    [SerializeField]
    private AudioClip determin;
    [SerializeField]
    private Scene nextScene;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>().text;
        choose = "- " + text + " -";
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleManager.Instance.transFlag == true)
        {
            TitleManager.Instance.destroyManager.AddDestroyList(gameObject);
        }
    }

    public void OnMousePointer()
    {
        gameObject.GetComponent<Text>().text = choose;
        TitleManager.Instance.GetComponent<AudioSource>().PlayOneShot(move);
    }
    public void ExitMousePointer()
    {
        gameObject.GetComponent<Text>().text = text;
    }
    public void OnClickAct()
    {
        TitleManager.Instance.transFlag = true;
        TitleManager.Instance.NextScene = nextScene;
        TitleManager.Instance.GetComponent<AudioSource>().PlayOneShot(determin);
    }
}
