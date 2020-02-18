using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int numOfshuop = 3;
    public GameObject shopIns;
    private Vector3 startPos = new Vector3(-7, 0, -18);
    int[,] placeMarker = new int[8, 6];
    public GameObject[] buildingIns;

    public int day;
    public int coins;
    private float preTime;
    public float onceTime = 30;
    public bool createMotor = false;
    public bool createMask = false;
    [HideInInspector]
    public GameMenu gameMenu;
    public Text timeUi;
    public int maskDay = 0;

    [SerializeField]
    public static int[] maxNumItem = { 4, 1, 5, 2, 6, 1 };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        createCity();
        information.day++;
        information.energy -= 2;
        information.food--;
        if (information.food < 0)
        {
            SceneManager.LoadScene(2);
        }

        preTime = Time.time;
        gameMenu = GameObject.FindObjectOfType<GameMenu>().GetComponent<GameMenu>();
        createMotor = false;
        createMask = false;

        if (maxNumItem[(int)itemList.motor] > 0)
        {
            if (day > 2 && day < 4)
            {
                createMotor = Random.value > 0.5;

            }
            else if (day >= 4 && day <= 6)
            {
                createMotor = true;
            }
        }
        if (maskDay == 0)
        {
            maskDay = Random.Range(5, 9);
        }

        if (maxNumItem[(int)itemList.mask] > 0)
        {
            if (day >= maskDay)
            {
                createMask = true;
            }
        }
    }

    private void Update()
    {
        if (information.mask == 1)
        {
            SceneManager.LoadScene(3);
        }
        day = information.day;
        coins = information.money;
        if (Time.time - preTime < onceTime)
        {
            timeUi.text = (onceTime - (int)(Time.time - preTime)).ToString();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void createCity()
    {
        for (int i = 0; i < placeMarker.GetLength(0); i++)
        {
            for (int j = 0; j < placeMarker.GetLength(1); j++)
            {
                placeMarker[i, j] = 0;
            }
        }
        for (int i = 0; i < numOfshuop; i++)
        {
            int x = Random.Range(1, 9);
            int y = Random.Range(1, 7);
            if (placeMarker[x - 1, y - 1] != 1)
                Instantiate(shopIns, startPos + new Vector3((int)(x / 2) * 12 + (x % 2 == 0 ? -1 : 1) * 4, 0, (int)(y / 2) * 12 + (y % 2 == 0 ? -1 : 1) * 4), Quaternion.identity);
            placeMarker[x - 1, y - 1] = 1;
        }
        for (int i = 0; i < placeMarker.GetLength(0); i++)
        {
            for (int j = 0; j < placeMarker.GetLength(1); j++)
            {
                if (placeMarker[i, j] == 0)
                {
                    int ramdonNum = Random.Range(0, buildingIns.Length);
                    Instantiate(buildingIns[ramdonNum], startPos + new Vector3((int)((i + 1) / 2) * 12 + ((i + 1) % 2 == 0 ? -1 : 1) * 4, 0, (int)((j + 1) / 2) * 12 + ((j + 1) % 2 == 0 ? -1 : 1) * 4), Quaternion.identity);
                }
            }
        }
    }
}
