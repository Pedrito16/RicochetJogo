using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ResetBall : MonoBehaviour
{
    [SerializeField] Button resetButton;
    [SerializeField] List<Ball> ballsList;
    [SerializeField] CanvasGroup bolaIcon;
    void Start()
    {
        bolaIcon = GetComponentInChildren<CanvasGroup>();
        resetButton.onClick.AddListener(() => PassRound(4));
      

        ballsList = new List<Ball>();
        for (int i = 0; i < DispararBolas.instance.ballsRbList.Count; i++)
        {
            ballsList.Add(DispararBolas.instance.ballsRbList[i].GetComponent<Ball>());
        }
    }
   



    void Update()
    {
        if(DispararBolas.instance.allBallsShot)
        {
            resetButton.interactable = true;
            bolaIcon.alpha = 1;
        }
        else
        {
            resetButton.interactable = false;
            bolaIcon.alpha = 0.5f;
        }
    }
    public void PassRound(int bolasGordas)
    {
        for (int i = 0; i < ballsList.Count; i++)
        {
            ballsList[i].ResetPos();
        }
        MoverPlayer.instance.ballsQuantity = 0;
    }
}
