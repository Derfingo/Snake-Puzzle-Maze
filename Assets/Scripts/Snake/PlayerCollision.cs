using UnityEngine;
using UnityEngine.Events;
using Snake;
using Food;
using UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private SnakeTail SnakeTail;
    [SerializeField] private Movement Movement;
    [SerializeField] private BoostSpeed boostSpeed;

    public UnityEvent OnEat;

    public event UnityAction<int> ScoreChanged;

    private int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IsEating>())
        {
            scoreValue++;
            ScoreChanged?.Invoke(scoreValue);
            collision.GetComponent<IsEating>().OnHit();
            SnakeTail.MakeNode();

            if (Movement != null)
            {
                Movement.Speed += 5f;
            }

            if (OnEat != null)    //OnEat?.Invoke();
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.GetComponent<BoostSpeed>())
        {
            StartCoroutine(BoostSpeedPlayer());
        }

        if (collision.gameObject.GetComponent<RotationCell>())
        {
            MenuManager.Instance.GameOver();
        }

        //if (collision.gameObject.GetComponent<CompositeCollider2D>())
        //{
        //    MenuManager.Instance.GameOver();
        //}

        if (collision.gameObject.GetComponent<NodeTail>())
        {
            MenuManager.Instance.GameOver();
        }

        if (collision.gameObject.GetComponent<LevelComplete>())
        {
            MenuManager.Instance.GameWon();
        }
    }

    private IEnumerator BoostSpeedPlayer()
    {
        Movement.Speed += 40f;
        yield return new WaitForSeconds(3);
        Movement.Speed -= 40f;

        yield break;
    }
}
