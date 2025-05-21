using UnityEngine;

namespace Project.Scripts
{
    public class PhysicsModel
    {
        private float _moshnost;
        
        private float _silaToka;
        private float _soprotivlenie;
        private float _napryajeniePeremennogoToka;
        private float _napryajeniePostoyannogoToka;
        
        
        public float SilaToka => _silaToka;
        public float Soprotivlenie => _soprotivlenie;
        public float NapryajeniePeremennogoToka => _napryajeniePeremennogoToka;
        public float NapryajeniePostoyannogoToka => _napryajeniePostoyannogoToka;
        
        public PhysicsModel(PhysicsConfig config)
        {
            _moshnost = config.Moshnost;
            _soprotivlenie = config.Soprotivlenie;
            _napryajeniePeremennogoToka = config.NapryajeniePeremennogoToka;

            _napryajeniePostoyannogoToka = Mathf.Sqrt(_moshnost * _soprotivlenie);
            _silaToka = Mathf.Sqrt(_moshnost / _soprotivlenie);
        }
    }
}