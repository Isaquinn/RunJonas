using UnityEngine;
using System.Collections;

public class FadeInAndFadeOut : MonoBehaviour {
    public static bool black = false;
    public static float fadeinspeed = 1f;
    public static float fadeoutspeed2 = 1f;
    public float minimum = 0.0f;
    public float maximum = 1f;
    // Use this for initialization
    void Start ()
    {
        minimum = 0.0f;
        maximum = 1f;
        black = false;
        fadeinspeed = 1f;
        fadeoutspeed2 = 1f;
     }
	// Update is called once per frame
	void Update () {
        Debug.Log(black);
        Debug.Log(fadeinspeed);
        if (black == false)
        {
            fadeinspeed -= Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, fadeinspeed));
        }
        else if (black == true)
        {
            fadeoutspeed2 -= Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep( maximum, minimum, fadeoutspeed2));
        }
        

    }
}
