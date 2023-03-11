using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Transform[] Snakeobjs;
    public List<Transform> GridList = new List<Transform>();

    private void Awake()
    {
        EventHandler.GameMouseDown += OnGameMouseDown;
    }

    private void OnDestroy()
    {
        EventHandler.GameMouseDown -= OnGameMouseDown;
    }

    private void Start()
    {
        foreach (var grid in GridList)
        {
            grid.AddComponent<GetGridPos>();
        }
    }

    private void OnGameMouseDown(Vector3 pos)
    {
        float disHead = (pos - Snakeobjs.First().transform.localPosition).magnitude;
        float disTail = (pos - Snakeobjs.Last().transform.localPosition).magnitude;

        if (disHead < 1.3f)
        {
            RefreshSnakeHead();
            Snakeobjs.First().transform.localPosition = pos;
        }

        if (disTail < 1.3f)
        {
            RefreshSnakeTail();
            Snakeobjs.Last().transform.localPosition = pos;
        }
    }

    private void RefreshSnakeHead()
    {
        var length = Snakeobjs.Length - 1;
        for (var i = length; i > 0; i--)
        {
            Snakeobjs[i].transform.localPosition = Snakeobjs[i - 1].transform.localPosition;
        }
    }

    private void RefreshSnakeTail()
    {
        var length = Snakeobjs.Length - 1;
        for (int i = 0; i < length; i++)
        {
            Snakeobjs[i].transform.localPosition = Snakeobjs[i + 1].transform.localPosition;
        }
    }
}