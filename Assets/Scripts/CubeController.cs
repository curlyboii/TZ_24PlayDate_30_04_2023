using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    /// <summary>
    /// this script manages the movement of a cube object in the game world, checking for trigger colliders and interacting with a PlayerStackCube script
    /// to add or remove the cube from the stack
    /// </summary>

    #region Variables
    [SerializeField] private PlayerStackCube stackController; // private reference to a PlayerStackCube script which is used to manage the stack of cubes
    private bool isStack = false; // field which is used to indicate whether the cube is currently stacked on the tower or not
    #endregion

    private void Start()
    {
        stackController = GameObject.FindObjectOfType<PlayerStackCube>(); // Here, the stackController field is initialized by finding an instance of the
                                                                          // PlayerStackCube script in the scene
    }

    #region Trigger collider
    private void OnTriggerEnter(Collider other) // the method checks if the trigger collider is tagged as "Cube" or "Obstacle"
    {
        if (other.gameObject.tag == "Cube")  // If the trigger collider is tagged as "Cube" and the cube is not currently stacked,
                                             // then the *IncreaseNewBlock* method of the *stackController* script is called to add the cube to the stack
                                             // and the *SetDirection* method is called to set the direction of the cube movement
        {
            if (!isStack)
            {
                isStack = !isStack;
                stackController.IncreaseNewBlock(gameObject);
            }

        }
        if (other.gameObject.tag == "Obstacle") // If the trigger collider is tagged as "Obstacle",
                                                // then the *DecreaseBlock method* of the *stackController* script is called to remove the cube from the stack.
        {
            stackController.DecreaseBlock(gameObject);
        }
    }
    #endregion

}
