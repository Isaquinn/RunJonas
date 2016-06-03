using UnityEngine;
using System.Collections;

public class DerrotaOverdose : MonoBehaviour {
    void Start () {
	
	}
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            //Tenta de novo
            if (hit.collider.tag == "TentarDeNovo")
            {
                //Fase 1
                if (SelecaoDeFases.faseselecionada == 1)
                {
                    Application.LoadLevel("Fase1");
                }
                //Fase 2
                if (SelecaoDeFases.faseselecionada == 2)
                {
                    Application.LoadLevel("Fase2");
                }
                //Fase 3
                if (SelecaoDeFases.faseselecionada == 3)
                {
                    Application.LoadLevel("Fase3");
                }
            }
            // Vai para o Menu
            if (hit.collider.tag == "menu")
            {
                Application.LoadLevel("Menu");
            }
        }
    }
}
