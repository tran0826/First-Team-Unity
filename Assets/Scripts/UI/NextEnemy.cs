using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextEnemy : MonoBehaviour
{
    private Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var enemy = GameManager.Instance.enemyManager.OneExistEnemy();
        if (enemy == null) sprite = null;
        else
        {
            if (sprite == null)  sprite = enemy.GetComponent<SpriteRenderer>().sprite;
        }

        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
