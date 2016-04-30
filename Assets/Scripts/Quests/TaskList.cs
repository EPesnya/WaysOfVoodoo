using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TaskList : MonoBehaviour {

    GameObject[] list;
    int count;
    public GameObject DescriptionObject;
    GameObject cam;
    public static bool isOpened = false;
    public static bool isQOpened = false;
    Text QDescription;
    Text QName;
    Text QTarget;
    GameObject[] buttons;
    int selectedPage = 0;
    int countOfPages = 0;
    string[] Pages = new string[5];
    GameObject[] bImages;

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
        bImages[0].SetActive(false);
        bImages[1].SetActive(false);
        bImages[2].SetActive(false);
        for (int i = 0; i < 5; i++)
            Pages[i] = "";
        TaskList.isQOpened = false;
    }

    public void TriggerChildren()
    {
        TaskList.isOpened = !TaskList.isOpened;
        for (int i = 0; i < count; i++)
        {
            list[i].SetActive(TaskList.isOpened);
        }
    }

    void OnMouseUp()
    {
        TriggerChildren();
    }

	void Start ()
    {
        QDescription = GameObject.FindGameObjectWithTag("QuestDescription").GetComponent<Text>();
        QName = GameObject.FindGameObjectWithTag("QuestName").GetComponent<Text>();
        QTarget = GameObject.FindGameObjectWithTag("QuestTarget").GetComponent<Text>();
        buttons = GameObject.FindGameObjectsWithTag("QuestButton");
        bImages = GameObject.FindGameObjectsWithTag("QuestBackground");

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
        bImages[0].SetActive(false);
        bImages[1].SetActive(false);
        bImages[2].SetActive(false);
	}

    public void SetQuestTexts(string d, string t, string n)
    {
        QDescription.gameObject.SetActive(true);
        QName.gameObject.SetActive(true);
        QTarget.gameObject.SetActive(true);

        int maxCountOfLines = 13;
        int fontWidth = 14;
        int xSize = 600;
        int maxCountInLine = xSize / fontWidth;
        string[] ss = d.Split(' ');
        float curC = 0;
        int countOfLines = 0;
        int curI = 0;

        for (int i = 0; i < ss.Length; i++)
        {
            if (curC + ss[i].Length <= maxCountInLine)
            {
                curC += (ss[i].Length + 0.35f);
            }
            else
            {
                countOfLines++;
                curC = ss[i].Length + 0.35f;
            }
            if (countOfLines >= maxCountOfLines)
            {
                curI++;
                countOfLines = 0;
            }
            Pages[curI] += (ss[i] + ' ');
        }
        countOfPages = curI + 1;


        ResetDescription(Pages[selectedPage]);
        QName.text = n;
        QTarget.text = t;
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        bImages[0].SetActive(true);
        bImages[1].SetActive(true);
        bImages[2].SetActive(true);
        TaskList.isQOpened = true;
        TriggerChildren();
    }

    void ResetDescription(string d)
    {
        QDescription.text = d;
    }

    public void incPage()
    {
        if (selectedPage + 1 < countOfPages)
        {
            selectedPage++;
            ResetDescription(Pages[selectedPage]);
        }
    }
    public void decPage()
    {
        if (selectedPage - 1 > -1)
        {
            selectedPage--;
            ResetDescription(Pages[selectedPage]);
        }
    }

    void Update()
    {
        transform.position = (Vector2)cam.transform.position - new Vector2(-6, 3.5f);
    }

}
