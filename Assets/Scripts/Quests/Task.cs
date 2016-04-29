using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;

public class Task : MonoBehaviour {

    public int id;
    string name, description, target;
    
    void Start()
    {
        if (id != 0)
            SetTask(id);
        else
        {
            name = "QuestName";
            description = "Description";
            target = "Target";
        }
    }

    void OnMouseDown()
    {
        if (!TaskList.isQOpened)
            GameObject.FindGameObjectWithTag("TaskList").GetComponent<TaskList>().SetQuestTexts(description, target, name);
    }

    public void SetTask(int id)
    {
        StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Texts/Quests/" 
                                                        + id.ToString() + ".txt", Encoding.Default);
        name = file.ReadLine();
        description = file.ReadLine();
        target = file.ReadLine();
    }

}