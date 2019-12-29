using System;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
  public GameObject player;
  private Move m_Move;
  public GameObject UIPanel;


  public Stage[] stageList;
  public int nowStageNo = -1;
  private Stage nowStage;
  private int nowStageStep;
  private DIRECTION nowStageCorrectDirection;

  public int wrongStep = 1;

  private UnityAction goNextStageAction;
  private UnityAction goWrongPenaltyAction;




  private void Start()
  {
    m_Move = player.GetComponent<Move>();


    goNextStageAction = new UnityAction(goNextStage);
    goWrongPenaltyAction = new UnityAction(goWrongPanelty);
    EventManager.GetInstance.StartListening(EVENT.GO_NEXT_STAGE, goNextStageAction);
    EventManager.GetInstance.StartListening(EVENT.GO_WRONG_PENALTY, goWrongPenaltyAction);

    EventManager.GetInstance.TriggerEvent(EVENT.GO_NEXT_STAGE);
  }



  public void goNextStage()
  {
    nowStageNo++;
    nowStage = stageList[nowStageNo];
    nowStageStep = nowStage.cubes.Length;
    nowStageCorrectDirection = nowStage.correctDirection;
    foreach (GameObject cube in nowStage.cubes)
    {
      cube.GetComponent<TouchCube>().isCorrectCube = true;
    }
    UIPanel.SetActive(true);
  }

  public void goWrongPanelty()
  {
    Debug.Log("goWrongPanelty");
    UIPanel.SetActive(true);
  }



  public void pressLeft()
  {
    goDirection(DIRECTION.LEFT);
  }
  public void pressRight()
  {
    goDirection(DIRECTION.RIGHT);
  }
  public void pressFront()
  {
    goDirection(DIRECTION.FRONT);

  }
  private void goDirection(DIRECTION direction)
  {
    UIPanel.SetActive(false);
    if (nowStageCorrectDirection == direction)
    {
      m_Move.move(nowStageCorrectDirection, nowStageStep, EVENT.GO_NEXT_STAGE);
    }
    else
    {
      m_Move.move(direction, wrongStep, EVENT.GO_WRONG_PENALTY);


    }

  }
}
