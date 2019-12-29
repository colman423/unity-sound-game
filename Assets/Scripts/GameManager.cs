using System;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
  public GameObject player;
  public GameObject UIPanel;
  private Move m_Move;
  private StageManager stageManager;

  public int wrongStep = 1;
  private Transform transformBeforeMove;

  private UnityAction goNextStageAction;
  private UnityAction goWrongPenaltyAction;




  private void Start()
  {
    m_Move = player.GetComponent<Move>();
    stageManager = GetComponent<StageManager>();


    goNextStageAction = new UnityAction(goNextStage);
    goWrongPenaltyAction = new UnityAction(goWrongPanelty);
    EventManager.GetInstance.StartListening(EVENT.GO_NEXT_STAGE, goNextStageAction);
    EventManager.GetInstance.StartListening(EVENT.GO_WRONG_PENALTY, goWrongPenaltyAction);

    EventManager.GetInstance.TriggerEvent(EVENT.GO_NEXT_STAGE);
  }



  public void goNextStage()
  {
    stageManager.goNextStage();
    UIPanel.SetActive(true);
  }

  public void goWrongPanelty()
  {
    Debug.Log("goWrongPanelty");
    UIPanel.SetActive(true);
    player.transform.position = transformBeforeMove.position;
    player.transform.eulerAngles = transformBeforeMove.eulerAngles;
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
    transformBeforeMove = player.transform;
    if (stageManager.nowStageCorrectDirection == direction)
    {
      m_Move.move(stageManager.nowStageCorrectDirection, stageManager.nowStageStep, EVENT.GO_NEXT_STAGE);
    }
    else
    {
      m_Move.move(direction, wrongStep, EVENT.GO_WRONG_PENALTY);


    }

  }
}
