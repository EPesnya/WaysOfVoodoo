using UnityEngine;
using System.Collections;

public class GroungCheck : MonoBehaviour {
    void OnTriggerEnter2D()
    {
        HeroControls.grounded = true;

    }

    void OnTriggerExit2D()
    {
        HeroControls.grounded = false;
    }
}
