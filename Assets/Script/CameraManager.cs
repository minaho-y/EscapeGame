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
            "Room1_Door", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    Left = "Room1_Left",
                    Right = "Room1_Right",
                }
            }
        },
        {
            "Room1_Left", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, -62, 0),
                MoveNames = new MoveNames
                {
                    Right = "Room1_Door",
                    Left = "Room1_Back",
                }
            }
        },
        {
            "Room1_Right", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, -2),
                Rotate = new Vector3(0, 62, 0),
                MoveNames = new MoveNames
                {
                    Left = "Room1_Door",
                    Right = "Room1_Back",
                }
            }
        },
        {
            "Room1_Back", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, 3),
                Rotate = new Vector3(0, 182, 0),
                MoveNames = new MoveNames
                {
                    Left = "Room1_Right",
                    Right = "Room1_Left",
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
                    Back = "Room1_Left",
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
                    Back = "Room1_Left",
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
                    Back = "Room1_Right",
                }
            }
        },
        {
            "CellBox", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-1, 3, -4),
                Rotate = new Vector3(83, 210, 0),
                MoveNames = new MoveNames
                {
                    Back = "Room1_Back",
                }
            }
        },
        {
            "CellBoxOpen", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-1, 3, -4),
                Rotate = new Vector3(83, 210, 0),
                MoveNames = new MoveNames
                {
                    Back = "CellBox",
                }
            }
        },
        {
            "BarCabinet", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 1, -3),
                Rotate = new Vector3(-3, 180, 0),
                MoveNames = new MoveNames
                {
                    Back = "Room1_Back",
                }
            }
        },
        {
            "Room2_Door", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, 5),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    // Back = "Room1_Door",
                    Left = "Room2_Left",
                    Right = "Room2_Right",
                }
            }
        },
        {
            "Room2_Left", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 2, 7),
                Rotate = new Vector3(0, -90, 0),
                MoveNames = new MoveNames
                {
                    Right = "Room2_Door",
                    Left = "Room2_Back",
                }
            }
        },
        {
            "Room2_Right", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-2, 2, 7),
                Rotate = new Vector3(0, 82, 0),
                MoveNames = new MoveNames
                {
                    Left = "Room2_Door",
                    Right = "Room2_Back",
                }
            }
        },
        {
            "Room2_Back", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(0, 2, 10),
                Rotate = new Vector3(0, 180, 0),
                MoveNames = new MoveNames
                {
                    Left = "Room2_Right",
                    Right = "Room2_Left",
                }
            }
        },
        {
            "Cabinet_Bird", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 2, 7),
                Rotate = new Vector3(28, 97, 0),
                MoveNames = new MoveNames
                {
                    Back = "Room2_Right",
                }
            }
        },
        {
            "Cabinet_Bird_Open", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 2, 7),
                Rotate = new Vector3(28, 97, 0),
                MoveNames = new MoveNames
                {
                    Back = "Cabinet_Bird",
                }
            }
        },
        {
            "Cabinet_Bird_BirdFocus", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(2, 3, 7),
                Rotate = new Vector3(50, 100, 0),
                MoveNames = new MoveNames
                {
                    Back = "Cabinet_Bird",
                }
            }
        },
        {
            "Cabinet_Bird_Bottom", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 1, 7),
                Rotate = new Vector3(5, 97, 0),
                MoveNames = new MoveNames
                {
                    Back = "Cabinet_Bird",
                }
            }
        },
        {
            "Cabinet_Bird_Bottom_Open", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(1, 1, 7),
                Rotate = new Vector3(5, 97, 0),
                MoveNames = new MoveNames
                {
                    Back = "Cabinet_Bird_Bottom",
                }
            }
        },
        {
            "Human", // 位置名
            new CameraPositionInfo
            {
                Position = new Vector3(-2, 2, 6),
                Rotate = new Vector3(32, 277, 0),
                MoveNames = new MoveNames
                {
                    Back = "Room2_Left",
                }
            }
        },
    };

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;    // シングルトン

        ChangeCameraPosition("Room1_Door");

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
