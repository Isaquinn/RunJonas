using UnityEngine;
using System.Collections;

public class BotoesMenu : MonoBehaviour {
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            // Vai para a tela de selecao de fases
            if (hit.collider.tag == "Play")
            {
                Application.LoadLevel("SelecaoDeFases");
            }
            // Vai para a tela de instruções
            if (hit.collider.tag == "Instrucoes")
            {
                Application.LoadLevel("Instrucoes");
            }
            //Vai para a tela de créditos
            if (hit.collider.tag == "Creditos")
            {
                Application.LoadLevel("Creditos");
            }
        }
    }
    
}
