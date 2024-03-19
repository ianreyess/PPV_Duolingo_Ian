using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    //Crea un texto
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Actualiza el texto usado.
    public void UpdateText()
    {
        
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Selecciona una opción.
    public void SelectOption()
    {
        //Asigna la respuesta correcta 
        LevelManager.Instance.SetPlayerAnswer(OptionID); 
        LevelManager.Instance.CheckPlayerState();
    }
}
