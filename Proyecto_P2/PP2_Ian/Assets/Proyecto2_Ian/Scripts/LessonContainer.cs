using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessons = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    public void Start()
    {
        //Hace que lessonContainer vea si non es null. 
        if (lessonContainer != null)
        {
            //Actualiza la UI.
            OnUpdateUI();
        }
        else
        {
            //Se muentra un mensaje en la consola en caso de que sea null.
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //La UI actualiza el texto que contenga la parte de lesson.
    public void OnUpdateUI()
    {
        //Comprueba si los objetos StageTitle o LessonStage no son null
        if (StageTitle != null || LessonStage != null)
        {
            //El texto se actualiza para cada leccion.
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        else
        {
            //Hace que la consola mande un mensaje que avisa que no se han asignado los objetos en los slots bien
            
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    // Activa o desactiva el LessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
        //Se deseactiva en caso de estar activada.
            lessonContainer.SetActive(false);
        }
        else
        {
            //Viceversa.
            lessonContainer.SetActive(true);
        }
    }
}