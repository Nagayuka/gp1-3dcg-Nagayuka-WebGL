using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Bgm;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(Bgm);
    }

    // Update is called once per frame
    void Update()
    {
        //エンターキーを押したらシーンを変える
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GAME");
        }

    }
}
