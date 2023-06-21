using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RengaChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool hasCollided = false;
    private int collisionCount = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.name == "Bear_4(Clone)")
        {
            hasCollided = true;
            collisionCount++;

            if (collisionCount == 1)
            {
                // 色を黄色に変える
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            else if (collisionCount == 2)
            {
                // 色を赤に変える
                GetComponent<Renderer>().material.color = Color.red;
            }
            else if (collisionCount == 3)
            {
                // オブジェクトを消す
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (hasCollided && collision.gameObject.name == "Bear_4(Clone)")
        {
            hasCollided = false;
        }
    }
}








