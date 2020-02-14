using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Strength : MonoBehaviour
{
    private GameObject car;//信息
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindWithTag("information");
        this.GetComponent<Slider>().value = car.GetComponent<information>().strength;
        this.transform.Find("strength").GetComponent<Text>().text = car.GetComponent<information>().strength.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
