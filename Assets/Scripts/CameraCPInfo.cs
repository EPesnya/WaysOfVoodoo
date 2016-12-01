using UnityEngine;
using System.Collections;

public class CameraCPInfo : MonoBehaviour {

    public float SquareRadius;
    public float CameraScale;

    Vector2 prevPos;
    Vector2 curPos;
    GameObject Player;
    bool isThis;

    void Start()
    {
        Player = PlayerToolkit.Player;
    }

	void Update () 
    {
        curPos = Player.transform.position;
        if(curPos != prevPos)
        {
            if(Mathf.Pow(curPos.x - transform.position.x, 2) + Mathf.Pow(curPos.y - transform.position.y, 2) < SquareRadius)
            {
                CameraFollow.TargetPos = transform.position;
                CameraFollow.isFollowing = false;
                CameraFollow.targetScale = CameraScale;
                isThis = true;
            }
            else
            {
                if (isThis)
                {
                    CameraFollow.isFollowing = true;
                    isThis = false;
                }
            }

            prevPos = curPos;
        }
	}
}
