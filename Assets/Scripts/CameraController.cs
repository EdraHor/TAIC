using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public float CameraDistanceZ;
    public float CameraDistanceY;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform Player;
    private int lastX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(Player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(Player.position.x - offset.x, Player.position.y + offset.y + CameraDistanceY, Player.position.z - CameraDistanceZ);
        }
        else
        {
            transform.position = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y + CameraDistanceY, Player.position.z - CameraDistanceZ);
        }
    }

    void Update()
    {
        if (Player)
        {
            int currentX = Mathf.RoundToInt(Player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;

            lastX = Mathf.RoundToInt(Player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(Player.position.x - offset.x, Player.position.y + offset.y + CameraDistanceY, Player.position.z - CameraDistanceZ);
            }
            else
            {
                target = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y + CameraDistanceY, Player.position.z - CameraDistanceZ);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
