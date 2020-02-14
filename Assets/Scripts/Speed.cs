using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speed : MonoBehaviour
{
    private GameObject car;//信息
  
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindWithTag("information");
        this.GetComponent<Slider>().value = car.GetComponent<information>().speed;
        this.transform.Find("speed").GetComponent<Text>().text = car.GetComponent<information>().speed.ToString();//每次加载场景会读取

    }

    // Update is called once per frame
    void Update()
    {

    }
}
