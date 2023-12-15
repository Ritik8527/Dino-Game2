using UnityEngine;

public class Animate : MonoBehaviour
{
    public Sprite[] sprites;
    private int frame;
    // private float time = 0f;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        //animate(); // PROLBLEM WITH THIS IS ->  IT WILL BE CALLED IMMEDIATLELY  AND  Start() is called later after OnEnable() , as in GameManager script
        //                  Start() (which will call newGame() which sets gameInitialspped, as OnENable() called first hence at this time initialgameSPeed=0
        //                  so, 1/0f is problem causing so use INvoke with time=0f, it will called function in next frame. using 0f time in invoke is trick  

        Invoke(nameof(animate), 0f);
        /* but if we replace OnEnable with Start here then this function will called once only in whole game so while restarting when gmeover start will not called
        hence use onenable function here   */
    }

    private void OnDisable()
    {
        CancelInvoke();  // this will cancel invoke(i.e. animation as we putting animation in invoke here) once gameOver (we will set when gameover later in gamemanager) 
    }

    private void animate()
    {
        frame++;

        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(animate), 1f / GameManager.Instance.gameSpeed);  // more gameSpedd less 1/gameSpeed so will call faster;



    }


}


// TRIES OWN WITH CHANGING OF SPIRTE 
// private void Update()
//     {
//         time += Time.deltaTime;
//         spriteRenderer.sprite = sprites[frame];
//         if (time > 1f)
//         {
//             time = 0;
//             frame++;
//         }
//     }
