using System;
using UnityEngine;
using System.Collections;

public enum DIRECTION
{
  LEFT = 1,
  RIGHT = 2,
  FRONT = 3
};

public class Move : MonoBehaviour
{
  public float moveSpeed;
  public float jumpHeight;
  public float scale = 1;


  // private Vector3 toMove;
  public void move(DIRECTION direction, int times)
  {
    Vector3 stepMove = new Vector3(0, 0, 0);
    if (angleEqual(transform.eulerAngles.y, 0))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(-1, 0, 0);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(1, 0, 0);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(0, 0, 1);
    }
    else if (angleEqual(transform.eulerAngles.y, 90))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(0, 0, 1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(0, 0, -1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(1, 0, 0);
    }
    else if (angleEqual(transform.eulerAngles.y, 180))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(1, 0, 0);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(-1, 0, 0);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(0, 0, -1);
    }
    else if (angleEqual(transform.eulerAngles.y, 270))
    {
      if (direction == DIRECTION.LEFT) stepMove = new Vector3(0, 0, -1);
      else if (direction == DIRECTION.RIGHT) stepMove = new Vector3(0, 0, 1);
      else if (direction == DIRECTION.FRONT) stepMove = new Vector3(-1, 0, 0);
    }
    else
    {
      Debug.Log("Move.move angleEqual ERRRR!!!");
    }
    StartCoroutine(moveStepByStep(stepMove, times));
  }

  private IEnumerator moveStepByStep(Vector3 stepMove, int times)
  {
    for (int i = 0; i < times; i++)
    {
      moveStep(stepMove);
      yield return new WaitForSecondsRealtime(1);
    }

  }

  private void moveStep(Vector3 stepMove)
  {
    transform.position += (stepMove + new Vector3(0, jumpHeight, 0)) * scale;

  }


  private bool angleEqual(float a, float b)
  {
    float threshhold = 0.1f;
    a %= 360;
    b %= 360;
    return (a - b) < threshhold && (a - b) > -1 * threshhold;
  }
}
