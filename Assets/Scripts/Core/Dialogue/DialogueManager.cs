using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Image actorImage;
    [SerializeField] private Text  actorName;
    [SerializeField] private Text  messageText;
    [SerializeField] private RectTransform backgroundBox;
    public static bool isMessageActive = false ;
    private Player_Item playerItem;
    [SerializeField] private AudioClip OpenMessage;
    [SerializeField] private AudioClip nextMassage;

    private Story currentStory;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    bool canink;
    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        isMessageActive = false;
        canink = true;
        playerItem = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isMessageActive)
        {
            NextMassage();
            SoundManager.instance.PlaySound(nextMassage);

        }
    }
    public void OpenDialogue(Message[] _message, Actor[] _actor, TextAsset ink, string id)
    {
        SoundManager.instance.PlaySound(OpenMessage);
        isMessageActive = true;
        currentMessages = _message;
        currentActors = _actor;
        activeMessage = 0;
        if (ink != null && canink )
        {
            currentStory = new Story(ink.text);
            currentStory.ResetState();
            currentStory.ChoosePathString(id);
        }
        else canink = false;
        DisplayMassage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        //backgroundBox.localScale = new Vector3(1, 1, 1);
    }
    void DisplayMassage()
    {
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        Message messageToDisplay = currentMessages[activeMessage];
        if (currentStory.canContinue && canink && playerItem.GetPower() < playerItem.GetMaxPower())
        {
            messageText.text = currentStory.Continue();
        }
        else if(!canink || playerItem.GetPower() >= playerItem.GetMaxPower())
        {
            messageText.text = messageToDisplay.message;
        }

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
