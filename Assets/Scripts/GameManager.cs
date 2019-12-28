using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
  public GameObject player;
  private Move m_Move;


  public Stage[] cubeList;
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
    nowStage = cubeList[nowStageNo];
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


  public GameObject cube;




  public GameObject column;

  public void dev()
  {
    cube.GetComponent<TouchCube>().collisionEnabled = true;
    // foreach (Transform cube in column.transform)
    // {
    //   string name = cube.name;
    //   name = name.Split('(')[1];
    //   name = name.Split(')')[0];
    //   int no = Int32.Parse(name);
    //   cube.localPosition = new Vector3(0, 0, 50-no);
    // }
  }

}
