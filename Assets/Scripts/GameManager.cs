using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
  public GameObject player;
  private Move m_Move;


  public Stage[] stageList;
  public int nowStageNo = -1;
  private Stage nowStage;
  private int nowStageStep;
  private DIRECTION nowStageCorrectDirection;

  public int wrongStep = 3;




  private void Start()
  {
    m_Move = player.GetComponent<Move>();

    goNextStage();
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
  }



  public void pressLeft()
  {
    int step = nowStageCorrectDirection == DIRECTION.LEFT ? nowStageStep : wrongStep;
    m_Move.move(DIRECTION.LEFT, step);
  }
  public void pressRight()
  {
    int step = nowStageCorrectDirection == DIRECTION.RIGHT ? nowStageStep : wrongStep;
    m_Move.move(DIRECTION.RIGHT, step);
  }
  public void pressFront()
  {
    int step = nowStageCorrectDirection == DIRECTION.FRONT ? nowStageStep : wrongStep;
    m_Move.move(DIRECTION.FRONT, step);

  }

}
