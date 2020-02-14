using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strengthup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;//信息
    void Start()
    {
        car = GameObject.FindWithTag("information");
        this.transform.Find("cutter").GetComponent<Text>().text = car.GetComponent<information>().cutter.ToString();
        this.transform.Find("wire2").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();
    }
    public void OnClick()
    {
        if (car.GetComponent<information>().cutter >= 2 && car.GetComponent<information>().wire >= 2)
        {
            car.GetComponent<information>().strength += 1;//提速
            car.GetComponent<information>().wire -= 2;
            car.GetComponent<information>().cutter-=2;//消耗材料
            this.transform.Find("cutter").GetComponent<Text>().text = car.GetComponent<information>().cutter.ToString();
            this.transform.Find("wire2").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();
            GameObject.Find("wire").GetComponent<Text>().text = car.GetComponent<information>().wire.ToString();//更新材料显示数据
            GameObject.Find("Slider_Strength").transform.GetComponent<Slider>().value = car.GetComponent<information>().strength;
            GameObject.Find("strength").transform.GetComponent<Text>().text = car.GetComponent<information>().strength.ToString();//更新速度


        }
        else
        {
            Debug.LogError("材料不够");//暂时不知道添加什么？
        }



    }
}