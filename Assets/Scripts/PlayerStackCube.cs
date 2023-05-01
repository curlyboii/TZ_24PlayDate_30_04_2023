using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.tvOS;

public class PlayerStackCube : MonoBehaviour
{
    /// <summary>
    /// this script manages a stack of cube objects by adding and removing them at runtime. 
    /// When a new block is added, it is placed 2 units below the last block placed and when a block is removed
    /// </summary>
    

    public List<GameObject> blockList = new List<GameObject>(); // stores all the cube objects that are stacked up by the player
    private GameObject lastBlockObject; // private GameObject field which stores the reference to the last block that was placed
       public GameObject pickUpEffect; // Pickup effect

    private void Start()
    {
        UpdateLastBlockObject(); // UpdateLastBlockObject method is called once to initialize the lastBlockObject field
    }

    public void IncreaseNewBlock(GameObject _gameObject) // IncreaseNewBlock which takes a GameObject parameter _gameObject.
                                                         // This method is used to add a new cube object to the stack
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z); // transform is updated to move it up by 2 units on the y-axis
        _gameObject.transform.position = new Vector3(transform.position.x, lastBlockObject.transform.position.y - 2f, transform.position.z); // The position of the _gameObject is updated to be 2 units below the position of the last block placed
        _gameObject.transform.SetParent(transform); // The _gameObject is set to be a child of the script's transform, which makes it move along with the script's transform
        blockList.Add(_gameObject); // The _gameObject is added to the blockList
        Instantiate(pickUpEffect, transform.position, pickUpEffect.transform.rotation); // spawn effect
        UpdateLastBlockObject(); // The UpdateLastBlockObject method is called to update the lastBlockObject field.
    }


    public void DecreaseBlock(GameObject _gameObject) // This method is used to remove a cube object from the stack
    {
        _gameObject.transform.parent = null; // is set to null, which detaches it from the script's transform
        blockList.Remove(_gameObject); // the _gameObject is removed from the blockList
        UpdateLastBlockObject(); // update the lastBlockObject field
        Destroy(_gameObject, 1.5f); // _gameObject is destroyed after 1.5 seconds using the Destroy method
    }


    public void UpdateLastBlockObject() // this method updates the lastBlockObject field to be the last GameObject in the blockList
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
