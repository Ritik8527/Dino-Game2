using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    private float gravity = 9.81f * 2f;
    //public Transform playerPosition;
    private float force = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * force;
            }
        }
        character.Move(direction * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider coll)  // Ontrigger.. function only works when object whom we r colliding has isTrigger enabled
    {
        if (coll.tag == "obstacle")
        {
            //FindObjectOfType<GameManager>().newGame();  // both method of calling newGame() is correct , but remember to put newGame() funcition at public.
            //GameManager.Instance.newGame();
            // but we gonna use diff method, i.e. we gonna call gameOver() from GameManager this will be public function.
            GameManager.Instance.gameOver();
            // now we will call newGme() also but in diff function to restart game.

        }
    }
}
