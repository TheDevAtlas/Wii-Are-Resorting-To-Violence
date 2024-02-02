using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectController : MonoBehaviour {

	public RectTransform uiElement1;
	public RectTransform uiElement2;
	public Vector3 newScale;
	public Vector3 oldScale;
    public TitleScreen menuController;
    public int gameNum;

	void Start()
	{
		uiElement2 = GetComponent<RectTransform>();
	}

	void Update()
	{
		/*Rect rect1 = cursor.rect;
		Rect rect2 = gameSlot.rect;

		//Rect intersection = Rect.Intersect(rect1, rect2);

		if (rect1.Overlaps(rect2)){
			// The UI elements are touching or intersecting.
			// You can put your code here for handling the touch.
			gameSlot.localScale = newScale;
		} else {
			// The UI elements are not touching.
			gameSlot.localScale = oldScale;
		}*/
		CheckIfUIElementsTouch();
	}

	private void CheckIfUIElementsTouch()
    {
        // Get the positions of the UI elements in world space
        Vector3[] corners1 = new Vector3[4];
        uiElement1.GetWorldCorners(corners1);

        Vector3[] corners2 = new Vector3[4];
        uiElement2.GetWorldCorners(corners2);

        // Check if any corner of the first UI element is inside the bounds of the second UI element
        for (int i = 0; i < 4; i++)
        {
            if (IsPointInsideRect(corners1[i], corners2))
            {
				uiElement2.localScale = newScale;
                menuController.gameNum = gameNum;
                // The UI elements are touching or intersecting.
                // You can put your code here for handling the touch.
                return;
            }
        }

        // Check if any corner of the second UI element is inside the bounds of the first UI element
        for (int i = 0; i < 4; i++)
        {
            if (IsPointInsideRect(corners2[i], corners1))
            {
				uiElement2.localScale = newScale;
                // The UI elements are touching or intersecting.
                // You can put your code here for handling the touch.
                return;
            }
        }

        // The UI elements are not touching.
		uiElement2.localScale = oldScale;
    }

    private bool IsPointInsideRect(Vector3 point, Vector3[] rectCorners)
    {
        float maxX = Mathf.Max(rectCorners[0].x, rectCorners[1].x, rectCorners[2].x, rectCorners[3].x);
        float minX = Mathf.Min(rectCorners[0].x, rectCorners[1].x, rectCorners[2].x, rectCorners[3].x);
        float maxY = Mathf.Max(rectCorners[0].y, rectCorners[1].y, rectCorners[2].y, rectCorners[3].y);
        float minY = Mathf.Min(rectCorners[0].y, rectCorners[1].y, rectCorners[2].y, rectCorners[3].y);

        return point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY;
    }
}
