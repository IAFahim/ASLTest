using System;
using UnityEngine;

namespace Customization.Runtime
{
    public class MaterialSwitcher : MonoBehaviour
    {
        private MaterialPropertyBlock _materialPropertyBlock;
        private void Awake()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
        }
    }
}