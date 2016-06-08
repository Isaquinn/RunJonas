using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Personagem : MonoBehaviour {
    private float speed = 0.1f;
    private bool efeitonegativo = false;
    private float tempoefeitonegativo = 5f;
    public static int vidas = 3;
    public static GameObject Pause;
    int criancassalvas;
    public static int scoresalvas = 0;
    public static int novafase = 0;
    // Funcao Start
    void Start()
    {
        scoresalvas = 0;
        Botoes.numberpause = 2;
        vidas = 3;
        Pause = GameObject.Find("Pause");
        Pause.SetActive(false);
        efeitonegativo = false;
        Botoes.pause = false;
    }

    // Funcao Update
    void Update()
    {
        // Verifica se a fase selecionada foi a fase 1 e atribui atributos como quantidade de criancas que devem ser salvas
        if (SelecaoDeFases.faseselecionada == 1)
        {
            TempoGatorosSalvosScore.criancasalva.gameObject.GetComponent<Text>().text = criancassalvas + "/4";
            // Caso o personagem salve a quantidade de criancas determinada na fase dentro do tempo proposto ele libera a fase 2
            if (criancassalvas >= 4 && TempoGatorosSalvosScore.temporal <= 0)
            {
                PlayerPrefs.SetInt(SelecaoDeFases.fases, 2);
                PlayerPrefs.Save();
                Debug.Log("Ganhou");
                novafase = 2;
                Application.LoadLevel("Vitoria");
             }
            //Caso não consiga salvar a quantidade de criancas dentro do tempo proposto ele perde e não avança para a a próxima fase
            else if (criancassalvas < 4 && TempoGatorosSalvosScore.time <= 0f)
            {
                Application.LoadLevel("DerrotaTempo");
            }
        }
        // Verifica se a fase selecionada foi a fase 2 e atribui atributos como quantidade de criancas que devem ser salvas
        if (SelecaoDeFases.faseselecionada == 2)
        {
            // Caso o personagem salve a quantidade de criancas determinada na fase dentro do tempo proposto ele libera a fase 3
            TempoGatorosSalvosScore.criancasalva.gameObject.GetComponent<Text>().text = criancassalvas + "/6";
            if (criancassalvas >= 6 && TempoGatorosSalvosScore.temporal <= 0)
            {
                 PlayerPrefs.SetInt(SelecaoDeFases.fases, 3);
                PlayerPrefs.Save();
                Debug.Log("Ganhou");
                novafase = 3;
                Application.LoadLevel("Vitoria");
            }
            //Caso não consiga salvar a quantidade de criancas dentro do tempo proposto ele perde e não avança para a a próxima fase
            else if (criancassalvas < 6 && TempoGatorosSalvosScore.time <= 0f)
            {
                Application.LoadLevel("DerrotaTempo");
            }
        }
        // Verifica se a fase selecionada foi a fase 3 e atribui atributos como quantidade de criancas que devem ser salvas
        if (SelecaoDeFases.faseselecionada == 3)
        {
            TempoGatorosSalvosScore.criancasalva.gameObject.GetComponent<Text>().text = criancassalvas + "/10";
            //Caso não consiga salvar a quantidade de criancas dentro do tempo proposto ele perde e não avança para a a próxima fase
            if (criancassalvas >= 10 && TempoGatorosSalvosScore.temporal <= 0)
            {
                 PlayerPrefs.SetInt(SelecaoDeFases.fases, 4);
                PlayerPrefs.Save();
                Debug.Log("Ganhou");
                Application.LoadLevel("Vitoria");
            }
            //Caso não consiga salvar a quantidade de criancas dentro do tempo proposto ele perde e não avança para a a próxima fase
            else if (criancassalvas < 10 && TempoGatorosSalvosScore.time <= 0f)
            {
                Application.LoadLevel("DerrotaTempo");
            }
        }
        // Verifica se a fase selecionada foi a fase 3 e atribui atributos como quantidade de criancas que devem ser salvas
        //Ainda em processo
        if (SelecaoDeFases.faseselecionada == 4)
        {
            TempoGatorosSalvosScore.criancasalva.gameObject.GetComponent<Text>().text = criancassalvas + "/15";
        }
        //Caso o jogo não esteja pausado a tela de pause fica desativada
        if (Botoes.pause == true)
        {
            Pause.SetActive(true);
             Time.timeScale = 0f;
        }
        //Caso o jogo esteja pausado a tela de pause é ativada
        else if (Botoes.pause == false)
        {
            Pause.SetActive(false);
            Time.timeScale = 1f;
        }
        //Caso o efeito negativo seja ativado comeca um tempo de duração deste efeito
        if (efeitonegativo == true)
        {
            tempoefeitonegativo -= Time.deltaTime;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //Caso o jogo não esteja pausado podemos jogar rsrs
        if (Botoes.pause == false)
        {
            // Funcao para mover o personagem em Y
            if (Input.GetMouseButtonUp(0))
            {
                //Limitação onde o personagem pode se mover
                if (transform.position.y <= 0.43f && transform.position.y >= -3.75f)
                {
                    //Quando efeitonegativo é igual a false, o personagem se move normamente.
                    if (efeitonegativo == false)
                    {
                        //Toque na seta para baixo
                        if (hit.collider.tag == "Baixo")
                        {
                            Debug.Log("Baixo");
                            if (transform.position.y <= -3.74f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y);
                            }
                            else if (transform.position.y >= -3.74f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y - 1.35f);
                            }
                        }
                        //Toque na seta para cima
                        if (hit.collider.tag == "Cima")
                        {
                            if (transform.position.y <= -0.01f && transform.position.y >= -1.0f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y);
                            }
                            else if (transform.position.y <= -0.01f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y + 1.35f);
                            }
                        }
                    }
                    //Quando o efeitonegativo é igual a true a funcao dos botões que movem o personagem no eixo Y ficam inversas
                    if (efeitonegativo == true)
                    {
                        tempoefeitonegativo -= Time.deltaTime;
                        //Toque na seta para cima
                        if (hit.collider.tag == "Baixo")
                        {
                            if (transform.position.y >= -0.01f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y);
                            }
                            else if (transform.position.y <= -0.01f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y + 1.35f);
                            }
                        }
                        //Toque na seta para baixo
                        if (hit.collider.tag == "Cima")
                        {
                            if (transform.position.y <= -3.74f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y);
                            }
                            else if (transform.position.y >= -3.74f)
                            {
                                transform.position = new Vector2(transform.position.x, transform.position.y - 1.35f);
                            }
                        }
                    }

                }
            }
            //Duração do efeitonegativo
            if (tempoefeitonegativo <= 0f)
            {
                tempoefeitonegativo = 5f;
                efeitonegativo = false;
            }
        }
        //Caso a barra de overdose(vidas) zere aparece a tela de derrota por overdose
        if (vidas <= 0)
        {
            Application.LoadLevel("DerrotaOverdose");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
            //Colisão com a Maconha
            if (other.gameObject.tag == "Maconha")
            {
                vidas -= 1;
                Destroy(other.gameObject);
            }
            //Colisão com a Cocaina
            if (other.gameObject.tag == "Cocaina")
            {
                vidas -= 1;
                efeitonegativo = true;
                Destroy(other.gameObject);
            }
            //Colisao com a Heroina
            if (other.gameObject.tag == "Heroina")
            {
                vidas -= 1;
                Destroy(other.gameObject);
            }
            //Colisão com a Droguinha
            if (other.gameObject.tag == "Droguinha")
            {
                vidas -= 1;
                Destroy(other.gameObject);
            }
            //Colisao com a crianca
            if (other.gameObject.tag == "crianca")
            {
                criancassalvas += 1;
                scoresalvas += 50;
                Destroy(other.gameObject);
            }
     }
}
    


