using UnityEngine;
using System.Collections;

public class EnemyUnit : Unit {

    public GameObject HPBar;
    Transform child;
    public float verticalShift = 2;
    
    void Start()
    {
        curHP = hp;
        HPBar = Instantiate(HPBar, transform) as GameObject;
        HPBar.transform.parent = transform;
        HPBar.transform.position = new Vector2(transform.position.x, transform.position.y + verticalShift);
        child = HPBar.transform.GetChild(0);
        child.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
    }

    public override void setDeltaHP(int a)
    {
        base.setDeltaHP(a);
        child.localScale = new Vector2((float)curHP / hp, 1);
        child.gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)(255 - 255 * child.localScale.x), (byte)(255 * child.localScale.x), 0, 255);
        child.localPosition = new Vector2(-0.5f + 0.5f * (float)curHP / hp, 0);
    }
}
