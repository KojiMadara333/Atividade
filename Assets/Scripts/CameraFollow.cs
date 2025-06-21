using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float fixedY = 0f;
    public float leftLimit = -10f;
    public float rightLimit = 10f;

    void LateUpdate()
    {
        if (player != null)
        {
            float targetX = player.position.x;

            //Limita posicao left right
            targetX = Mathf.Clamp(targetX, leftLimit, rightLimit);

            //y e z fixo
            transform.position = new Vector3(targetX, fixedY, transform.position.z);
        }
    }
}
