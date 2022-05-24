using UnityEngine;
namespace Core.Character
{
    public class DetectorFighting : MonoBehaviour
    {
        protected Character _currentTarget;
        public bool IsFight => _currentTarget != null;
    }
}