using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapItemChange : TapCollider
{
    public int Index { get; private set; }

    public GameObject[] Items;
    public static event System.Action<TapItemChange> OnItemSelected;

    void OnEnable()
    {
        Index = 0;
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] != null)
                Items[i].SetActive(i == Index);
        }
    }
    
    protected override void OnTap(){
        base.OnTap();

        Items[Index].SetActive(false);

        Index++;
        if(Index >= Items.Length)
            Index = 0;

        Items[Index].SetActive(true);

        OnItemSelected?.Invoke(this);
    }

     public void ResetSelect()
    {
        Items[Index].SetActive(false);
        Index = 0;
        Items[Index].SetActive(true);
    }
}
