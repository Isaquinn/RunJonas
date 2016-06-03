using UnityEngine;
using System.Collections;

public class Ganhou : MonoBehaviour {
    // Use this for initialization
	void Start ()
    {
	
	}
	// Update is called once per frame
	void Update ()
    {
       RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            //Proxima fase
            if (hit.collider.tag == "ProximaFase")
            {
                //Fase 2
                if (Personagem.novafase == 2)
                {
                    SelecaoDeFases.faseselecionada = 2;
                    PlayerPrefs.SetInt(SelecaoDeFases.faseselecionadafase, 2);
                    PlayerPrefs.Save();
                    Application.LoadLevel("Fase2");
                }
                //Fase 3
                if (Personagem.novafase == 3)
                {
                    SelecaoDeFases.faseselecionada = 3;
                    PlayerPrefs.SetInt(SelecaoDeFases.faseselecionadafase, 3);
                    PlayerPrefs.Save();
                    Application.LoadLevel("Fase3");
                }
            }
            //Menu
            if (hit.collider.tag == "menu")
            {
                Application.LoadLevel("Menu");
            }
        }
    }
}
