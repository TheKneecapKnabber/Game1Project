using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

interface IAutomatic
{
    public bool firing { get; set; }
    
    void StartFiring();
    
    void StopFiring();

}
