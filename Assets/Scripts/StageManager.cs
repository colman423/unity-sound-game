using System;
using UnityEngine;
using UnityEngine.Events;
public class StageManager : MonoBehaviour
{

  public Stage[] stageList;
  public int nowStageNo = -1;

  [ReadOnly] public Stage nowStage;
  [ReadOnly] public int nowStageStep;
  [ReadOnly] public DIRECTION nowStageCorrectDirection;




  public void goNextStage()
  {
    if (nowStageNo > -1)
    {
      Stage prevStage = stageList[nowStageNo];
      setCorrectCubes(prevStage.cubes, false);
    }

    nowStageNo++;
    nowStage = stageList[nowStageNo];
    nowStageStep = nowStage.cubes.Length;
    nowStageCorrectDirection = nowStage.correctDirection;
    setCorrectCubes(nowStage.cubes, true);
  }

  private void setCorrectCubes(GameObject[] cubes, bool isCorrectCube)
  {
    foreach (GameObject cube in cubes)
    {
      cube.GetComponent<TouchCube>().isCorrectCube = isCorrectCube;
    }

  }



}
