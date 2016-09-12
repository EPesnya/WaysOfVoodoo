﻿using UnityEngine;
using System.Collections;

public class AbilitiesControl : MonoBehaviour {

    public GameObject FireBall;

    float lastCastTime;
    float globalCooldown = 1;

    float lastFrameTime;

    float fireResource = 100;
    float waterResource = 100;
    float windResource = 100;
    float earthResource = 100;
    float curFireResource = 100;
    float curWaterResource = 100;
    float curWindResource = 100;
    float curEarthResource = 100;

    Transform fireResourceBar;
    Transform fireResourceBarFill;
    Transform waterResourceBar;
    Transform waterResourceBarFill;
    Transform windResourceBar;
    Transform windResourceBarFill;
    Transform earthResourceBar;
    Transform earthResourceBarFill;

	void Start () 
    {
        lastCastTime = -10;
        fireResourceBar = Camera.main.transform.GetChild(0);
        fireResourceBarFill = fireResourceBar.transform.GetChild(0);
        fireResourceBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(240, 44, 16, 255);//??
        waterResourceBar = Camera.main.transform.GetChild(1);
        waterResourceBarFill = waterResourceBar.transform.GetChild(0);
        waterResourceBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(35, 137, 208, 255);//??
        windResourceBar = Camera.main.transform.GetChild(2);
        windResourceBarFill = windResourceBar.transform.GetChild(0);
        windResourceBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(126, 180, 155, 255);//??
        earthResourceBar = Camera.main.transform.GetChild(3);
        earthResourceBarFill = earthResourceBar.transform.GetChild(0);
        earthResourceBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(45, 128, 30, 255);//??
	}
	
    void setBarFill(Transform barFill, float part)
    {
        barFill.localScale = new Vector2(part, 1);
        barFill.localPosition = new Vector2(-0.5f + 0.5f * part, 0);
    }

	void Update () 
    {
        if (Time.time - lastCastTime > globalCooldown)
        {
            if (Input.GetKeyDown("r") && curFireResource > 25) //25 заменить на манакост
            {
                GameObject tmp;
                tmp = Instantiate(FireBall, this.transform) as GameObject;
                tmp.transform.position = new Vector2(transform.position.x + transform.localScale.x, transform.position.y);
                tmp.transform.parent = null;
                tmp.transform.localScale = new Vector3(3, 3, 1); //???
                tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(25 * transform.localScale.x, 0);
                lastCastTime = Time.time;
                curFireResource -= 25; //
            }
        }
        float delta = Time.time - lastFrameTime;
        delta *= 5;
        curFireResource += delta;
        curWaterResource += delta;
        curWindResource += delta;
        curEarthResource += delta;
        if (curFireResource > fireResource)
            curFireResource = fireResource;
        if (curWaterResource > waterResource)
            curWaterResource = waterResource;
        if (curWindResource > windResource)
            curWindResource = windResource;
        if (curEarthResource > earthResource)
            curEarthResource = earthResource;
        setBarFill(fireResourceBarFill, curFireResource / (float)fireResource);
        setBarFill(waterResourceBarFill, curWaterResource / (float)waterResource);
        setBarFill(windResourceBarFill, curWindResource / (float)windResource);
        setBarFill(earthResourceBarFill, curEarthResource / (float)earthResource);
        lastFrameTime = Time.time;
	}
}
