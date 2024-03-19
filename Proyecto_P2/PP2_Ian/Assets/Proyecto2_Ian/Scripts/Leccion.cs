using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]

public class Leccion : ScriptableObject
{
    //Crea una lección la cual permite heredar el codigo sin alterar el codigo principal.
     [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Subject> leccionList;
}