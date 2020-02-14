using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedup : MonoBehaviour
{ 
    public GameObject car;//信息
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindWithTag("information");
        this.transform.Find("motor").GetComponent<Text>().text = car.GetComponent<information>().motor.ToString();
        this.transform.Find("wire").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();
    }

    public void OnClick()
    {
        if(car.GetComponent<information>().motor >= 1&& car.GetComponent<information>().wire >= 3){
            car.GetComponent<information>().speed += 1;//提速
            car.GetComponent<information>().wire -= 3;
            car.GetComponent<information>().motor-=1;//消耗材料
            
            this.transform.Find("motor").GetComponent<Text>().text = car.GetComponent<information>().motor.ToString();
            GameObject.Find("wire2").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();//更新材料显示数据
            this.transform.Find("wire").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();//更新材料显示数据
            GameObject.Find("Slider_speed").transform.GetComponent<Slider>().value = car.GetComponent<information>().speed;
            GameObject.Find("speed").transform.GetComponent<Text>().text = car.GetComponent<information>().speed.ToString();//更新速度
        }
        else
        {
            Debug.LogError("材料不够");//暂时不知道添加什么？
        }

    }
}