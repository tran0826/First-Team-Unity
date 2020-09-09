using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    [SerializeField]
    private int rank;

    private string score;
    // Start is called before the first frame update
    void Start()
    {
        score=ResultManager.Instance.GetScore(rank);

        gameObject.GetComponent<Text>().text = score;
    }
}
