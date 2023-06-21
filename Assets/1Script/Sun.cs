using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject mansionLight;
    public GameObject mansionLight2;
    public GameObject mansionLight3;

    private Quaternion initialRotation = new Quaternion(-0.391588539f, 0.832828343f, -0.10423477f, 0.377081603f);
    private bool isDay = false;

    void Start()
    {
        transform.rotation = initialRotation;
    }

    void Update()
    {
        // 現在の回転角度を取得
        Quaternion rotation = transform.rotation;

        // Y軸周りに回転させる
        rotation *= Quaternion.Euler(0f, 6 * Time.deltaTime, 0f);

        // 回転後の角度を設定
        transform.rotation = rotation;

        float xAngle = transform.rotation.eulerAngles.x;

        
        if (xAngle >= 270f && xAngle <= 360f)
        {
            mansionLight.SetActive(true);
            mansionLight2.SetActive(true);
            mansionLight3.SetActive(true);

        }
        else
        {
            mansionLight.SetActive(false);
            mansionLight2.SetActive(false);
            mansionLight3.SetActive(false);

        }
    }
}
