using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowingTheDescription : MonoBehaviour {

    public void SetText(string s)
    {
        GetComponent<Text>().text = s;
    }
}
