using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedup : MonoBehaviour
{ 

    void Start()
    {
        this.transform.Find("motor").GetComponent<Text>().text = information.motor.ToString();
        this.transform.Find("wire").GetComponent<Text>().text = information.wire.ToString();
    }

    public void OnClick()
    {
        if(information.motor >= 1&& information.wire >= 3){
            information.speed += 1;//提速
            information.wire -= 3;
            information.motor-=1;//消耗材料
            
            this.transform.Find("motor").GetComponent<Text>().text = information.motor.ToString();
            GameObject.Find("wire2").GetComponent<Text>().text = information.wire.ToString();//更新材料显示数据
            this.transform.Find("wire").GetComponent<Text>().text = information.wire.ToString();//更新材料显示数据
            GameObject.Find("Slider_speed").transform.GetComponent<Slider>().value = information.speed;
            GameObject.Find("speed").transform.GetComponent<Text>().text = information.speed.ToString();//更新速度
        }
        else
        {
            Debug.LogError("材料不够");//暂时不知道添加什么？
        }

    }
}