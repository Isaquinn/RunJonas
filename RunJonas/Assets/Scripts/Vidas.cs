using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vidas : MonoBehaviour {
    private GameObject coracao;
    // Use this for initialization
    void Start () {
        coracao = GameObject.Find("Canvas/Vidas");
        Personagem.vidas = 3;

    }
	
	// Update is called once per frame
	void Update () {
        //Muda a quantidade de coracoes cado o personagem perca vida!
        if (Personagem.vidas == 3)
        {
            coracao.GetComponent<Image>().sprite = Resources.Load<Sprite>("3vidas");
        }
        else if (Personagem.vidas == 2)
        {
            coracao.GetComponent<Image>().sprite = Resources.Load<Sprite>("2vidas");

        }
        else if (Personagem.vidas == 1)
        {
            coracao.GetComponent<Image>().sprite = Resources.Load<Sprite>("1vidas");

        }
       

    }
}
