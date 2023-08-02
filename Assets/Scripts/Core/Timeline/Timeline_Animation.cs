using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline_Animation : MonoBehaviour
{
    [SerializeField]private PlayableDirector director;
    [SerializeField] private double stratTime;
    [SerializeField] private double finishTime;
    bool canStrat;
    bool canFinish;

    private void Start()
    {
        transform.localScale = Vector2.zero;
        canFinish = true;
        canStrat = true;
    }

    private void Update()
    {
        double currentTime = director.time;
        if (currentTime >= stratTime && canStrat) 
        {
            OpenUI();
            canStrat = false;
        }
        else if (currentTime >= finishTime && canFinish)
        {
            CloseUI();
            canFinish = false;
        }
    }


    public void OpenUI()
    {
        transform.LeanScale(Vector2.one, 0.4f);
    }
    public void CloseUI()
    {
        transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
    }
}
