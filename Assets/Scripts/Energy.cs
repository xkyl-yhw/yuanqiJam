using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Energy : MonoBehaviour
{

    void Start()
    {
        this.transform.GetComponent<Text>().text = information.energy.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
