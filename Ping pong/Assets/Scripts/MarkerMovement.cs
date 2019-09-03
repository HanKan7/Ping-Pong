using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMovement : MonoBehaviour
{
    public float markerSpeed = 10;
   
    public Joystick joystick;
    public PlayerMovement player;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float jh = joystick.Horizontal;
        float stick = 0;
        if (jh > 0) stick = 1;
        if (jh < 0) stick = -1;
        if (jh == 0) stick = 0;
        float v = Input.GetAxis("Vertical");
        float xPos = h * markerSpeed * Time.deltaTime;
        float jxPos = stick * markerSpeed * Time.deltaTime;
        if (player.isServing == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), transform.position.y, transform.position.z); //Clamping the marker
        }
        transform.Translate(xPos, 0, 0);
        transform.Translate(jxPos, 0, 0);

    }
}
