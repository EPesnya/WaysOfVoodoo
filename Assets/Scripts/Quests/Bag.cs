using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bag : MonoBehaviour {

    List<Item> ItemList;
    BagCell[] BagCells = new BagCell[100];
    public int itemCount;

    public void addItem(Item a)
    {
        bool isExist = false;
        foreach(Item i in ItemList)
        {
            if(i.id == a.id)
            {
                isExist = true;
                i.count += a.count;
            }
        }
        if(!isExist)
        {
            ItemList.Add(a);
            itemCount++;
        }
        return;
    }

    public bool isInBag(Item a)
    {
        bool k = false;
        foreach (Item i in ItemList)
        {
            if (i.id == a.id)
            {
                k = true;
            }
        }
        return k;
    }

	void Start () 
    {
        itemCount = ItemList.Count;
	    for(int i = 0; i < 100; i++)
        {
            BagCells[i].empty = true;
        }
        for(int i = 0; i < itemCount; i++)
        {
            BagCells[i].empty = false;
            BagCells[i].itemInCell = ItemList[i];
        }
	}
	
	void Update () 
    {
	
	}
}
