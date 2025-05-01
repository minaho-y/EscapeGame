using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    public string OpenPositionName;

    public GameObject Drawer;
    private Vector3 origin_pos;
    private Vector3 move_pos;

    // Start is called before the first frame update
    void Start()
    {
        origin_pos = Drawer.transform.position;
        move_pos = origin_pos;
        move_pos.x = origin_pos.x - 0.58f;
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenPositionName == CameraManager.Instance.CurrentPositionName)
            Drawer.transform.position = move_pos;
        else Drawer.transform.position = origin_pos;
    }
}
