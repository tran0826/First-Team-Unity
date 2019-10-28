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

    private float alpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>().text;
        choose = "- " + text + " -";
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleManager.Instance.sharedValue.TransFlag == true)
        {
            TitleManager.Instance.destroyManager.AddDestroyList(gameObject);
        }
        if (alpha < 1)
        {
            alpha +=(float) TitleManager.Instance.timeManager.DeltaTime();
            gameObject.GetComponent<Text>().color = new Color(0, 0, 0, alpha);
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
        TitleManager.Instance.sharedValue.TransFlag = true;
        TitleManager.Instance.NextScene = nextScene;
        TitleManager.Instance.GetComponent<AudioSource>().PlayOneShot(determin);
    }
}
