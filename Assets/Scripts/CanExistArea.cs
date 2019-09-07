using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanExistArea : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.destroyManager.AddDestroyList(collision.gameObject);
    }

}
