using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    // SerializeField allows you to expose private objects to the inspector. HideInInspector is the opposite (hide public objects from the inspector)
    [SerializeField]
    private float speed;
    // making endPosition a field so we don't have to "remake" them every frame
    private Vector3 endPosition;

    // I like to group fields by function, this is where I'd put all components
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // prevent the player from moving to 0,0,0
        endPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Compare tag isn't the most performant method to do this, but this will only set end position if you click on a floor. You have to set the tag of the objects in the inspector
                // Ideally, you'd use "GetComponent<X>() where X = any component that only floor objects have, this is better for performance
                if (hit.transform.gameObject.CompareTag("Floor"))
                {
                    endPosition = hit.point;
                    Debug.Log(endPosition);
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }


}
