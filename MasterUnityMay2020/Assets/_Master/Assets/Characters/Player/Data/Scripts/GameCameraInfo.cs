using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GameCameraInfo : MonoBehaviour
{
    public static GameCameraInfo Instance;
    public Camera GameCamera { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);

        GameCamera = GetComponent<Camera>();
    }
}
