using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BtnProximaFase : MonoBehaviour
{
    
    public string nomeDaProximaCena; // Defina o nome da pr�xima cena no Inspector

    public void CarregarProximaFase()
    {
        SceneManager.LoadScene(nomeDaProximaCena); // Carrega a cena definida
    }
}

