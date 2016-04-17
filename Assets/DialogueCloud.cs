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

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 1000, 100), countOfLines.ToString());
    }

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
        textField.rectTransform.position =
            (Vector2)Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y, 0));
    }

    void Initialize(Text curText)
    {
        countOfLines = 1;
        string s = curText.text;
        string[] ss = s.Split(' ');
        int curC = 0;
        int maxCountInLine = xSize / fontWidth;
        for (int i = 0; i < ss.Length; i++)
        {
            if (curC + ss[i].Length <= maxCountInLine)
            {
                curC += (ss[i].Length + 1);
            }
            else
            {
                countOfLines++;
                curC = ss[i].Length + 1;
            }
        }
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
	    if(Input.GetMouseButtonDown(0))
        {
            curReplica++;
            isPlayerFirst = !isPlayerFirst;
            SetText(replicas[curReplica], isPlayerFirst);
            Initialize(textField);
        }
	}
}
