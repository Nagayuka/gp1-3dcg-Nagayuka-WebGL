using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // カメラとプレイヤーの距離オフセット
    float kyori; // カメラとプレイヤーの距離

    // Start is called before the first frame update
    void Start()
    {
        // カメラとプレイヤーの距離を取得
        offset = transform.position - player.transform.position;
        // kyori = (transform.position - player.transform.position).magnitude;
    }

    void Update(){
        transform.LookAt(player.transform.position);

        // transform.eulerAngles = player.transform.eulerAngles; // cubeの回転をplaneに適用
        // Vector3 up = Vector3.up;
        // up = transform.TransformDirection(up);
        // transform.position = player.transform.position + up*kyori; 


    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // カメラの位置をプレイヤーに追従させる
        transform.position = player.transform.position + offset;
    }
}
