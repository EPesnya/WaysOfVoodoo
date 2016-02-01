using UnityEngine;
using System.Collections;

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

}
