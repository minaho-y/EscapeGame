using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    // シングルトン
    public static CameraManager Instance { get; private set; }

    /// <summary> 現在のカメラ位置名 </summary>
    public string CurrentPositionName { get; private set; }

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;

    /// <summary>
    /// カメラの位置情報クラス
    /// </summary>
    private class CameraPositionInfo
    {
        /// <summary> カメラの位置 </summary>
        public Vector3 Position { get; set; }
        /// <summary> カメラの角度 </summary>
        public Vector3 Rotate { get; set; }
        /// <summary> ボタンの移動先 </summary>
        public MoveNames MoveNames { get; set; }
    }

    /// <summary>
    /// ボタン移動先クラス
    /// </summary>
    private class MoveNames
    {
        /// <summary> 左ボタンを押したときの位置名 </summary>
        public string Left { get; set; }
        public string Right { get; set; }
        public string Back { get; set; }
    } 

    /// <summary>
    /// 全カメラ位置情報
    /// </summary>
    private Dictionary<string, CameraPositionInfo> _CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
    {
        {
            "Door", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomLeft",
                    Right = "RoomRight",
                }
            }
        },
        {
            "RoomLeft", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, -62, 0),
                MoveNames = new MoveNames
                {
                    Right = "Door",
                }
            }
        },
        {
            "RoomRight", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, 62, 0),
                MoveNames = new MoveNames
                {
                    Left = "Door",
                }
            }
        },
        {
            "SandBox", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-3, 2, 1),
                Rotate = new Vector3(38, -112, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft",
                }
            }
        },
        {
            "ItemBox", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-3, 2, 2),
                Rotate = new Vector3(21, -79, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft",
                }
            }
        },
        {
            "ItemBoxOpen", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-3, 2, 2),
                Rotate = new Vector3(21, -79, 0),
                MoveNames = new MoveNames
                {
                    Back = "ItemBox",
                }
            }
        },
        {
            "Sofa", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(4, 1, 1),
                Rotate = new Vector3(10, 52, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomRight",
                }
            }
        },
    };

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;    // シングルトン

        ChangeCameraPosition("Door");

        ButtonBack.GetComponent<Button>().onClick.AddListener(()=> 
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Back);
        });
        ButtonLeft.GetComponent<Button>().onClick.AddListener(()=> 
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Left);
        });
        ButtonRight.GetComponent<Button>().onClick.AddListener(()=> 
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Right);
        });
    }

    /// <summary>
    /// カメラ移動
    /// </summary>
    /// <param name="positionName"> カメラ位置名 </param>
    public void ChangeCameraPosition(string positionName)
    {
        if (positionName == null) return;

        CurrentPositionName = positionName; // 現在のカメラ位置名を更新

        GetComponent<Camera>().transform.position = _CameraPositionInfoes[CurrentPositionName].Position;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfoes[CurrentPositionName].Rotate);

        UpdateButtonActive();
    }

    /// <summary>
    /// 移動先がない場合ボタンを非表示
    /// </summary>
    private void UpdateButtonActive()
    {
        if(_CameraPositionInfoes[CurrentPositionName].MoveNames.Back == null)
            ButtonBack.SetActive(false);
        else ButtonBack.SetActive(true);
        if(_CameraPositionInfoes[CurrentPositionName].MoveNames.Left == null)
            ButtonLeft.SetActive(false);
        else ButtonLeft.SetActive(true);
        if(_CameraPositionInfoes[CurrentPositionName].MoveNames.Right == null)
            ButtonRight.SetActive(false);
        else ButtonRight.SetActive(true);
    }
}
