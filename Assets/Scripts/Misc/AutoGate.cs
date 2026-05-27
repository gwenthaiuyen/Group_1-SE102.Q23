using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AutoGate : MonoBehaviour
{
    [Header("Gate Settings")]
    public float speed = 2f;
    public float moveHeight = 6f;

    [Header("Detection Settings")]
    public string playerTag = "Player";
    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isOpen = false;

    private void Start()
    {
        closedPos = transform.position; //vị trí ban đầu của cửa
        openPos = new Vector3(transform.position.x, transform.position.y - moveHeight, transform.position.z); //vị trí mở cửa



    }
    void Update()
    {
        //xác định vị trí của cửa
        Vector3 targetPos = isOpen ? openPos : closedPos;

        //cửa trượt xuống khi mở 
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isOpen = true; //mở cửa khi người chơi vào vùng phát hiện
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isOpen = false; //đóng cửa khi người chơi rời khỏi vùng phát hiện
        }
    }
}
