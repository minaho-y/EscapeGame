using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapCollider : MonoBehaviour
{
    public string EnableCameraPositionName;
    // Start is called before the first frame update
    void Start()
    {
        var CurrentTrigger = gameObject.AddComponent<EventTrigger>();

        var EntryClick = new EventTrigger.Entry();
        EntryClick.eventID = EventTriggerType.PointerClick;
        EntryClick.callback.AddListener((x) => OnTap());

        CurrentTrigger.triggers.Add(EntryClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        // Debug.Log($"{name} Collider Enabled: {GetComponent<BoxCollider>().enabled}, カメラ位置: {CameraManager.Instance.CurrentPositionName}");

        if(EnableCameraPositionName == CameraManager.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
            else GetComponent<BoxCollider>().enabled = false;
    }

    /// <memo>
    /// "protected" : 継承クラスがアクセスできる
    /// "virtual" : 仮想関数．継承先で処理を上書きできる
    /// </memo>
    protected virtual void OnTap()
    {
        // Debug.Log($"Tapped: {gameObject.name}（現在のカメラ位置：{CameraManager.Instance.CurrentPositionName}）");
    }
}
