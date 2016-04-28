using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TaskList : MonoBehaviour {

    GameObject[] list;
    int count;
    public GameObject DescriptionObject;
    GameObject cam;
    bool isOpened = false;
    Text QDescription;
    Text QName;
    Text QTarget;
    GameObject[] buttons;

    public void closeCurQuest()
    {
        QDescription.text = "";
        QName.text = "";
        QTarget.text = "";
        QTarget.gameObject.SetActive(false);
        QName.gameObject.SetActive(false);
        QDescription.gameObject.SetActive(false);
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
    }

    void OnMouseUp()
    {
        isOpened = !isOpened;
        for (int i = 0; i < count; i++)
        {
            list[i].SetActive(isOpened);
        }
    }

	void Start ()
    {
        QDescription = GameObject.FindGameObjectWithTag("QuestDescription").GetComponent<Text>();
        QName = GameObject.FindGameObjectWithTag("QuestName").GetComponent<Text>();
        QTarget = GameObject.FindGameObjectWithTag("QuestTarget").GetComponent<Text>();
        buttons = GameObject.FindGameObjectsWithTag("QuestButton");
        cam = Camera.main.gameObject;
        list = GameObject.FindGameObjectsWithTag("Task");
        int tmp = 0;
        foreach(GameObject t in list)
        {
            tmp++;
            t.transform.position = new Vector2(0, tmp) + (Vector2)transform.position;
            t.transform.parent = transform;
            t.SetActive(false);
        }
        count = tmp;
        QTarget.gameObject.SetActive(false);
        QName.gameObject.SetActive(false);
        QDescription.gameObject.SetActive(false);
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
	}

    public void SetQuestTexts(string d, string t, string n)
    {
        QDescription.gameObject.SetActive(true);
        QName.gameObject.SetActive(true);
        QTarget.gameObject.SetActive(true);
        QDescription.text = d;
        QName.text = n;
        QTarget.text = t;
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
    }

    void Update()
    {
        transform.position = (Vector2)cam.transform.position - new Vector2(-6, 3.5f);
    }

}
