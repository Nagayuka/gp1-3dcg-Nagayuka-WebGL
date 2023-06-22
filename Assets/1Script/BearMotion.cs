using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMotion : MonoBehaviour
{
    public AudioClip nakigoe;

    public GameObject duck;
    private Rigidbody PlayerRb;
    public float speed = 5f;
    int n = 0;
    bool isResetting = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    // 衝突した時に呼ばれる
    void OnCollisionEnter(Collision collision)
    {
        // Renga(Clone)に衝突した場合
        if (collision.gameObject.name == "Renga(Clone)")
        {
            n = 1;
            StartCoroutine(ResetNAfterDelay(1f)); // 1秒後にnをリセットする

            GetComponent<AudioSource>().PlayOneShot(nakigoe);

        }else{
            n=2;
        }
    }

    IEnumerator ResetNAfterDelay(float delay)
    {
        if (isResetting) yield break; // 既にリセット処理中ならば終了する

        isResetting = true;
        yield return new WaitForSeconds(delay);

        n = 0;
        isResetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (n == 1)//ぶつかった時は後ろに下がる
        {
            PlayerRb.AddRelativeForce(-Vector3.forward * speed);
            transform.Rotate(0, 0.5f, 0);
        }else if(n==2)//右に少しズレる
        {
            PlayerRb.AddRelativeForce(Vector3.right * speed);
            n=0;
        }
        else
        {
            // duckに向かって移動する
            transform.LookAt(duck.transform.position);

            PlayerRb.AddRelativeForce(Vector3.forward * speed);
        }
    }
}
