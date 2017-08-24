using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    [SerializeField]
    GameObject AnswerText;

    [SerializeField]
    GameObject QuestionManager;
    //This number will be used to store the value the user submits
    [HideInInspector]
    public int number = 0;

  
    
    //buffer for number input, prior to submission
    StringBuilder numbahs = new StringBuilder();
    
    
    //The way this function is setup does not account for negative numbers,
    //since the numbers than can be passed in are fixed ( 0 to 11).
    public void SetNumber(int _in)
    {
        
        // if the number is between 0 and 9
        if(_in < 10)
        {
            if (numbahs.Length == 0 && _in == 0)
                return;
            //Check if the buffer is not full yet before adding the number
            if (numbahs.Length < 6)
            {
                numbahs.Append(_in.ToString());
                AnswerText.GetComponent<Text>().text = numbahs.ToString();
                Debug.Log("Added!" + numbahs);
            }
            //Rest in pepperoni the buffer is full already
            else
            {
                Debug.Log("Oooh! too many numbersss...");
            }

        }
        //Check for 10, aka delete.
        else if(_in == 10)
        {
           
            //Make sure there´s something to delete
            if (numbahs.Length > 0)
            {
                numbahs.Remove(numbahs.Length - 1, 1);
                AnswerText.GetComponent<Text>().text = numbahs.ToString();
                Debug.Log("Removed! " + numbahs);
            }
            //Oh okay let´s delete nothing -_-
            else
            {
                AnswerText.GetComponent<Text>().text = "0";
                Debug.Log("Cant´t delete what´s not there ;)");
            }

            //this right here is text paranoia
            if (AnswerText.GetComponent<Text>().text == "" || AnswerText.GetComponent<Text>().text == " ")
            {
                AnswerText.GetComponent<Text>().text = "0";
            }


        }
        //Check for 11, aka Submit
        else if (_in == 11)
        {
            // Is there anything to submit? if not, 0 is always your friend.
            if (numbahs.Length == 0)
            {
                number = 0;
                QuestionManager.GetComponent<QuestionManagerController>().CompareResults(number);
                AnswerText.GetComponent<Text>().text = "0";
                Debug.Log("You submitted: " + number);
            }
            //Submit whatever´s on the stringbuffer
            else
            {
                string yee = numbahs.ToString();
                number = Convert.ToInt32(yee);
                QuestionManager.GetComponent<QuestionManagerController>().CompareResults(number);
                AnswerText.GetComponent<Text>().text = "0";
                Debug.Log("You submitted: " + number);
                numbahs.Length = 0;
            }
          
        }
        //Reload the scene
        else if(_in == 12)
        {
            SceneManager.LoadScene("main");
        }
    }

    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void PauseGame()
    {
        GameManager.instance.pauseGame = !GameManager.instance.pauseGame;
        if (GameManager.instance.pauseGame)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
