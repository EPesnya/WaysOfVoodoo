using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TaskList : MonoBehaviour {

    public List<Task> list;
    public List<Button> Buttons;
    int count;
    public int selected = 0;
    public GameObject DescriptionObject;

    public void AddTast(Task a)
    {
        return;
    }

	void Start () 
    {
        Task asd = new Task(0);
        list.Add(asd);
        list.Add(asd);
        list.Add(asd);
        count = list.Count;
        string s = "";
        for(int i = 0; i < count; i++)
        {
            s += list[i].done ? "Ready " : "notReady ";
            s += list[i].name + " " + list[i].target + "\n";
        }
        this.GetComponent<Text>().text = s;
	}
}
