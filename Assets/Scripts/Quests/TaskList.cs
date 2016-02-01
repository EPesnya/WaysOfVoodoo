using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TaskList : MonoBehaviour {

    public List<Task> list;
    int count;

    public void AddTast(Task a)
    {
        list.Add(a);
        return;
    }

	void Start () 
    {
        Task asd = new Task();
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        count = list.Count;
        string s = "";
        for(int i = 0; i < count; i++)
        {
            s += list[i].done ? "notReady " : "Ready ";
            s += list[i].name + " " + list[i].description + " " + list[i].target + "\n";
        }
        this.GetComponent<Text>().text = s;
	}

	void Update () 
    {
	    
	}
}
