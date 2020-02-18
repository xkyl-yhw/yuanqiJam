using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<Text>().text = information.money.ToString();//每次加载场景会读取
    }

    // Update is called once per frame
    void Update()
    {

    }
}
