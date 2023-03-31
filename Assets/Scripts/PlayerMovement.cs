using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject boom;
    public GameOverScreen GameOverScreen;
    //public Stopwatch Stopwatch;
    public float speed = 1f;
    public CharacterController karakter;
    public float gr = 0;
    public FixedJoystick joystik;
    private Animator animator;

    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
        karakter = GetComponent<CharacterController>();
        sfx = GetComponent<AudioSource>();

    }
    void Update()
    {
      

        //IMPLEMENTASIKAN JOYSTICK
        float x = joystik.Horizontal;
        float z = joystik.Vertical;

     

        //UNTUK MENNGERAKAN player
       // Vector3 move = transform.right * x + transform.forward * z;
        //karakter.Move(move * speed * Time.deltaTime);

        Vector3 movementDirection = new Vector3(x, 0, z);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //MEMBUAT GRAVITASI
        //velocity.y += gr * Time.deltaTime;
        //karakter.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);


            transform.forward = movementDirection;
        }
        else
        {
            animator.SetBool("IsMoving", false);
         
        }

    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("we hit something.");
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            animator.SetBool("IsNearEnemy", true);
            Destroy(collisionInfo.gameObject);

            Instantiate(boom, transform.position, Quaternion.identity);

            ScoreManager.instance.AddPoint();
        }else if (collisionInfo.gameObject.tag == "Coin")
        {
            
            Destroy(collisionInfo.gameObject);
            sfx.Play();
            //Instantiate(boom, transform.position, Quaternion.identity);

            ScoreManager.instance.AddPoint();
        }else if (collisionInfo.gameObject.tag == "Bullet")
        {
            animator.SetBool("IsHit", true);
            Destroy(collisionInfo.gameObject);

            Instantiate(boom, transform.position, Quaternion.identity);
            StopWatchGameOver();
            Time.timeScale = 0f;

        }
        StartCoroutine(Wait());
        

    }
    public void StopWatchGameOver()
    {
        GameOverScreen.Setup(Stopwatch.instance.score);
    }

    public void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.instance.score);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("IsNearEnemy", false);
        StartCoroutine(Wait());

    }
}