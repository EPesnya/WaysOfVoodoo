using UnityEngine;
using System.Collections;

public class FireflyGeneration : MonoBehaviour {

    public int countOfFireflies = 10;
    //GameObject[] ff;
    public GameObject ffPrefab;

	void Start ()
    {
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;

        for(int i = 0; i < countOfFireflies; i++)
        {
            Instantiate(ffPrefab, new Vector3(Random.RandomRange(minX, maxX), Random.RandomRange(minY, maxY), 0), transform.rotation);
        }
	}
}
