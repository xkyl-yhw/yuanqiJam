using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speed : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = information.speed;
        this.transform.Find("speed").GetComponent<Text>().text = information.speed.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {

    }
}
