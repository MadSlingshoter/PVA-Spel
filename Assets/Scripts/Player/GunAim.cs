using UnityEngine;

public class GunAim : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        aimAngle();
    }


    // Aiming direction of gun
    private void aimAngle()
    {
        float horizontalInput = Input.GetAxis("HorizontalPlayer1");
        float verticalInput = Input.GetAxis("VerticalPlayer1");
        int angle = 0;

        if (horizontalInput != 0 && verticalInput != 0)
            angle = 45;
        else if (verticalInput != 0)
            angle = 90;
        else
            angle = 0;

        if (verticalInput < -0.01f)
            angle *= -1;

        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
