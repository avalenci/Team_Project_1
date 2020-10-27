using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCam : MonoBehaviour
{
    static public GameObject target;


    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Ball");
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, target.transform.position.x, 0.75f),
            transform.position.y,
            Mathf.Lerp(transform.position.z, target.transform.position.z, 0.75f));
    }
}
