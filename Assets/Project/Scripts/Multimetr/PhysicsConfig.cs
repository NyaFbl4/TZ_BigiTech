using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(menuName = "Game/PhysicsConfig", fileName = "PhysicsConfig ")]
    public class PhysicsConfig : ScriptableObject
    {
        [SerializeField] private float _moshnost;
        [SerializeField] private float _soprotivlenie;
        [SerializeField] private float _napryajeniePeremennogoToka;

        //public float Napravlenie => _napryajenie;
        public float NapryajeniePeremennogoToka => _napryajeniePeremennogoToka;
        public float Moshnost => _moshnost;
        public float Soprotivlenie => _soprotivlenie;
    }
}