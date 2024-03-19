using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Data")]
    public Leccion Lesson;

    [Header("User interface")]
    public TMP_Text textQuestion;
    public TMP_Text textGood;
    public List<Option> Question;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;

    [Header("Current Lesson")]
    public Subject currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        //Define cuantas preguntas van a ser
        questionAmount = Lesson.leccionList.Count;
        
        LoadQuestion();

        // Verifica que haya algo seleccionado 
        CheckPlayerState();
    }

    //Carga la siguiente pregunta
    private void LoadQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            //Busca la leccion actual.
            currentLesson = Lesson.leccionList[currentQuestion];

            //Pone la pregunta.
            question = currentLesson.lessons;

            //Dice cual es la respuesta correcta.
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //En la UI para aparece la pregunta.
            textQuestion.text = question;

            //Pone las opciones
            for (int i = 0; i < currentLesson.options.Count; i++)
            {

                // Cada pregunta tiene opcion.
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];

                Question[i].GetComponent<Option>().OptionID = i;

                //Actualiza el option
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
           //Fin de las preguntas en formato de texto
            Debug.Log("Fin de las preguntas");
        }
    }

    //Pasa a la siguiente pregunta.
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {
            //La pregunta este dentro de la opcion
            if (currentQuestion < questionAmount)
            {
                //Revisa si la pregunta es correcta 
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // Activa la ventana de respuestas en el UI.
                AnswerContainer.SetActive(true);

                // Revisa que la pregunta este correcta.
                if (isCorrect)
                {
                    //Si es correcto se pone verde.
                    AnswerContainer.GetComponent<Image>().color = Green;
                   //Confirma que es correcto.
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Si no es correcto se pone roje.
                    AnswerContainer.GetComponent<Image>().color = Red;
                    //Actualiza que sea incorrecto.
                    textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                }

                // Hace que no se repita.
                currentQuestion++;

                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //Reinicia la pregunta.
                answerFromPlayer = 9;
                
            }
            
        }
    }

   
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajusta el tiempo que se espera.
        yield return new WaitForSeconds(2.5f);

        //Oculta las respuestas.
        AnswerContainer.SetActive(false);

        //Nueva pregunta.
        LoadQuestion();

        //Activa el boton.
      
        CheckPlayerState();
    }

    //Las respuestas del jugador.
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    
    public bool CheckPlayerState()
    {
        
        if (answerFromPlayer != 9)
        {   
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;}
        else
        {   
        
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
