using Jenga.Block;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.OnGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.OnGround = false;
        }
    }
}
