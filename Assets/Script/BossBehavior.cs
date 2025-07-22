using System;
using System.Collections;
using UnityEngine;

// Đảm bảo có Rigidbody2D trên GameObject
[RequireComponent(typeof(Rigidbody2D))]
public class BossBehavior : BaseEnemy
{
    //public Animator animator;
    //public Transform player; // Kéo thả đối tượng Player vào đây

    //// Kéo thả SpriteRenderer của đối tượng vào đây nếu muốn lật hình ảnh
    //public SpriteRenderer spriteRenderer;

    //public float attackRange = 2f;     // Khoảng cách để kích hoạt tấn công khi nhìn thấy
    //public float visionRange = 50f;    // Tầm nhìn của boss bằng Raycast
    //public float walkTime = 3f;        // Thời gian cho trạng thái đi
    //public float idleTime = 3f;        // Thời gian cho trạng thái đứng

    //public float moveSpeed = 2f;       // Tốc độ di chuyển của boss

    //// Các biến mới cho hệ thống tấn công
    //public float attackCooldown = 1f;  // Thời gian chờ giữa các lần tấn công
    //private bool canAttack = true;     // Biến kiểm soát có thể tấn công hay không

    //// Các biến mới cho hiệu ứng lướt tới
    //public float dashDistance = 2f;    // Khoảng cách boss lướt tới khi tấn công
    //public float dashDuration = 0.2f;  // Thời gian boss hoàn thành cú lướt

    //// Các Layer cần kiểm tra khi Raycast (Player và MapWall)
    //public LayerMask visionBlockingLayers; // Thiết lập trong Inspector: chọn Player và MapWall

    //private Coroutine patrolCoroutine;
    //private Rigidbody2D rb2d;          // Tham chiếu đến Rigidbody2D
    //private Vector2 currentVisionDirection; // Hướng Raycast gần nhất

    void Start()
    {
        base.Start();
        //if (animator == null)
        //{
        //    animator = GetComponent<Animator>();
        //}
        //if (spriteRenderer == null)
        //{
        //    spriteRenderer = GetComponent<SpriteRenderer>();
        //}
        //rb2d = GetComponent<Rigidbody2D>();
        //rb2d.freezeRotation = true;

        //// Bắt đầu chu trình tuần tra ban đầu
        //patrolCoroutine = StartCoroutine(PatrolRoutine());
    }

    void Update()
    {
        base.Update();
        //if (player == null) return;

        //// Cập nhật hướng nhìn
        //currentVisionDirection = (player.position - transform.position).normalized;

        //// Lật sprite theo hướng nhìn
        //if (spriteRenderer != null)
        //{
        //    spriteRenderer.flipX = currentVisionDirection.x < 0;
        //}

        //// Thực hiện Raycast để kiểm tra tầm nhìn
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, currentVisionDirection, visionRange, visionBlockingLayers);

        //// Debug Raycast (hiện thị trong Scene View)
        //Color rayColor = Color.blue;
        //bool playerSeenAndInAttackRange = false;

        //if (hit.collider != null)
        //{
        //    Debug.Log($"Raycast hit: {hit.collider.name}, Tag: {hit.collider.tag}"); // Log collider mà Raycast chạm vào

        //    // Nếu Raycast chạm vào Player VÀ khoảng cách đến Player trong tầm tấn công
        //    if (hit.collider.CompareTag("Player") && hit.distance <= attackRange)
        //    {
        //        rayColor = Color.red; // Đổi màu Raycast thành đỏ
        //        playerSeenAndInAttackRange = true;
        //    }
        //    // Nếu Raycast chạm vào vật cản khác (ví dụ: tường) trước Player
        //    else if (hit.collider.CompareTag("MapWall")) // Đảm bảo tag vật cản là "MapWall"
        //    {
        //        rayColor = Color.yellow; // Đổi màu Raycast thành vàng
        //    }
        //}
        //Debug.DrawRay(transform.position, currentVisionDirection * visionRange, rayColor);

        //// Logic tấn công hoặc tuần tra dựa trên kết quả Raycast
        //if (playerSeenAndInAttackRange)
        //{
        //    // Nếu người chơi trong tầm nhìn VÀ trong tầm tấn công
        //    if (canAttack)
        //    {
        //        // Dừng tuần tra nếu đang hoạt động
        //        if (patrolCoroutine != null)
        //        {
        //            StopCoroutine(patrolCoroutine);
        //            patrolCoroutine = null;
        //            animator.SetBool("IsWalking", false);
        //            rb2d.linearVelocity = Vector2.zero; // Dừng di chuyển
        //        }

        //        animator.SetTrigger("Attack");
        //        StartCoroutine(DashTowardsPlayer(dashDistance, dashDuration));

        //        canAttack = false;
        //        StartCoroutine(AttackCooldownRoutine());
        //    }
        //}
        //else // Người chơi không nằm trong tầm tấn công hoặc bị che khuất
        //{
        //    // Nếu boss đang không tuần tra, hãy bắt đầu lại chu trình tuần tra
        //    if (patrolCoroutine == null)
        //    {
        //        rb2d.linearVelocity = Vector2.zero;
        //        animator.SetBool("IsWalking", false);
        //        patrolCoroutine = StartCoroutine(PatrolRoutine());
        //    }
        //}
    }

    //private IEnumerator PatrolRoutine()
    //{
    //    while (true)
    //    {
    //        animator.SetBool("IsWalking", true);

    //        Vector2[] possibleDirections = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    //        Vector2 chosenMoveDirection = possibleDirections[UnityEngine.Random.Range(0, possibleDirections.Length)];

    //        float startTime = Time.time;
    //        while (Time.time < startTime + walkTime)
    //        {
    //            rb2d.linearVelocity = chosenMoveDirection * moveSpeed;
    //            yield return null;
    //        }

    //        animator.SetBool("IsWalking", false);
    //        rb2d.linearVelocity = Vector2.zero;
    //        yield return new WaitForSeconds(idleTime);
    //    }
    //}

    //private IEnumerator AttackCooldownRoutine()
    //{
    //    yield return new WaitForSeconds(attackCooldown);
    //    canAttack = true;
    //}

    //private IEnumerator DashTowardsPlayer(float distance, float duration)
    //{
    //    Vector2 startPosition = rb2d.position;
    //    Vector2 targetDirection = (player.position - transform.position).normalized;
    //    Vector2 endPosition = startPosition + targetDirection * distance;

    //    float elapsed = 0f;
    //    while (elapsed < duration)
    //    {
    //        rb2d.MovePosition(Vector2.Lerp(startPosition, endPosition, elapsed / duration));
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    rb2d.MovePosition(endPosition);
    //    rb2d.linearVelocity = Vector2.zero;
    //}
}