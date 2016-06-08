using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotoesPause : MonoBehaviour {
    Image som;
    GameObject BotaoSom;
    public static int sons = 0;
    public static string somsalvo = "som";
    bool menu = false;
    // Use this for initialization
    void Start () {
        //Chama o estado do botão som caso a fase seja reiniciada
        BotoesPause.sons = PlayerPrefs.GetInt(BotoesPause.somsalvo, 0);
        som = gameObject.GetComponent<Image>();
        BotaoSom = GameObject.Find("Pause/Som");
        menu = false;
    }

    // Retorna ao jogo
    public void RetornaAoGame()
    {
        Botoes.numberpause = 0;
        Personagem.Pause.SetActive(false);
        Botoes.pause = false;
    }
    //Reinicia a fase
    public void ReloadGame()
    {
        Botoes.numberpause = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
    // Vai para o Menu
    public void Menu()
    {
        FadeInAndFadeOutCanvas.canvasfade.SetActive(true);
        menu = true;
        FadeInAndFadeOutCanvas.black = true;
        //Botoes.numberpause += 1;
    }
    // Controlado de audio(liga/desliga)
    public void Audio()
    {
        sons += 1;
        PlayerPrefs.SetInt(somsalvo,sons);
    }
    void Update()
    {
        //Gambiarra para trocar a imagem do som
        if (sons == 1)
        {
            BotaoSom.GetComponent<Image>().sprite = Resources.Load<Sprite>("sem_SOM");
        }
        else if (sons == 2)
        {
            BotaoSom.GetComponent<Image>().sprite = Resources.Load<Sprite>("SOM");
            sons = 0;
        }
        if (  menu == true)
        {
            Application.LoadLevel("Menu");
        }
     }
}
