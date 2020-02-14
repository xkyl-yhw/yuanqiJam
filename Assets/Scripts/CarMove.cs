using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    float carSpeed = 20;//基础速度
    float addSpeed = 0;//通过装备增加的前进速度
    float roateSpeed = 30;//转动速度
    float weight = 0;//负重
    float friction = 0.5f;//摩擦系数
    private static CarMove _Instance;
    public static CarMove Instance
    {
        get
        {
            return _Instance;
        }
        
    }

    float h;
    float v;


    private void Awake()
    {
        _Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (v!=0)
        {
            PoCheck();
            float realspeed = RealSpeed();//计算真实速度
            print("realspeed"+realspeed);
            transform.Translate(Vector3.forward * Time.deltaTime*v*realspeed);
            if (h != 0)
            {
                if (v > 0)
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * h * roateSpeed);
                }
                else
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * h * roateSpeed*-1);
                }
            }
        }

    }

    //设置各项参数
    public void SetaddSpeee(float speed)
    {
        carSpeed += speed;
    }
    public void SetWeight(float weigth)
    {
        weight += weigth;
    }
    public void SetFriction(float a)
    {
        if (a < 1 && a > 0)
        {
            friction = a;
        }
    }
    public void SetRoateSpeed(float a)
    {
        if(a<60&&a>20)
        {
            roateSpeed = a;
        }
    }

    float RealSpeed()//计算真实速度
    {
        float sp = carSpeed+addSpeed - weight * friction;
        if (sp < 10)//保证有一个最小速度
        {
            sp = 10f;
        }
        return sp;
    }

    void PoCheck()//检测坡
    {
        Vector3 nextPos = transform.position;
        Ray thisray = new Ray(nextPos, Vector3.down);//将车本身的图层设为ignore
        RaycastHit hitme;
        if (Physics.Raycast(thisray, out hitme))
        {
            nextPos = hitme.point;//自己的位置
        }
        else
        {
        }
       

        float sp1 = RealSpeed();
        Vector3 tempPos = transform.rotation * Vector3.forward * sp1 * 0.1f;
        Vector3 realPos = nextPos + tempPos + new Vector3(0, 10, 0);
        Ray ray = new Ray(realPos, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null)
            {
                
            }
            else
            {
                realPos = hit.point;//得到下一步自己的位置  
            }
        }

        if(realPos.y>nextPos.y)//上坡
        {
            float xiebian = tempPos.magnitude;
            float zhibian = Mathf.Abs(realPos.y - nextPos.y); //直角边
            if (xiebian > zhibian && xiebian > 0 && zhibian > 0)
            {
                carSpeed = Mathf.Sqrt(xiebian * xiebian - zhibian * zhibian);//速度 
            }
            else
            {
                carSpeed = 20;
            }
        }
        else if(realPos.y == nextPos.y)//平地
        {
            carSpeed = 20;
        }
        else//下坡
        {
            carSpeed = 20;
        }
    }

}
