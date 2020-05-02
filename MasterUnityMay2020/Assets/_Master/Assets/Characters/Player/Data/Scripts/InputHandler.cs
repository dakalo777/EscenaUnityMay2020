using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Camera gameCamera= null;

    private void Start()
    {
        gameCamera = GameCameraInfo.Instance.GameCamera;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit, Mathf.Infinity, PlayerBrain.Instance.Settings.FloorMask))
            {
                PlayerBrain.Instance.MoveCommand(hit.point);
            }
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, PlayerBrain.Instance.Settings.EnemiesMask))
            {
                PlayerBrain.Instance.EnemySelected(hit.transform.gameObject);
            }
        }
    }
}
