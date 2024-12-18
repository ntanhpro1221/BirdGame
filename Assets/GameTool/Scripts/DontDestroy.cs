

// ReSharper disable once CheckNamespace

using System;
using UnityEngine;

namespace GameTool
{
    public class DontDestroy : SingletonMonoBehaviour<DontDestroy>
    {
        protected override void Awake()
        {
            if (Exists())
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
