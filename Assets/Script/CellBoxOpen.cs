using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBoxOpen : MonoBehaviour
{
    public string OpenPositionName;

    public GameObject Lid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenPositionName == CameraManager.Instance.CurrentPositionName)
            Lid.SetActive(false);
        else Lid.SetActive(true);
    }
}
