using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Strength : MonoBehaviour
{

    void Start()
    {
        this.GetComponent<Slider>().value = information.strength;
        this.transform.Find("strength").GetComponent<Text>().text = information.strength.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
