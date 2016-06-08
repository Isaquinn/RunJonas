using UnityEngine;
using System.Collections;

public class SelecaoDeFases : MonoBehaviour {
    public static int faseselecionada = 1;
    public static int fase = 1;
    public static string fases = "fases";
    public static string faseselecionadafase = "fasesselecionada";
    private GameObject[] caixas = new GameObject[5];
    bool fase1, fase2, fase3;
    // Use this for initialization
    void Start () {
        fase = PlayerPrefs.GetInt(fases, 0);
        caixas[1] = GameObject.Find("Fase2");
        caixas[2] = GameObject.Find("Fase3");
        fase1 = false; fase2 = false; fase3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Muda o sprite da caixa da fase 2 caso ela seja desbloqueada
        if (fase == 2)
        {
            caixas[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("download");
        }
        //Muda o sprite da caixa da fase 3 caso ela seja desbloqueada
        if (fase == 3)
        {
            caixas[1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("download");
            caixas[2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("download");

        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButton(0))
        {
            //Caso clicaco na fase 1, abre a fase 1
            if (hit.collider.tag == "fase1")
            {
                fase1 = true;
                FadeInAndFadeOut.black = true;
                faseselecionada = 1;
                PlayerPrefs.SetInt(faseselecionadafase, 1);
                PlayerPrefs.Save();
            }
            //Caso a fase 2 seja liberada, podemos jogar ela ou até mesmo a fase 1 de novo
            if (fase == 2)
            {
                if (hit.collider.tag == "fase1")
                {
                    fase1 = true;
                    FadeInAndFadeOut.black = true;
                    faseselecionada = 1;
                    PlayerPrefs.SetInt(faseselecionadafase, 1);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase2")
                {
                    fase2 = true;
                    FadeInAndFadeOut.black = true;
                    faseselecionada = 2;
                    PlayerPrefs.SetInt(faseselecionadafase, 2);
                    PlayerPrefs.Save();
                }

            }
            //Caso a fase 3 seja liberada, podemos jogar ela ou até mesmo a fase 1 e a fase 2 de novo
            if (fase == 3)
            {
                if (hit.collider.tag == "fase1")
                {
                    fase1 = true;
                    FadeInAndFadeOut.black = true;
                    faseselecionada = 1;
                    PlayerPrefs.SetInt(faseselecionadafase, 1);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase2")
                {
                    fase2 = true;
                    FadeInAndFadeOut.black = true;
                    faseselecionada = 2;
                    PlayerPrefs.SetInt(faseselecionadafase, 2);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase3")
                {
                    fase3 = true;
                    FadeInAndFadeOut.black = true;
                    faseselecionada = 3;
                    PlayerPrefs.SetInt(faseselecionadafase, 3);
                    PlayerPrefs.Save();
                }

            }

        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && fase1 == true)
        {
            Application.LoadLevel("Fase1");

        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && fase2 == true)
        {
            Application.LoadLevel("Fase2");

        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && fase3 == true)
        {
            Application.LoadLevel("Fase3");

        }
    }
    
  
}
