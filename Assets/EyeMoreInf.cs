﻿using UnityEngine;
using System.Collections;

public class EyeMoreInf : MonoBehaviour
{
    private GameObject Field;
    public Sprite Text;
    public Sprite Speach;
    // Use this for initialization
    void Start()
    {
        Field = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(1).gameObject;
    }

    void OnMouseDown()
    {
        if (Text != null)
        {
            Field.GetComponent<SpriteRenderer>().sprite = Text;
            Field.SetActive(true);
            ListCloser.gObject = this.gameObject;
        }
        if (Speach != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = Speach;
        }

    }
}
