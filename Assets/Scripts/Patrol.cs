using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public int startNode;
    private int numberOfNodes;
    private int currentNode;

    private bool playerIsHiding = false;
    private Animator Anim;
    public float direcao = 1f;
    public float axisX, axisY;

    public Transform[] moveSpots;
    void Start()
    {
        waitTime = startWaitTime;
        currentNode = startNode;
        numberOfNodes = moveSpots.Length;
        CheckInteraction.onPlayerHiding += HiddenPlayer;
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[NextNode(currentNode)].position, speed * Time.deltaTime);
        axisX = moveSpots[NextNode(currentNode)].position.x;
        axisY = moveSpots[NextNode(currentNode)].position.y;
        verificaDirecao();
        verificaAnimacao();

        if (Vector2.Distance(transform.position, moveSpots[NextNode(currentNode)].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                currentNode = NextNode(currentNode);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    private int NextNode(int current)
    {
        int returning = current + 1;
        if(returning == numberOfNodes)
        {
            returning = 0;
        }
        return returning;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerIsHiding)
        {
            Debug.LogError("Peguei Voce!");
        }
    }

    private void HiddenPlayer()
    {
        if (playerIsHiding)
        {
            playerIsHiding = false;
        }
        else
        {
            playerIsHiding = true;
        }
    }

    public void verificaDirecao()
    {
        Debug.LogError("X: " + axisX + " Y: " + axisY);
        if (axisX > 0) { direcao = 1f; }                // valor do eixo positivo está indo para direita
        else if (axisX < 0) { direcao = -1f; }          // valor do eixo negativo está indo para esquerda
        transform.localScale = new Vector3(direcao, 1f, 1f);
    }

    public void verificaAnimacao()
    {
        int antes = Anim.GetInteger("situacao");

        if (axisY < -0.05f)
        {
            Anim.SetInteger("situacao", 1);
            return;
        }
        else
        {
            if (axisY > 0.05f)
            {
                Anim.SetInteger("situacao", 2);
                return;
            }
        }

        if (axisX > 0.05f || axisX < -0.05f)
        {
            Anim.SetInteger("situacao", 3);
            return;

        }

        if (antes == 3)
            Anim.SetInteger("situacao", 4);
        else
            Anim.SetInteger("situacao", 0);
    }
}
