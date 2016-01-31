using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Application.LoadLevel("Mountains");
    }

}
