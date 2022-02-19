using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class SaveService
{
    private LocalSavesData _localSavesData;
    public LocalSavesData LocalSavesData => _localSavesData;
    
    public SaveService(LocalSavesData localSavesData)
    {
        _localSavesData = localSavesData;
    }
}
