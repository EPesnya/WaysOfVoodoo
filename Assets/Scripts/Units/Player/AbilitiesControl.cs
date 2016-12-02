using UnityEngine;
using System.Collections;

public class AbilitiesControl : MonoBehaviour {

    public GameObject FireBall;
    public GameObject FireTotem;

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

    Transform GCDResourceBar;
    Transform GCDResourceBarFill;
    
    Transform DamageMask;


    float guiScale = 1;
    float normalDepth;
    float normalLocalScale = 5;

    float lastUseOfWindwalk = -10;
    bool isWindwalkActive = false;

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
        GCDResourceBar = Camera.main.transform.GetChild(4);
        GCDResourceBarFill = GCDResourceBar.transform.GetChild(0);
        GCDResourceBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);//??
        DamageMask = Camera.main.transform.GetChild(7);
        normalDepth = Camera.main.orthographicSize;
	}
	
    void setBarFill(Transform barFill, float part)
    {
        barFill.localScale = new Vector2(part, 1);
        barFill.localPosition = new Vector2(-0.5f + 0.5f * part, 0);
    }

	void Update () 
    {
        guiScale = Camera.main.orthographicSize / normalDepth;
        Vector2 ScaleVector = new Vector2(normalLocalScale * guiScale, normalLocalScale * guiScale);
        fireResourceBar.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height * 0.05f));
        fireResourceBar.position = new Vector3(fireResourceBar.transform.position.x, fireResourceBar.transform.position.y, 0);
        fireResourceBar.localScale = ScaleVector;
        waterResourceBar.position = new Vector3(fireResourceBar.transform.position.x, fireResourceBar.transform.position.y + 0.5f * guiScale, 0);
        waterResourceBar.localScale = ScaleVector;
        windResourceBar.position = new Vector3(fireResourceBar.transform.position.x, fireResourceBar.transform.position.y + 1f * guiScale, 0);
        windResourceBar.localScale = ScaleVector;
        earthResourceBar.position = new Vector3(fireResourceBar.transform.position.x, fireResourceBar.transform.position.y + 1.5f * guiScale, 0);
        earthResourceBar.localScale = ScaleVector;
        GCDResourceBar.position = new Vector3(fireResourceBar.transform.position.x, fireResourceBar.transform.position.y + 2.1f * guiScale, 0);
        GCDResourceBar.localScale = ScaleVector;
        DamageMask.localScale = ScaleVector / 5.0f;
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
            if (Input.GetKeyDown("t") && curFireResource > 50) //50 заменить на манакост
            {
                GameObject tmp;
                tmp = Instantiate(FireTotem, this.transform) as GameObject;
                tmp.transform.position = new Vector2(transform.position.x, transform.position.y);
                tmp.transform.parent = null;
                lastCastTime = Time.time;
                curFireResource -= 50; //
            }
            if (Input.GetKeyDown("q") && curWindResource > 50)
            {
                GetComponent<HeroControls>().speedModifier += 0.5f;
                lastCastTime = Time.time;
                curWindResource -= 50;
                lastUseOfWindwalk = Time.time;
                isWindwalkActive = true;
            }
            if (Input.GetKeyDown("e") && curWindResource > 50)
            {
                lastCastTime = Time.time;
                foreach(GameObject g in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    float t = (1 / Vector2.SqrMagnitude(g.transform.position - transform.position)) * 5000;
                    Vector2 normalVector = (g.transform.position - transform.position).normalized;
                    g.GetComponent<Rigidbody2D>().AddForce(normalVector * t);
                }
                curWindResource -= 50;
            }
        }
        if (isWindwalkActive && Time.time - lastUseOfWindwalk > 5)
        {
            GetComponent<HeroControls>().speedModifier -= 0.5f;
            isWindwalkActive = false;
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
        setBarFill(GCDResourceBarFill, (Time.time - lastCastTime > 1) ? 1 : Time.time - lastCastTime);
        lastFrameTime = Time.time;
	}
}
