using UnityEngine;
using System.Collections;

public class GroungCheck : MonoBehaviour {
    void OnTriggerStay2D()
    {
        HeroControls.grounded = true;
    }

    void OnTriggerExit2D()
    {
        HeroControls.grounded = false;
    }
}
