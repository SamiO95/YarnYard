/*
 
    ICORE means that the class has a behaviour it supervises. 
 
*/
using UnityEngine;

public interface ICORE
{
    enum Type { Slash }
    Type GetType();
    IBEHAVIOUR GetBehaviour();
    void SetBehaviour(IBEHAVIOUR behaviour);
    GameObject GetObject();
}
