using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform targetpos;//跟随的目标
    Vector3 offestpos;//固定位置
    Vector3 temppos;//临时变量
    void Start()
    {
        offestpos = new Vector3(0,1,-5.5f);
        targetpos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temppos = targetpos.position + targetpos.TransformDirection(offestpos);
        transform.position = Vector3.Lerp(transform.position, temppos, Time.fixedDeltaTime * 3);
        transform.LookAt(targetpos);
    }
}
