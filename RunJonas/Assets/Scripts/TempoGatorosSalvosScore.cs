using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TempoGatorosSalvosScore : MonoBehaviour {
    GameObject tempo;
    GameObject Score;
    public static GameObject criancasalva;
    public static float time;
    public static int temporal;
    public static int score = 0;
    float timescore;
    int eoq;
    int conversor;
    // Use this for initialization
    void Start () {
        score = 0;
        //Define o tempo limite da fase 1
        if (SelecaoDeFases.faseselecionada == 1)
        {
            time = 30;
            conversor = 30;
        }
        //Define o tempo limite da fase 2
        if (SelecaoDeFases.faseselecionada == 2)
        {
            time = 45;
            conversor = 45;
        }
        //Define o tempo limite da fase 3
        if (SelecaoDeFases.faseselecionada == 3)
        {
            time = 90;
            conversor = 90;
        }
        //Define o tempo limite da fase 4
        if (SelecaoDeFases.faseselecionada == 4)
        {
            time = 120;
            conversor = 120;
        }
        tempo = GameObject.Find("Canvas/Tempo");
        Score = GameObject.Find("Canvas/Score");
        criancasalva = GameObject.Find("Canvas/Garotos Salvos");

    }
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        temporal = Mathf.RoundToInt(time % conversor);
        tempo.gameObject.GetComponent<Text>().text = "Tempo: " + temporal.ToString();
        timescore += Time.deltaTime;
        if (temporal != 0)
        {
            if (timescore >= 1f)
            {
                score += 10;
                timescore = 0f;
            }
        }
        eoq = score;
        Score.gameObject.GetComponent<Text>().text = "Pontuacao: " + eoq.ToString();
    }
}
