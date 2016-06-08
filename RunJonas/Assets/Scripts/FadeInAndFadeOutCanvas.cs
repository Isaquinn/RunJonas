using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInAndFadeOutCanvas : MonoBehaviour {
   public static GameObject canvasfade;
    public static bool black = false;
    public static float fadeinspeed = 1f;
    public static float fadeoutspeed2 = 1f;
    public float minimum = 0.0f;
    public float maximum = 1f;
    // Use this for initialization
    void Start()
    {
        canvasfade = GameObject.Find("Canvas/fade");
        black = false;
        fadeinspeed = 1f;
        fadeoutspeed2 = 1f;
    }
    // Update is called once per frame
    void Update()
    {

        if (black == false)
        {
            fadeinspeed -= Time.deltaTime;
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, fadeinspeed));
        }
        else if (black == true)
        {
            canvasfade.SetActive(true);
            fadeoutspeed2 -= Time.deltaTime; ;
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, fadeoutspeed2));
        }
        if (fadeinspeed <= 0 && black == false)
        {
            canvasfade.SetActive(false);
        }



    }
}
