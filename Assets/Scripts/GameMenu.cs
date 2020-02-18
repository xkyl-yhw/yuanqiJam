using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Text coinsText;
    public GameObject shopMenu;
    public GameObject[] insForItems;

    List<GameObject> shopList = new List<GameObject>();


    private void Start()
    {
        //shopInitMethod();
    }

    private void Update()
    {
        coinsText.text = GameManager.instance.coins.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            checkItem();
        }
    }

    public void checkItem()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            foreach (RaycastResult item in results)
            {
                if (item.gameObject.GetComponent<purchaseItem>() != null)
                {
                    item.gameObject.GetComponent<purchaseItem>().itemEffect();
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

    public void closeShop()
    {
        shopList.Clear();
        for (int i = 0; i < shopMenu.transform.childCount; i++)
        {
            Destroy(shopMenu.transform.GetChild(0).GetChild(i).gameObject);
        }
        shopMenu.SetActive(false);
        SceneManager.LoadScene(0);

    }


    public void shopInitMethod()
    {
        shopMenu.SetActive(true);
        if (GameManager.maxNumItem[(int)itemList.wire] > 0)
        {
            shopList.Add(insForItems[(int)itemList.wire]);
        }
        if (GameManager.maxNumItem[(int)itemList.iron] > 0)
        {
            shopList.Add(insForItems[(int)itemList.iron]);
        }
        if (GameManager.maxNumItem[(int)itemList.food] > 0)
        {
            shopList.Add(insForItems[(int)itemList.food]);
        }
        if (GameManager.maxNumItem[(int)itemList.battery] > 0)
        {
            shopList.Add(insForItems[(int)itemList.battery]);
        }
        if (GameManager.maxNumItem[(int)itemList.mask] > 0 && GameManager.instance.createMask)
        {
            shopList.Add(insForItems[(int)itemList.mask]);
        }
        if (GameManager.maxNumItem[(int)itemList.motor] > 0 && GameManager.instance.createMotor)
        {
            shopList.Add(insForItems[(int)itemList.motor]);
        }
        for (int i = 0; i < shopList.Count; i++)
        {
            Instantiate(shopList[i], shopMenu.transform.GetChild(0).transform);
        }
    }
}
