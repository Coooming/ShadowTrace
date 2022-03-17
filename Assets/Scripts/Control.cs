using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject character;
    public GameObject shadow;

    private Track track;

    // character相关组件
    private Transform characterTransform;
    private Transform characterBottom;
    private Rigidbody characterRigidbody;
    private CharacterAnimation characterAnimation;

    // shadow相关组件
    private Transform shadowTransform;
    private Transform shadowBottom;
    private Rigidbody shadowRigidbody;
    private ShadowAnimation shadowAnimation;
    private InteractController shadowInteract;

    // 方向定义
    public static Vector3 directionLeft = new Vector3(-1, 0, 0);
    public static Vector3 directionRight = new Vector3(1, 0, 0);
    public static Vector3 directionUp = new Vector3(0, 1, 0);
    public static Vector3 directionDown = new Vector3(0, -1, 0);
    
    // 按键定义
    public static KeyCode leftKey = KeyCode.LeftArrow;
    public static KeyCode rightKey = KeyCode.RightArrow;
    public static KeyCode jumpKey = KeyCode.Space;
    public static KeyCode interactKey = KeyCode.F;
    public static KeyCode reflectKey = KeyCode.Return;
    
    private const float eps = 1e-6f; // 精度，用于跳跃结束判断
    private const float bottomHeight = 0.35f; // 底部高度，用于跳跃结束判断
    private const float collisionWidth = 1.2f; // 碰撞检测宽度，用于移动合法性判断

    public float moveSpeed = 5f; // 移动速度
    public float jumpSpeed = 3f; // 跳跃速度
    public float jumpHeight = 5f; // 跳跃高度

    Queue<char> movement = new Queue<char>(); // 动作指令队列（A为左移，D为右移，L为左跳，R为右跳，U为原地跳）

    [SerializeField] private int movementNumber = 0; // 动作指令数量（队列的长度）
    [SerializeField] private bool isReflecting = false; // 标识是否正在执行反映
    [SerializeField] private bool isJumping = false; // 标识是否正在跳跃
    [SerializeField] private char jumpingDirection; // 跳跃方向

    private bool aboutToRetry = false; // 标识是否准备重置游戏
    private int retryFrame = 0; // 重置游戏的等待帧数
    private int reflectingCount = 0; // 执行反映的操作次数

    // 为交互控制提供的接口
    public bool CanInteract()
    {
        return !isReflecting && !isJumping;
    }

    // 为轨迹记录提供的接口
    public Vector3 getCharacterCenter()
    {
        return characterTransform.GetChild(0).position;
    }

    public Vector3 getShadowCenter()
    {
        return shadowTransform.GetChild(0).position;
    }

    void Start()
    {
        track = GameObject.Find("TrackDrawer").GetComponent<Track>();

        characterTransform = character.transform;
        characterBottom = characterTransform.GetChild(1);
        characterRigidbody = character.GetComponent<Rigidbody>();
        characterAnimation = character.GetComponent<CharacterAnimation>();

        shadowTransform = shadow.transform;
        shadowBottom = shadowTransform.GetChild(1);
        shadowRigidbody = shadow.GetComponent<Rigidbody>();
        shadowAnimation = shadow.GetComponent<ShadowAnimation>();
        shadowInteract = shadow.GetComponent<InteractController>();
    }

    void Update()
    {
        // 检测ESC键退出程序
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        // 检测是否准备重置游戏
        if (aboutToRetry)
        {
            retryFrame += 1;
            if (retryFrame > 60)
            {
                track.BackupTrack();
                LevelManager.Instance().Retry(false);
            }
            return;
        }

        int countLimit = LevelManager.Instance().currLevel == 2 ? 2 : 1; // 反映操作次数上限
        // 判断是否已经达到反映操作次数限制
        if (reflectingCount >= countLimit)
        {
            aboutToRetry = true;
            return;
        }

        // 检测是否正在执行反映
        if (isReflecting)
        {
            // 检测是否正在跳跃
            if (isJumping)
            {
                RaycastHit hit;
                Physics.Raycast(shadowBottom.position, directionDown, out hit); // 射线检测
                float verticalVelocity = shadowRigidbody.velocity.y; // 获取垂直方向的速度
                
                // 判断是否跳跃结束
                if (hit.collider != null && hit.distance < bottomHeight && verticalVelocity < eps)
                {
                    isJumping = false;
                    shadowAnimation.setIsJumping(false);
                    return;
                }

                // 若跳跃未结束，按照跳跃方向进行移动
                switch (jumpingDirection)
                {
                    case 'L':
                        shadowTransform.position += directionRight * jumpSpeed * Time.deltaTime;
                        break;
                    case 'R':
                        shadowTransform.position += directionLeft * jumpSpeed * Time.deltaTime;
                        break;
                }
                return;
            }

            shadowAnimation.setIsInteracting(false);
            // 判断反映动作是否执行完
            if (movementNumber == 0)
            {
                isReflecting = false;
                shadowAnimation.setIsStop(true);
                reflectingCount += 1;
                return;
            }    

            movementNumber--;
            char move = movement.Dequeue();
            if (move == 'A')
            {
                shadowTransform.position += directionRight * moveSpeed * Time.deltaTime;
                shadowAnimation.setIsStop(false);
                shadowAnimation.setIsToRight(true);
                shadowAnimation.setIsInteracting(false);
            }
            else if (move == 'D')
            {
                shadowTransform.position += directionLeft * moveSpeed * Time.deltaTime;
                shadowAnimation.setIsStop(false);
                shadowAnimation.setIsToRight(false);
                shadowAnimation.setIsInteracting(false);
            }
            else if (move == 'L')
            {
                shadowRigidbody.velocity += directionUp * jumpHeight;
                isJumping = true;
                jumpingDirection = 'L';
                shadowAnimation.setIsStop(false);
                shadowAnimation.setIsInteracting(false);
                shadowAnimation.setIsJumping(true);
            }
            else if (move == 'R')
            {
                shadowRigidbody.velocity += directionUp * jumpHeight;
                isJumping = true;
                jumpingDirection = 'R';
                shadowAnimation.setIsStop(false);
                shadowAnimation.setIsInteracting(false);
                shadowAnimation.setIsJumping(true);
            }
            else if (move == 'U')
            {
                shadowRigidbody.velocity += directionUp * jumpHeight;
                isJumping = true;
                jumpingDirection = 'U';
                shadowAnimation.setIsStop(false);
                shadowAnimation.setIsInteracting(false);
                shadowAnimation.setIsJumping(true);
            }
            else if (move == 'F')
            {
                shadowInteract.DoInteract();
                shadowAnimation.setIsInteracting(true);
            }
            return;
        }

        // 检测是否正在跳跃
        if (isJumping)
        {
            RaycastHit hit;
            Physics.Raycast(characterBottom.position, directionDown, out hit); // 射线检测
            float verticalVelocity = characterRigidbody.velocity.y; // 获取垂直方向的速度

            // 判断是否跳跃结束
            if (hit.collider != null && hit.distance < bottomHeight && verticalVelocity < eps)
            {
                isJumping = false;
                characterAnimation.setIsJumping(false);
                return;
            }

            // 若跳跃未结束，按照跳跃方向进行移动
            switch (jumpingDirection)
            {
                case 'L':
                    characterTransform.position += directionLeft * jumpSpeed * Time.deltaTime;
                    break;
                case 'R':
                    characterTransform.position += directionRight * jumpSpeed * Time.deltaTime;
                    break;
            }
            return;
        }

        // 检测跳跃键
        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            characterRigidbody.velocity += directionUp * jumpHeight; // 施加跳跃
            movementNumber++;
            characterAnimation.setIsStop(false);
            characterAnimation.setIsInteracting(false);
            characterAnimation.setIsJumping(true);

            // 判断跳跃方向
            if (Input.GetKey(leftKey))
            {
                movement.Enqueue('L');
                jumpingDirection = 'L';
            }
            else if (Input.GetKey(rightKey))
            {
                movement.Enqueue('R');
                jumpingDirection = 'R';
            }
            else
            {
                movement.Enqueue('U');
                jumpingDirection = 'U';
            }
            return;
        }

        // 检测左移键
        if (Input.GetKey(leftKey))
        {
            RaycastHit hit;
            Physics.Raycast(characterBottom.position, directionLeft, out hit); // 射线检测
            // 判断是否为有效移动
            if (hit.collider == null || hit.distance > collisionWidth)
            {
                movementNumber++;
                movement.Enqueue('A');
                characterTransform.position += directionLeft * moveSpeed * Time.deltaTime;
                characterAnimation.setIsStop(false);
                characterAnimation.setIsToRight(false);
                characterAnimation.setIsInteracting(false);
            }
            return;
        }
        
        // 检测右移键
        if (Input.GetKey(rightKey))
        {
            RaycastHit hit;
            Physics.Raycast(characterBottom.position, directionRight, out hit); // 射线检测
            // 判断是否为有效移动
            if (hit.collider == null || hit.distance > collisionWidth)
            {
                movementNumber++;
                movement.Enqueue('D');
                characterTransform.position += directionRight * moveSpeed * Time.deltaTime;
                characterAnimation.setIsStop(false);
                characterAnimation.setIsToRight(true);
                characterAnimation.setIsInteracting(false);
            }
            return;
        }

        // 检测交互键
        if (Input.GetKeyDown(interactKey))
        {
            movementNumber++;
            movement.Enqueue('F');
            characterAnimation.setIsInteracting(true);
            return;
        }

        // 检测执行键
        if (Input.GetKeyDown(reflectKey))
        {
            isReflecting = true;
            characterAnimation.setIsStop(true);
            characterAnimation.setIsInteracting(false);
            return;
        }

        characterAnimation.setIsStop(true);
        characterAnimation.setIsInteracting(false);
    }
}
