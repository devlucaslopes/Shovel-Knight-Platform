using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float Speed;

    private bool _hasPlayer;
    private Vector2 _originalPosition;

    void Start()
    {
        _originalPosition = transform.position;
    }

    void Update()
    {
        if (_hasPlayer)
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        } else
        {
            if (Vector2.Distance(transform.position, _originalPosition) >= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, _originalPosition, Speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            _hasPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            _hasPlayer = false;
        }
    }
}
