using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = Vector3.zero;
        angle.z = 30.0f * Mathf.Sin(Time.time * 5.0f)-90.0f;
        transform.eulerAngles = angle;

    }
}
