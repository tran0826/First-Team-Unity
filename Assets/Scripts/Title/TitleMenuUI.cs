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
        GameObject.Find("BGM").GetComponent<AudioSource>().PlayOneShot(move);

    }
    public void ExitMousePointer()
    {
        gameObject.GetComponent<Text>().text = text;
    }
    public void OnClickAct()
    {
        TitleManager.Instance.transFlag = true;
        TitleManager.Instance.NextScene = nextScene;
    }
}
