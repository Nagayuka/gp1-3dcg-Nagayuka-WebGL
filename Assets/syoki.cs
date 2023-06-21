using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syoki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(15, 15, 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
