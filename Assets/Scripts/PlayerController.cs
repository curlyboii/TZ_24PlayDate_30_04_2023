using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float forwardSpeed; // speed
    public float dodgeSpeed; // horizontal speed
    public float maxXLimitDirection; // limit X diraction

    private float horizontalValue; // Horizontal variable
    private float newPositionX; // X position variable (variable to save X diraction and limit)

    #endregion


    // Update is called once per frame
    void Update()
    {
        PlayerForwardMove();
        HorizontalControl();
        HorizontalMovementAndLimit();
    }


    #region Horizontal control input
    private void HorizontalControl()
    {
        if (UnityEngine.Input.GetMouseButton(0)) // press button to control X diraction
        {
            horizontalValue = UnityEngine.Input.GetAxis("Mouse X"); // horizontalValue = X diraction which mouse control
        }
        else
        {
            horizontalValue = 0; // if you don't touch mouse horizontalValue = 0
        }
    }
    #endregion



    #region Player move forward
    private void PlayerForwardMove()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime); // moves the object forward in its local space at a speed determined by forwardSpeed,
                                                                              // with the movement scaled by the time elapsed since the last frame to ensure
                                                                              // consistent movement across different frame rates
    }
    #endregion


    #region Horizontal move and X diraction limit
    private void HorizontalMovementAndLimit() //horizontal dodge, and limit
    {
        newPositionX = transform.position.x + horizontalValue * dodgeSpeed * Time.deltaTime; //change X diraction + mouse control * speed
        newPositionX = Mathf.Clamp(newPositionX, -maxXLimitDirection, maxXLimitDirection); // This restricts the object's movement along the X-axis within a defined range
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z); // This ensures that the object only moves horizontally and does not change its height or depth position in the 3D space
    }
    #endregion


    #region Restart
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            forwardSpeed = 0;
            dodgeSpeed = 0;
            GameManager.instance.GameOver();

        }

    }
    #endregion


}
