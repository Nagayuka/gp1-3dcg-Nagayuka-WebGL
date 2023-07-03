using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;


    private Vector3 offset;

    void Start()
    {
        transform.LookAt(player.transform.position);

    }

    void LateUpdate()
    {

    }
}
