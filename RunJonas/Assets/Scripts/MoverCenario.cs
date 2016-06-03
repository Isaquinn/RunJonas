using UnityEngine;
using System.Collections;

public class MoverCenario : MonoBehaviour {
    private Material currentMaterial;
    private float velocidade = 3;
    private float offset;
    // Use this for initialization
    void Start ()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Botoes.pause == false) {
            //Faz os armários ficarem se movendo para a esquerda
            offset += 0.001f;
            currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0));
        }
    }
}
