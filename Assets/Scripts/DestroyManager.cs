using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private List<GameObject> destroyList = new List<GameObject>();

    public void AddDestroyList(GameObject obj)
    {
        destroyList.Add(obj);
    }

    public void AddDestroyList(List<GameObject> objList)
    {
        destroyList.AddRange(objList);
    }

    public void UpdateByFrame()
    {
        DestroyAll();
        ResetDestroyList();
    }

    private void ResetDestroyList()
    {
        destroyList.Clear();
    }

    private void DestroyAll()
    {
        if (destroyList.Count == 0) return;
        foreach(GameObject obj in destroyList)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }

    private void Destroy(GameObject obj)
    {
        obj.SetActive(false);
        Object.Destroy(obj);
    }


}
