using UnityEngine;
using System.Collections;

public class Botoes : MonoBehaviour {
    public static bool pause;
    public static int numberpause = 0;
    // Use this for initialization
    void Start ()
    {
    }
    //Pausa o jogo caso click no botão pause
    public void PauseGame()
    {
        numberpause += 1;
    }
    // Update is called once per frame
    void Update () {
        //Gambiarra para pausar o jogo
        if (numberpause == 0)
        {
            pause = false;
        }
        else if (numberpause == 1)
        {
            pause = true;
        }
        else if (numberpause == 2)
        {
            pause = false;
            numberpause = 0;
        }
    }
}
