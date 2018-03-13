using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuButtonsSelector : MonoBehaviour {

    [SerializeField]
    int CurrentSelected;

    [SerializeField]
    Button[] Buttons;
    [SerializeField]
    Button TapToStart;

    [SerializeField]
    Image SelectedButtonImage;

    [SerializeField]
    BookAnimations BookAnims;

    [SerializeField]
    Animator CameraAnim;
    [SerializeField]
    Animator TitleAnimation;

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        CurrentSelected = 0;
        //SelectedButtonImage.rectTransform.position = Buttons[0].transform.position;
        StartCoroutine(SetSelectedImage());
        NewInfoManager.instance.LoadHighScores();
    }
	
	public void ClickedButton(int ID)
    {
        if (CurrentSelected == ID)
            return;

        BookAnims.ChangePage(CurrentSelected,ID);
        //if this is not the exit button
        if (ID != 3)
        {
        CurrentSelected = ID;
        SelectedButtonImage.rectTransform.position = Buttons[ID].transform.position;

        }
        else
        {
   //the book has been closed
            anim.SetBool("ToggleMenu", false);
            StartCoroutine(WaitForOriginalPos());
            CameraAnim.SetBool("GoToBook",false);
            TitleAnimation.SetBool("MoveUp", false);
        }
        StartCoroutine(FreezeBruddah());
    }
   public void OpenBook()
    {
        SelectedButtonImage.gameObject.SetActive(false);
        TapToStart.gameObject.SetActive(false);
        BookAnims.OpenBook();
        anim.SetBool("ToggleMenu", true);
        CameraAnim.SetBool("GoToBook",true);
        TitleAnimation.SetBool("MoveUp", true);
        CurrentSelected = 0;
        StartCoroutine(SetSelectedImage());
        //SelectedButtonImage.rectTransform.position = Buttons[0].transform.position;
    }
    IEnumerator FreezeBruddah()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    IEnumerator WaitForOriginalPos()
    {
        yield return new WaitForSeconds(2);

        TapToStart.gameObject.SetActive(true);
        
    }

    IEnumerator SetSelectedImage()
    {
        
        yield return new WaitForSeconds(3);
        SelectedButtonImage.gameObject.SetActive(true);
        SelectedButtonImage.rectTransform.position = Buttons[0].transform.position;
    }
}
