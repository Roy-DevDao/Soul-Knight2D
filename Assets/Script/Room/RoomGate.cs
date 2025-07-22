using UnityEngine;
using System.Collections;

public class RoomGate : MonoBehaviour
{
    public delegate void OnEnterCallback();
    private OnEnterCallback enterCallback;

    [HideInInspector]
    public RoomController roomController;

    private bool hasBeenEnteredWhenUnsolved = false;

    public void onEnter(OnEnterCallback callback)
    {
        this.enterCallback = callback;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        // Kiểm tra va chạm là với phần nào của cổng (START hay END)
        if (collision.otherCollider.tag == TAG.GATE_START)
        {
            if (roomController != null && !roomController.isSolved)
            {
                if (!hasBeenEnteredWhenUnsolved)
                {
                    hasBeenEnteredWhenUnsolved = true;
                    roomController.HideGateTemporarily(this.gameObject); ;
                    enterCallback?.Invoke();
                }
            }
            else if (roomController != null && roomController.isSolved)
            {
                roomController.HideGateTemporarily(this.gameObject);
            }
        }
        else if (collision.otherCollider.tag == TAG.GATE_END)
        {
            if (roomController != null && roomController.isSolved)
            {
                roomController.HideGateTemporarily(this.gameObject);
            }
            // Nếu chưa clear thì không làm gì (bị khóa)
        }
    }

    private IEnumerator OpenAndCloseGateTemporarily()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(true);
    }
}
