using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip oku;
    public float speed = 15f;
    public float dashMultiplier = 2f;
    public GameObject boxPrefab;
    private bool isDashing = false;

    void Update()
    {
        // プレイヤーの範囲制限
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -70f, 70f);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -70f, 70f);
        transform.position = clampedPosition;

        // プレイヤーの移動
        Vector3 moveDirection = Vector3.zero;
        Quaternion targetRotation = transform.rotation;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += Vector3.forward;
            targetRotation = Quaternion.Euler(0f, 0f, 0f); // 上を向く
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection -= Vector3.forward;
            targetRotation = Quaternion.Euler(0f, 180f, 0f); // 下を向く
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector3.right;
            targetRotation = Quaternion.Euler(0f, 90f, 0f); // 右を向く
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection -= Vector3.right;
            targetRotation = Quaternion.Euler(0f, -90f, 0f); // 左を向く
        }

        if (moveDirection != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isDashing = true;
                transform.position += moveDirection.normalized * speed * dashMultiplier * Time.deltaTime;
            }
            else
            {
                isDashing = false;
                transform.position += moveDirection.normalized * speed * Time.deltaTime;
            }
        }
        else
        {
            Stop();
        }

        // プレイヤーの回転
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceBox();
        }
    }

    void Stop()
    {
        // プレイヤーの移動を停止
    }

    void PlaceBox()
    {
        // プレハブから箱を生成
        GameObject box = Instantiate(boxPrefab, transform.position + 5.0f * transform.forward, transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(oku);
    }
}
