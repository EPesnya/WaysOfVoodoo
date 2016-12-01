using UnityEngine;
using System.Collections;

public abstract class EnemyUnit : Unit {

    public GameObject HPBar;
    public float verticalShift = 2;
    protected bool isPooled = false;
    protected float poolRange = 10;
    protected float movementSpeed = 1;
    protected float speedModifier = 1;
    protected Transform HPBarFill;
    protected GameObject Player;
    
    public virtual void OnPlayersMove()
    {
        if(!isPooled)
            isPooled = Mathf.Abs((int)(Player.transform.position - transform.position).x) < poolRange &&
                       Mathf.Abs((int)(Player.transform.position - transform.position).y) < poolRange;
    }

    protected void Init()
    {
        Player = PlayerToolkit.Player;
        curHP = hp;
        HPBar = Instantiate(HPBar, transform) as GameObject;
        HPBar.transform.parent = transform;
        HPBar.transform.position = new Vector2(transform.position.x, transform.position.y + verticalShift);
        HPBarFill = HPBar.transform.GetChild(0);
        HPBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
    }

    void Start()
    {
        Init();
    }

    public override void setDeltaHP(int a)
    {
        base.setDeltaHP(a);
        HPBarFill.localScale = new Vector2((float)curHP / hp, 1);
        HPBarFill.gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)(255 - 255 * HPBarFill.localScale.x), (byte)(255 * HPBarFill.localScale.x), 0, 255);
        HPBarFill.localPosition = new Vector2(-0.5f + 0.5f * (float)curHP / hp, 0);
    }
}
