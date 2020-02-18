using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day : MonoBehaviour
{
    void Start()
    {
        this.transform.GetComponent<Text>().text = information.day.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
