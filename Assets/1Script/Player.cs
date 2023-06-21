using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip oku;
    private Rigidbody PlayerRb;
    public float speed = 100f;
    public float dashMultiplier = 2f;
    public GameObject boxPrefab; // 箱のプレハブをアサインする
    private bool isDashing = false;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // プレイヤーの範囲制限
        if (transform.position.x < -70)
        {
            transform.position = new Vector3(-70, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -70)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -70);
        }

        if (transform.position.x > 70)
        {
            transform.position = new Vector3(70, transform.position.y, transform.position.z);
        }

        if (transform.position.z > 70)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 70);
        }




        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isDashing = true;
                PlayerRb.AddRelativeForce(Vector3.forward * speed * dashMultiplier);
            }
            else
            {
                isDashing = false;
                PlayerRb.AddRelativeForce(Vector3.forward * speed);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // 下キーを押した場合
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isDashing = true;
                PlayerRb.AddRelativeForce(-Vector3.forward * speed * dashMultiplier); // 後退方向に力を加える
            }
            else
            {
                isDashing = false;
                PlayerRb.AddRelativeForce(-Vector3.forward * speed); // 後退方向に力を加える
            }
        }
        else
        {
            Stop();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.5f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceBox();
        }
    }
    void Stop()
    {
        PlayerRb.velocity = Vector3.zero;
        PlayerRb.angularVelocity = Vector3.zero;
    }
    void PlaceBox()
    {
        // プレハブから箱を生成
        GameObject box = Instantiate(boxPrefab, transform.position + 5.0f * transform.forward, transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(oku);
    }


}


