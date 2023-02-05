using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    enum Direction
    {
        //up,
        down,
        left,
        right
    }

    Direction direction;

    public List<Transform> Tail = new List<Transform>();
    public float frameRate = 0.2f;
    public float step = 3.2f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", frameRate, frameRate);
    }
    void Move() 
    {
        lastPos = transform.position;

        Vector3 nextPos = Vector3.zero;
        /*if (direction == Direction.up)
            nextPos = Vector3.up;*/
        if (direction == Direction.down)
            nextPos = Vector3.down;
        else if (direction == Direction.left)
            nextPos = Vector3.left;
        else if (direction == Direction.right)
            nextPos = Vector3.right;
        nextPos *= step;
        transform.position += nextPos;

        MoveTail();
    }

    Vector3 lastPos;
    void MoveTail()
    {
        for (int i = 0; i < Tail.Count; i++)
        {
            Vector3 temp = Tail[i].position;
            Tail[i].position = lastPos;  
            lastPos = temp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.UpArrow))
            direction = Direction.up;*/
        if(Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.down;
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.left;
        else if(Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.right;
    }
}
