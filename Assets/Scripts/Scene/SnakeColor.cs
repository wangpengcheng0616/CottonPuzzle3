using DG.Tweening;
using UnityEngine;

public class SnakeColor : MonoBehaviour
{
    public enum SnakeType
    {
        Yellow = 0,
        Red,
        Blue,
        Green,
        Gray
    }

    public SnakeType m_SnakeType;

    public Sprite[] spritesUnChange;
    public Sprite[] spritesChange;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        DOTween.Sequence().AppendInterval(0.05f).AppendCallback
        (
            () =>
            {
                switch (m_SnakeType)
                {
                    case SnakeType.Yellow:
                        if (col.CompareTag("Yellow"))
                        {
                            ChangeSnakeSprite(m_SnakeType);
                        }

                        break;
                    case SnakeType.Red:
                        if (col.CompareTag("Red"))
                        {
                            ChangeSnakeSprite(m_SnakeType);
                        }

                        break;
                    case SnakeType.Blue:
                        if (col.CompareTag("Blue"))
                        {
                            ChangeSnakeSprite(m_SnakeType);
                        }

                        break;
                    case SnakeType.Green:
                        if (col.CompareTag("Green"))
                        {
                            ChangeSnakeSprite(m_SnakeType);
                        }

                        break;
                }
            }
        );
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (m_SnakeType)
        {
            case SnakeType.Yellow:
                if (other.CompareTag("Yellow"))
                {
                    UnChangeSnakeSprite(m_SnakeType);
                }

                break;
            case SnakeType.Red:
                if (other.CompareTag("Red"))
                {
                    UnChangeSnakeSprite(m_SnakeType);
                }

                break;
            case SnakeType.Blue:
                if (other.CompareTag("Blue"))
                {
                    UnChangeSnakeSprite(m_SnakeType);
                }

                break;
            case SnakeType.Green:
                if (other.CompareTag("Green"))
                {
                    UnChangeSnakeSprite(m_SnakeType);
                }

                break;
        }
    }

    private void ChangeSnakeSprite(SnakeType snakeType)
    {
        spriteRenderer.sprite = spritesChange[(int)snakeType];
        EventHandler.CallGamePassNumEvent(-1);
    }

    private void UnChangeSnakeSprite(SnakeType snakeType)
    {
        spriteRenderer.sprite = spritesUnChange[(int)snakeType];
        EventHandler.CallGamePassNumEvent(1);
    }
}