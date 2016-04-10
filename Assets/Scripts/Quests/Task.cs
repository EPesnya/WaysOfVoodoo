using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System;
using System.Text;

public class Task : MonoBehaviour {

    public bool done = false;
    public GameObject QuestGiver;
    public bool hendedIn = false;
    public string name;
    public string description;
    public string target;

    public Task()
    {
        name = "QuestName";
        description = "Description";
        target = "Target";
    }

    public Task(int id)
    {
        StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Texts/Quests/" 
                                                        + id.ToString() + ".txt", Encoding.Default);
        name = file.ReadLine();
        description = file.ReadLine();
        target = file.ReadLine();
    }

}
