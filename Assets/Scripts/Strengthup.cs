using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strengthup : MonoBehaviour
{

    void Start()
    {
        this.transform.Find("cutter").GetComponent<Text>().text = information.cutter.ToString();
        this.transform.Find("wire2").GetComponent<Text>().text = information.wire.ToString();
    }
    public void OnClick()
    {
        if (information.cutter >= 2 && information.wire >= 2)
        {
            information.strength += 1;//提速
            information.wire -= 2;
            information.cutter-=2;//消耗材料
            this.transform.Find("cutter").GetComponent<Text>().text = information.cutter.ToString();
            this.transform.Find("wire2").GetComponent<Text>().text = information.wire.ToString();
            GameObject.Find("wire").GetComponent<Text>().text = information.wire.ToString();//更新材料显示数据
            GameObject.Find("Slider_Strength").transform.GetComponent<Slider>().value = information.strength;
            GameObject.Find("strength").transform.GetComponent<Text>().text = information.strength.ToString();//更新速度
        }
        else
        {
            Debug.LogError("材料不够");//暂时不知道添加什么？
        }
    }
}