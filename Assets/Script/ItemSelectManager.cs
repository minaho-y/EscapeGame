using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectManager : MonoBehaviour
{
    public TapItemChange[] AllItems;
    // private bool selected = false;

    void OnEnable()
    {
        TapItemChange.OnItemSelected += ResetSelection;
    }

    void OnDisable(){
        TapItemChange.OnItemSelected -= ResetSelection;
    }

    void ResetSelection(TapItemChange selectedItem)
    {
        foreach (var item in AllItems)
        {
            if (item != selectedItem)
            {
                item.ResetSelect();
                // Debug.Log("item : " + item + ", selectedItem : " + selectedItem);
            }
        }
    }
}
