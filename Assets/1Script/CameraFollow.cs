using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformコンポーネント

    private Vector3 offset; // カメラとプレイヤーの距離オフセット

    private void Start()
    {
        // カメラとプレイヤーの距離オフセットを計算
        offset = transform.position - player.position;
    }

    private void Update()
    {
        // カメラの位置をプレイヤーの位置にオフセットを加えて更新
        transform.position = player.position + offset;
    }
}

