using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayCastProvider
{
    public Ray CreateRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
