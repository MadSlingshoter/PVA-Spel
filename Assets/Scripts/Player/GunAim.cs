using UnityEngine;

public class GunAim : MonoBehaviour
{
    private int facingDir = 1;

    // Update is called once per frame
    void Update()
    {
        facingUpdate();
        aimAngle();
    }

    private void facingUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
            facingDir = 1;
        else if (horizontalInput < -0.01f)
            facingDir = -1;
    }

    // Aiming direction of gun
    private void aimAngle()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        int angle = 0;

        if (horizontalInput != 0 && verticalInput != 0)
            angle = 45;
        else if (verticalInput != 0)
            angle = 90;
        else
            angle = 0;

        if (verticalInput < -0.01f)
            angle *= -1;

        transform.eulerAngles = Vector3.forward * angle * facingDir;

    }
}
