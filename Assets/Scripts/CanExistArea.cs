using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanExistArea : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<BulletBase>();
        if (bullet != null)
        {
            GameManager.Instance.destroyManager.AddDestroyList(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.enterExistArea();
        }
    }

}
