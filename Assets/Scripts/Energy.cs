using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Energy : MonoBehaviour
{
    private GameObject car;//信息
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindWithTag("information");
        this.transform.GetComponent<Text>().text = car.GetComponent<information>().energy.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
