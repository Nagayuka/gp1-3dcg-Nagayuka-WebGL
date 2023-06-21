using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public AudioClip Bgm;
    public AudioClip YoruBgm;
    public float CountDown = 62f;
    public Text CountDownText;
    public float DayCount = 32f;
    public Text DayCountText;
    public float NightCount = 30f;
    public Text NightCountText;
    public GameObject BearPrefab;
    public GameObject Duck;
    public float distanceFromDuck = 100f;

    private bool bearSpawned = false; // Bearが出現したかどうかのフラグ

    void Start()
    {
        // BGMを再生する
        GetComponent<AudioSource>().PlayOneShot(Bgm);
    }

    void Update()
    {
        CountDown -= Time.deltaTime;
        CountDownText.text = CountDown.ToString("f0");

        DayCount -= Time.deltaTime;
        DayCountText.text = DayCount.ToString("f0");



        if (CountDown <= 30 && !bearSpawned)
        {
            SpawnBear();
            bearSpawned = true;
            // BGMを夜のものに変更する
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(YoruBgm);



        }

        if (CountDown <= 30)
        {

            NightCount -= Time.deltaTime;
            NightCountText.text = NightCount.ToString("f0");
        }

        if (CountDown <= 0)
        {
            SceneManager.LoadScene("GAMECREAR");
        }

        if (DayCount <= 0)
        {
            DayCountText.text = "NIGHT"; // DayCountが0になったらYORUと表示する
        }
    }

    void SpawnBear()
    {
        // Duckの位置から一定の距離離れた位置にBearを生成
        Vector3 duckPosition = Duck.transform.position;
        float randomX = Random.Range(duckPosition.x - distanceFromDuck, duckPosition.x + distanceFromDuck);
        float randomZ = Random.Range(duckPosition.z - distanceFromDuck, duckPosition.z + distanceFromDuck);
        Vector3 spawnPosition = new Vector3(randomX, 2f, randomZ);
        Instantiate(BearPrefab, spawnPosition, Quaternion.identity);
    }
}