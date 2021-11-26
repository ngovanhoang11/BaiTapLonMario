using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("player").GetComponent<PlayerJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
            //Debug.Log ("Touching The Left Button");

        }
        else
        {
            playerMove.SetMoveLeft(false);
            //Debug.Log("Touching The Right Button");
        }
        if(gameObject.name == "Jump")
        {
            playerMove.setJump(true);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
        if (gameObject.name == "Jump")
        {
            playerMove.setJump(false);
        }
    }
}
