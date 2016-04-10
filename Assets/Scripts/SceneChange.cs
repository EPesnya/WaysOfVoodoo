using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    public string SceneName;
    GameObject ExitObject;

    void Start()
    {
        ExitObject = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter2D()
    {
        ExitObject.SetActive(true);
    }

    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown("e"))
            Application.LoadLevel(SceneName);
    }

    void OnTriggerExit2D()
    {
        ExitObject.SetActive(false);
    }

}
