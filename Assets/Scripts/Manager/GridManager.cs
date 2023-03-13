using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Serializable]
    public class Snake
    {
        public SnakeId snakeId;
        public Transform[] transforms;
    }

    public List<Snake> m_Snakes = new List<Snake>();

    public List<Transform> GridList = new List<Transform>();

    private int m_CurrentSnakeId;
    private SnakeDragType m_CurrentSnakeDragType;

    private void Awake()
    {
        EventHandler.GameMouseDownEvent += OnGameMouseDownEvent;
        EventHandler.GameSnakeMoveEvent += OnGameSnakeMoveEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GameMouseDownEvent -= OnGameMouseDownEvent;
        EventHandler.GameSnakeMoveEvent -= OnGameSnakeMoveEvent;
    }

    private void Start()
    {
        foreach (var grid in GridList)
        {
            grid.AddComponent<GridPos>();
        }
    }

    private void OnGameSnakeMoveEvent(SnakeId snakeId, SnakeDragType snakeDragType)
    {
        m_CurrentSnakeId = (int)snakeId;
        m_CurrentSnakeDragType = snakeDragType;
    }

    private void OnGameMouseDownEvent(Vector3 pos)
    {
        switch (m_CurrentSnakeDragType)
        {
            case SnakeDragType.Head:
                float disHead = (pos - m_Snakes[m_CurrentSnakeId].transforms.First().localPosition)
                    .magnitude;
                if (disHead < 1.3f)
                {
                    RefreshSnake(m_CurrentSnakeDragType);

                    // TODO: Line
                    m_Snakes[m_CurrentSnakeId].transforms.First().GetChild(0).gameObject.SetActive(true);
                    m_Snakes[m_CurrentSnakeId].transforms.Last().GetChild(0).gameObject.SetActive(false);
                    RefreshSnakeRotation(pos, m_Snakes[m_CurrentSnakeId].transforms.First().localPosition, 0);

                    m_Snakes[m_CurrentSnakeId].transforms.First().transform.localPosition = pos;
                }

                break;
            case SnakeDragType.Tail:
                float disTail = (pos - m_Snakes[m_CurrentSnakeId].transforms.Last().localPosition).magnitude;


                if (disTail < 1.3f)
                {
                    RefreshSnake(m_CurrentSnakeDragType);

                    // Line
                    m_Snakes[m_CurrentSnakeId].transforms.First().GetChild(0).gameObject.SetActive(false);
                    m_Snakes[m_CurrentSnakeId].transforms.Last().GetChild(0).gameObject.SetActive(true);
                    RefreshSnakeRotation(pos, m_Snakes[m_CurrentSnakeId].transforms.Last().localPosition,
                        m_Snakes[m_CurrentSnakeId].transforms.Length - 1);

                    m_Snakes[m_CurrentSnakeId].transforms.Last().localPosition = pos;
                }

                break;
        }
    }

    private void RefreshSnake(SnakeDragType snakeDragType)
    {
        var length = m_Snakes[m_CurrentSnakeId].transforms.Length - 1;
        switch (snakeDragType)
        {
            case SnakeDragType.Head:
                for (var i = length; i > 0; i--)
                {
                    RefreshSnakeRotation(m_Snakes[m_CurrentSnakeId].transforms[i - 1].localPosition,
                        m_Snakes[m_CurrentSnakeId].transforms[i].localPosition, i);

                    m_Snakes[m_CurrentSnakeId].transforms[i].localPosition =
                        m_Snakes[m_CurrentSnakeId].transforms[i - 1].localPosition;
                }

                break;
            case SnakeDragType.Tail:
                for (int i = 0; i < length; i++)
                {
                    RefreshSnakeRotation(m_Snakes[m_CurrentSnakeId].transforms[i + 1].localPosition,
                        m_Snakes[m_CurrentSnakeId].transforms[i].localPosition, i);

                    m_Snakes[m_CurrentSnakeId].transforms[i].localPosition =
                        m_Snakes[m_CurrentSnakeId].transforms[i + 1].localPosition;
                }

                break;
        }
    }

    private void RefreshSnakeRotation(Vector3 targetPos, Vector3 currentPos, int id)
    {
        var x = targetPos.x - currentPos.x;
        var y = targetPos.y - currentPos.y;
        if (x < 0)
        {
            m_Snakes[m_CurrentSnakeId].transforms[id].rotation = Quaternion.Euler(0, 0, 90f);
        }

        if (x > 0)
        {
            m_Snakes[m_CurrentSnakeId].transforms[id].rotation = Quaternion.Euler(0, 0, 270f);
        }

        if (y > 0)
        {
            m_Snakes[m_CurrentSnakeId].transforms[id].rotation = Quaternion.Euler(0, 0, 0f);
        }

        if (y < 0)
        {
            m_Snakes[m_CurrentSnakeId].transforms[id].rotation = Quaternion.Euler(0, 0, 180f);
        }
    }
}