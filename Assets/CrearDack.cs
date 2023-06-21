using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearDack : MonoBehaviour
{
    public GameObject player;
    private Rigidbody PlayerRb;
    // Start is called before the first frame update
    void Start()
    {

        PlayerRb = GetComponent<Rigidbody>();
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // duckに向かって移動する
        
        PlayerRb.AddRelativeForce(Vector3.forward * 100);
        
    }
}
