using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endgameController: MonoBehaviour {

    private spinModel _sModel;

    public Animator[] animator = new Animator[3];
    public Button button;
    public Text Score;

    private void Start()
    {
        _sModel = GetComponent<spinModel>();
        clickEvent.instance.clicked += variableReset;

    }

    public void variableReset()
    {
        button.interactable = false;

        foreach (Animator anim in animator)
        {
            anim.SetBool("animTrigger", false);

        }

        endWatcher.instance.finishGame += endGame;


    }

    private void endGame()
    {
        switch (_sModel.ActiveReelCount)//handles the final animations 
        {
            case 0:
                break;
            case 1:
                animator[0].SetBool("animTrigger", true);

                break;
            case 2:
                animator[0].SetBool("animTrigger", true);
                animator[1].SetBool("animTrigger", true);

                break;
            case 3:
                animator[0].SetBool("animTrigger", true);
                animator[1].SetBool("animTrigger", true);
                animator[2].SetBool("animTrigger", true);          
                break;
        }
        Score.text = "SCORE: " + _sModel.winAmount;
        endWatcher.instance.finishGame -= endGame;
        button.interactable = true;

    }


}
