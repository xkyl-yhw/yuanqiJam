using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPerson : MonoBehaviour
{
    public float freeDistance = 5f;
    private Camera ThirdCam;
    public float rotateSpeed;
    public float upAngle = 80;
    public float moveSpeed = 10f;
    public Text PerText;

    private bool missionA1 = false;
    private int missionF1 = 0;

    private bool missionA2 = false;
    private int missionF2 = 0;

    private bool missionA3 = false;
    private int missionF3 = 0;

    private float rotDegree = 0;
    private float rollDegree = 30;
    private float rot, roll;
    [HideInInspector]
    public Vector3 moveDir, moveDirR;

    private void Start()
    {
        ThirdCam = Camera.main;
        missionA2 = false;
        missionA1 = false;
        missionA3 = false;
    }

    private void Update()
    {
        //cameraRot();
        //moveInput();
    }

    private void FixedUpdate()
    {
        //playerMove();

    }

    private void playerMove()
    {
        transform.Translate(moveDir * Time.fixedDeltaTime * moveSpeed);
    }

    private void moveInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDir = v * Vector3.ProjectOnPlane(ThirdCam.transform.forward, transform.up).normalized;
        moveDirR = h * Vector3.ProjectOnPlane(ThirdCam.transform.right, transform.up).normalized;
    }

    private void cameraRot()
    {
        float inputY = Input.GetAxis("Mouse Y");
        float inputX = Input.GetAxis("Mouse X");
        rotDegree -= inputX * rotateSpeed;
        rollDegree += inputY * rotateSpeed;
        rollDegree = Mathf.Clamp(rollDegree, -upAngle, upAngle);
        rot = rotDegree * Mathf.PI / 180;
        roll = rollDegree * Mathf.PI / 180;

        float d = freeDistance * Mathf.Cos(roll);
        float height = freeDistance * Mathf.Sin(roll);
        Vector3 cameraPos = Vector3.zero;

        cameraPos.x = transform.position.x + d * Mathf.Cos(rot);
        cameraPos.z = transform.position.z + d * Mathf.Sin(rot);
        cameraPos.y = transform.position.y + height;
        //Debug.Log(cameraPos);
        ThirdCam.transform.position = cameraPos;
        ThirdCam.transform.LookAt(this.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "shop")
        {
            if (missionA3)
            {
                missionF3++;
                PerText.gameObject.SetActive(true);
                PerText.text = "是你把这些东西送来的吗，谢谢你，你需要些什么吗？口罩？第"+GameManager.instance.maskDay+"天就会到货了，记得来买啊";
            }
            this.GetComponent<CarMove>().enabled = false;
            GameManager.instance.gameMenu.openShop();
        }
        else if (collision.collider.tag == "home")
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.collider.tag == "Person1" && !missionA3 && missionF3 < 1)
        {
            missionA3 = true;
            PerText.gameObject.SetActive(true);
            PerText.text = "你这是要去商店吗？如果你要去商店的话帮我把这箱东西送给商店的老板娘吧。她应该会给你点有用的信息的。";
        }
        else if (collision.collider.tag == "Person2" && !missionA1 && missionF1 < 2)
        {
            missionA1 = true;
            PerText.gameObject.SetActive(true);
            PerText.text = "你能帮我把这份通知送到工厂吗？谢谢你。就是这条路的尽头的红房子";
        }
        else if (collision.collider.tag == "Person3" && !missionA2 && missionF2 < 2)
        {
            PerText.gameObject.SetActive(true);
            PerText.text = "好厉害的小车，能帮我送点东西到城市里的工厂吗，到了那有人会给你报酬的。";
        }
        else if (collision.collider.tag == "factory" && missionA1)
        {
            PerText.gameObject.SetActive(true);
            PerText.text = "辛苦了，现在商店没什么东西卖，你的小车一定需要电池的吧，这两个电池就当你跑腿的酬劳吧";
            information.energy += 2;
            missionF1++;
        }
        else if (collision.collider.tag == "factory" && missionA2)
        {
            PerText.gameObject.SetActive(true);
            PerText.text = "你真是帮了大忙啊，这175金钱是给你的报酬。";
            information.money += 175;
            missionF2++;
        }
    }
}
