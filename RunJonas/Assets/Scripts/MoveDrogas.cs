using UnityEngine;
using System.Collections;

public class MoveDrogas : MonoBehaviour {
    private float speed;
    // Use this for initialization
    void Start ()
    {
	
	}
	// Update is called once per frame
	void Update () {
        if (Botoes.pause == false) {
            //Velocidade das drogas aumentam com o decorrer do tempo
            speed += 0.0001f;
            //Atributos fase 1
            if (SelecaoDeFases.faseselecionada == 1)
            {
                speed = 0.05f;
                transform.Translate(-speed, 0, 0);
                if (transform.position.x <= -10.32004f)
                {
                    Destroy(this.gameObject);
                }
            }
            //Atributos fase 2
            if (SelecaoDeFases.faseselecionada == 2)
            {
                speed = 0.06f;
                transform.Translate(-speed, 0, 0);
                if (transform.position.x <= -10.32004f)
                {
                    Destroy(this.gameObject);
                }
            }
            //Atributos fase 3
            if (SelecaoDeFases.faseselecionada == 3)
            {
                speed = 0.07f;
                transform.Translate(-speed, 0, 0);
                if (transform.position.x <= -10.32004f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
