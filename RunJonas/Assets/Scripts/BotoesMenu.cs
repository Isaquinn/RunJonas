using UnityEngine;
using System.Collections;

public class BotoesMenu : MonoBehaviour {
    bool play, instrucoes, creditos;
    void Start()
    {
        play = false;instrucoes = false;creditos = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (FadeInAndFadeOut.fadeinspeed <= 0f) {
            if (Input.GetMouseButtonUp(0))
            {
                // Vai para a tela de selecao de fases
                if (hit.collider.tag == "Play")
                {
                    play = true;
                    FadeInAndFadeOut.black = true;
                }
                // Vai para a tela de instruções
                if (hit.collider.tag == "Instrucoes")
                {
                    instrucoes = true;
                    FadeInAndFadeOut.black = true;
                }
                //Vai para a tela de créditos
                if (hit.collider.tag == "Creditos")
                {
                    creditos = true;
                    FadeInAndFadeOut.black = true;
                }
            }
        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && play == true)
        {
            Application.LoadLevel("SelecaoDeFases");
        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && instrucoes == true)
        {
            Application.LoadLevel("Instrucoes");
        }
        if (FadeInAndFadeOut.fadeoutspeed2 <= 0f && creditos == true)
        {
            Application.LoadLevel("Creditos");
        }
    }
    
}
