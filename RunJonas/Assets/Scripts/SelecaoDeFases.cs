using UnityEngine;
using System.Collections;

public class SelecaoDeFases : MonoBehaviour {
    public static int faseselecionada = 1;
    public static int fase = 1;
    public static string fases = "fases";
    public static string faseselecionadafase = "fasesselecionada";
    private GameObject[] caixas = new GameObject[5];
    // Use this for initialization
    void Start () {
        fase = PlayerPrefs.GetInt(fases, 0);
        caixas[1] = GameObject.Find("Fase2");
        caixas[2] = GameObject.Find("Fase3");
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
                Application.LoadLevel("Fase1");
                faseselecionada = 1;
                PlayerPrefs.SetInt(faseselecionadafase, 1);
                PlayerPrefs.Save();
            }
            //Caso a fase 2 seja liberada, podemos jogar ela ou até mesmo a fase 1 de novo
            if (fase == 2)
            {
                if (hit.collider.tag == "fase1")
                {
                    Application.LoadLevel("Fase2");
                    faseselecionada = 1;
                    PlayerPrefs.SetInt(faseselecionadafase, 1);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase2")
                {
                    Application.LoadLevel("Fase2");
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
                    Application.LoadLevel("Fase2");
                    faseselecionada = 1;
                    PlayerPrefs.SetInt(faseselecionadafase, 1);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase2")
                {
                    Application.LoadLevel("Fase2");
                    faseselecionada = 2;
                    PlayerPrefs.SetInt(faseselecionadafase, 2);
                    PlayerPrefs.Save();
                }
                if (hit.collider.tag == "fase3")
                {
                    Application.LoadLevel("Fase3");
                    faseselecionada = 3;
                    PlayerPrefs.SetInt(faseselecionadafase, 3);
                    PlayerPrefs.Save();
                }

            }

        }
    }
    
  
}
