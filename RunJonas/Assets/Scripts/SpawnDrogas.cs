using UnityEngine;
using System.Collections;

public class SpawnDrogas : MonoBehaviour {
    public GameObject Maconha;
    public GameObject Cocaina;
    public GameObject Droguinha;
    public GameObject Heroina;
    public GameObject crianca;
    private float tempo = 1f;
    private float tempo2 = 1f;
    private int number;
    private int numberposition;
    private float position;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Botoes.pause == false)
        {
            tempo2 -= Time.deltaTime;
            //Tempo para decidir a posicao aleatoria de cada drop
            if (tempo2 <= 0f)
            {
                numberposition = Random.Range(0, 4);
                tempo2 = 1f;
            }
            //Denine a poscao da y da droga dependendo do número randomico
            switch (numberposition)
            {
                case 0:
                    position = -0.46f;
                    break;
                case 1:
                    position = -1.59f;
                    break;
                case 2:
                    position = -2.94f;
                    break;
                case 3:
                    position = -4.25f;
                    break;
            }
            tempo -= Time.deltaTime;
            if (tempo <= 0f)
            {
                number = Random.Range(0, 5);
                //Decide a droga que sera dropada
                switch (number)
                {
                    case 0:
                        Instantiate(Maconha, new Vector2(9.99f, position), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(Cocaina, new Vector2(9.99f, position), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(Droguinha, new Vector2(9.99f, position), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(Heroina, new Vector2(9.99f, position), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(crianca, new Vector2(9.99f, position), Quaternion.identity);
                        break;
                }
                tempo = 1f;
            }
        }
    }
}
