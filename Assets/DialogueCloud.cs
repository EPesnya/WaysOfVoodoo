using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using System.Text;

public class DialogueCloud : MonoBehaviour {

    public int xSize, ySize, fontWidth, fontHeight;
    int countOfLines =  1;
    public string DialogueName;
    public Text textField;
    int curIndex = 0;
    public Transform anc1, anc2;
    string[] replicas;
    bool isPlayerFirst;
    int curReplica = 0;
    public GameObject TopBorder;
    public GameObject BottomBorder;
    public GameObject Parent;

 
    void SetText(string cur, bool isCharFirst)
    {
        textField.text = cur;
        if (isCharFirst)
        {
            transform.position = anc1.position;
        }
        else
        {
            transform.position = anc2.position;
        }
    }

    void Initialize(Text curText)
    {
		
        float ls = 1f;
        string s = curText.text;
        string[] ss = s.Split(' ');
		while(true)
		{
			float curC = 0;
			countOfLines = 1;
			int maxCountInLine = (int)Mathf.Round((xSize * ls) / (float)fontWidth);
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
			}
			if(ls * 4 >= countOfLines)
				break;
			else
				ls += 0.1f;
		}/*
		4 * 22
		lines = floor(ls * 4);
		width = 300 * ls;
		*/
        transform.localScale = new Vector2(ls, ls);
        curText.rectTransform.sizeDelta = new Vector2(190 * ls, 190 * ls);

        //TopBorder.transform.position = new Vector2(transform.position.x, transform.position.y + transform.localScale.y * 0.75f);
        //BottomBorder.transform.position = new Vector2(transform.position.x, transform.position.y - transform.localScale.y * 0.75f);
    }

	void Start ()
    {
        StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Texts/Conversations/"
                                                        + DialogueName + ".txt", Encoding.Default);
        string s = file.ReadLine();
        replicas = s.Split('/');
        SetText(replicas[0], isPlayerFirst);
        Initialize(textField);
	}
	
	void Update () 
    {

        textField.rectTransform.position =
            (Vector2)Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y, 0));
	    if(Input.GetMouseButtonDown(0))
        {
            if (replicas.Length > curReplica + 1)
            {
                curReplica++;
                isPlayerFirst = !isPlayerFirst;
                SetText(replicas[curReplica], isPlayerFirst);
                Initialize(textField);
            }
            else
            {
                Parent.SetActive(false);
            }
        }
	}
}

