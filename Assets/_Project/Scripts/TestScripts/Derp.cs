using UnityEngine;

public class Derp : MonoBehaviour
{

    public int[] rows = new int[] { -1, 0, 1 };     // x position of each row
    private int targetRow = 0;
    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        transform.position = new Vector3(rows[targetRow], 0, 0);
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetRow > 0)
        {
            targetRow--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && targetRow < rows.Length - 1)
        {
            targetRow++;
        }


        //Move Character Controller towards target row when distance is greater than 0.05
        if (Mathf.Abs(transform.position.x - rows[targetRow]) > 0.05f)
        {

            if (transform.position.x < rows[targetRow])
            {
                charController.Move(Vector3.right * Time.deltaTime);
            }
            else if (transform.position.x > rows[targetRow])
            {
                charController.Move(Vector3.left * Time.deltaTime);
            }
        }
        //Lerp transform to position when character controller is close enough
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(rows[targetRow], 0, 0), Time.deltaTime);
        }
    }

}