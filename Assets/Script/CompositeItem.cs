using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeItem : MonoBehaviour
{
    public GameObject[] items;
    public GameObject compositeItem;

    // Update is called once per frame
    void Update()
    {
        if (AllItemsActive() && !compositeItem.activeSelf)
        {
            foreach (GameObject item in items)
            {
                item.SetActive(false);
            }
            compositeItem.SetActive(true);
        }
    }

    bool AllItemsActive()
    {
        foreach (GameObject item in items)
        {
            if (!item.activeSelf)
                return false;
        }
        return true;
    }
}
