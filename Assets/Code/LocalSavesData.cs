using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "LocalSaves", menuName = "LocalSaves", order = 351)]
    public class LocalSavesData : ScriptableObject
    {
        public bool IntroViewed;
        public bool WentToTheFirstArch;
    }
}