using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DuckMotion : MonoBehaviour
{
    public AudioClip piyo;
    public float movementSpeed = 5f; // オブジェクトの移動速度
    public float rotationSpeed = 5f; // オブジェクトの回転速度

    private Vector3 targetPosition; // 目標位置
    private Quaternion targetRotation; // 目標回転

    // Start is called before the first frame update
    void Start()
    {
        // 初期の目標位置と回転を設定
        targetPosition = GenerateRandomPosition();
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // 目標位置に向かって移動する
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // 目標位置に到達したら新しい目標位置を生成
        if (transform.position == targetPosition)
        {
            targetPosition = GenerateRandomPosition();
        }

        // オブジェクトの進行方向に向きを滑らかに変える
        Quaternion lookRotation = Quaternion.LookRotation(targetPosition - transform.position);
        targetRotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;

        //死ぬ時にエフェクトつけようとしたけど挫折
        //もしy座標が10以上になったら
        // if (transform.position.y > 10)
        // {

        //     SceneManager.LoadScene("GAMEOVER");

        // }
    }

    // ランダムな位置を生成する
    Vector3 GenerateRandomPosition()
    {
        // x軸とz軸のランダムな値を生成して位置を作成
        float randomX = Random.Range(-15f, 15f);
        float randomZ = Random.Range(-15f, 15f);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }

    // 衝突した時に呼ばれる
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("衝突したオブジェクト名：" + collision.gameObject.name);

        // Renga(Clone)に衝突した場合
        if (collision.gameObject.name == "Renga(Clone)")
        {
            // Generate a new random position
            targetPosition = GenerateRandomPosition();
            GetComponent<AudioSource>().PlayOneShot(piyo);

        }
        if (collision.gameObject.name == "Player")
        {
            // randomPositionにマイナスをかけることで反転させる
            targetPosition = -targetPosition;
            GetComponent<AudioSource>().PlayOneShot(piyo);

        }

        if (collision.gameObject.name == "Bear_4(Clone)")
        {
            Debug.Log("GAMEOVER");
            SceneManager.LoadScene("GAMEOVER");

            //上に行く死ぬエフェクトはできなかった
            // transform.position = new Vector3(0, 1, 0);
        }


    }
}