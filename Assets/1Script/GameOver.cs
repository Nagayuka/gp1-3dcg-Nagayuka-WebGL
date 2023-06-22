using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioClip Bgm;
    public AudioClip nakigoe;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(Bgm);
        GetComponent<AudioSource>().PlayOneShot(nakigoe);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GAME");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GAMESTART");
        }

         //もしクリックしたらシーンを変える
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GAME");
        }       

    }
}
