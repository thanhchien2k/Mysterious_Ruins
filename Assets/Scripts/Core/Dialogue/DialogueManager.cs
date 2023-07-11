using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Image actorImage;
    [SerializeField] private Text  actorName;
    [SerializeField] private Text  messageText;
    [SerializeField] private RectTransform backgroundBox;
    public static bool isMessageActive = false ;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        isMessageActive = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isMessageActive)
        {
            NextMassage();
        }
    }
    public void OpenDialogue(Message[] _message, Actor[] _actor)
    {
        isMessageActive = true;
        currentMessages = _message;
        currentActors = _actor;
        activeMessage = 0;
        DisplayMassage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        //backgroundBox.localScale = new Vector3(1, 1, 1);
    }
    void DisplayMassage()
    {
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimateTextColor();
    }
    public void NextMassage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMassage();
        }

        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            //backgroundBox.localScale = new Vector3(0, 0, 0);
            isMessageActive = false;
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
}
