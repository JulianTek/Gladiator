using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    private float elapsedTime = 0;
    private float duration = 10;
    // Start is called before the first frame update
    void Start()
    {

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
                Vector3 worldPosition = hit.point;
                Vector3 startPosition = transform.position;
                Debug.Log("World position " + worldPosition);

                // Do something with the world position, e.g., instantiate a game object
                // Instantiate(prefab, worldPosition, Quaternion.identity);
                // duration of movement in seconds
                elapsedTime += Time.deltaTime;
                float t = duration / elapsedTime;
                transform.position = Vector3.Lerp(startPosition, worldPosition, t);
            }
        }
    }
}
