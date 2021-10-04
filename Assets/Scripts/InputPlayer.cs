using System.Collections;
using UnityEngine;



namespace Snake
{
    public class InputPlayer : MonoBehaviour
    {
        [SerializeField] private CharacterController snakeHead;
        [SerializeField] private Joystick joystick;
        [SerializeField] private float speed;
        private float startSpeed;
        private float deltaX = 0f;
        [SerializeField] private float speedDeltaX;
        private Vector3 moveDirection;

        [SerializeField] private Animator animator;
        [SerializeField] private PowerUp powerUp;
        

        void Start()
        {
            if (snakeHead != null)
            {
                snakeHead.GetComponent<CharacterController>();
            }
            animator.GetComponent<Animator>();
            startSpeed = speed;
        }

        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
                deltaX = joystick.Direction.x * speedDeltaX;
               
                if (powerUp.startTimerFever == true && snakeHead.transform.position.x != 0)
                {

                    if (snakeHead.transform.position.x < 1f && snakeHead.transform.position.x > -1f)
                    {
                    deltaX = 0;;
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                    }
                    else 
                    {
                    deltaX = 10;
                    deltaX = snakeHead.transform.position.x > 0 ? -deltaX : deltaX;
                    }
                }
                moveDirection = new Vector3(deltaX, 0, speed);
                snakeHead.Move(moveDirection * Time.fixedDeltaTime);
            
                ///Animation
            
                if (deltaX > 0)
                {
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", true);
                }
                else
                {
                    animator.SetBool("Right", false);
                }
                if (deltaX < 0)
                {
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                }
                else
                {
                    animator.SetBool("Left", false);
                }
        }
        /// <summary>
        /// How many times the speed is higher
        /// </summary>
        /// <param factor ="factor *"></param>
        public void SuperSpeed(int factor, bool division)
        {
            if (division == true)
            {
                speed = startSpeed;
                speed = speed * factor;
            }

            if(division == false)
            {
                speed = speed / factor;
            }
        }
        public void SetCharacterController(CharacterController charContrl)
        {
            snakeHead = charContrl;
        }
    }
}
