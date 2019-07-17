using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;
    public Camera mainCamera;

    public void Shakeit()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.5f);
        Invoke("StopCameraShaking", shakeTime);
    }

    public void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.Range(-10f, 10f) * shakeMagnitude * Random.Range(-10f, 10f) - shakeMagnitude;
        float cameraShakingOffsetY = Random.Range(-10f, 10f) * shakeMagnitude * Random.Range(-10f, 10f) - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraInitialPosition.x += cameraShakingOffsetX;
        cameraInitialPosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
    }

    public void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
}
