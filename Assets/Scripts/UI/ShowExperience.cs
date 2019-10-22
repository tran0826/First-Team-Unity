using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowExperience : MonoBehaviour
{
    private Text text;
    [SerializeField]
    private int fontSize;

    public void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = GameManager.Instance.playerManager.Experience.ToString();
        text.fontSize = fontSize;
    }

    public void Update()
    {
        text.text = GameManager.Instance.playerManager.Experience.ToString();
    }
}
