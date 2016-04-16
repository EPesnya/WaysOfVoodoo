using UnityEngine;
using System.Collections;

public class ListCloser : MonoBehaviour
{
    public static GameObject gObject;
    void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }
}
