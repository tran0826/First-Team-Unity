using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowExperience : MonoBehaviour
{
    private Text text;

    public void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "Experience" + GameManager.Instance.playerManager.Experience.ToString();
    }

    public void Update()
    {
        text.text = "Experience" + GameManager.Instance.playerManager.Experience.ToString();
    }
}
