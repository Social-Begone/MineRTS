using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// select in square
public class MouseInputSystem : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector2 direction;
    public GameObject selectorPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            startPosition = Camera.main.ScreenToWorldPoint(startPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            endPosition = Camera.main.ScreenToWorldPoint(endPosition);

            Vector3 lowerLeftPosition = new Vector3(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y), 0);
            Vector3 upperRightPosition = new Vector3(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y), 0);
            Vector3 finalPos = new Vector3((upperRightPosition.x - ((upperRightPosition.x - lowerLeftPosition.x) / 2)), (upperRightPosition.y - ((upperRightPosition.y - lowerLeftPosition.y) / 2)), 0);

            GameObject newObject = Instantiate(selectorPrefab, finalPos, Quaternion.identity) as GameObject;
            newObject.transform.localScale = new Vector3((((upperRightPosition.x - lowerLeftPosition.x) / 2)*200), (((upperRightPosition.y - lowerLeftPosition.y) / 2) * 200), 0);

            
        }


    }


}
