using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarLesson : MonoBehaviour
{
    public bool pasarNivel;
    public int IndiceNivel;

    //Cambia de escena con la tecla space
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //peprmite cambiar la escena de IndiceNivel
            CambiarNivel(IndiceNivel);
        }
        //Cambia la escena cuando la variable es = true.
        if (pasarNivel)
        {
            CambiarNivel(IndiceNivel);
        }
    }

    // Hace el cambio de escena 
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
