using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemList
{
    battery,
    motor,
    wire,
    iron,
    food,
    mask
}

public class purchaseItem : MonoBehaviour
{
    public itemList Item;

    public itemList item { get => Item; set => Item = value; }

    public void itemEffect()
    {
        switch (Item)
        {
            case itemList.battery:
                information.money -= 20;
                information.energy += 2;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            case itemList.food:
                information.money -= 30;
                information.food += 1;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            case itemList.wire:
                information.money -= 10;
                information.wire += 1;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            case itemList.mask:
                information.money -= 50;
                information.mask += 1;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            case itemList.motor:
                information.money -= 120;
                information.motor += 1;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            case itemList.iron:
                information.money -= 10;
                information.cutter += 1;
                GameManager.maxNumItem[(int)Item] -= 1;
                break;
            default:
                break;
        }
    }
}
