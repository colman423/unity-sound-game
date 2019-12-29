using System;
using UnityEngine;
using UnityEngine.Events;
public class StageManager : MonoBehaviour
{

  public AudioSource audio;
  public float audioDistance;

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
    setAudioDirection(nowStageCorrectDirection);
  }

  private void setCorrectCubes(GameObject[] cubes, bool isCorrectCube)
  {
    foreach (GameObject cube in cubes)
    {
      cube.GetComponent<TouchCube>().isCorrectCube = isCorrectCube;
    }

  }

  private void setAudioDirection(DIRECTION direction)
  {
    audio.enabled = false;
    switch (direction)
    {
      case DIRECTION.LEFT:
        audio.transform.localPosition = new Vector3(-1*audioDistance, 0, 0);
        break;
      case DIRECTION.RIGHT:
        audio.transform.localPosition = new Vector3(audioDistance, 0, 0);
        break;
      case DIRECTION.FRONT:
        audio.transform.localPosition = new Vector3(0, 0, audioDistance);
        break;
    }
  }



}
