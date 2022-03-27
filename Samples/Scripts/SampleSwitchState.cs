using GameMeanMachine.Unity.WindRose.Authoring.Behaviours.Entities.Objects;
using GameMeanMachine.Unity.WindRose.Types;
using UnityEngine;


namespace GameMeanMachine.Unity.WindRose.SpriteUtils
{
    namespace Samples
    {
        [RequireComponent(typeof(MapObject))]
        public class SampleSwitchState : MonoBehaviour
        {
            private float time = 0;
            private int index = 0;
            private MapObject mapObject;
            private State[] states = { State.Get(""), State.Get("alt") };
            
            private void Awake()
            {
                mapObject = GetComponent<MapObject>();
            }

            // Start is called before the first frame update
            void Start()
            {
                mapObject.CurrentState = MapObject.IDLE_STATE;
            }

            // Update is called once per frame
            void Update()
            {
                time += Time.deltaTime;
                if (time >= 4f)
                {
                    time -= 4f;
                    index += 1;
                    if (index == states.Length) index = 0;
                    mapObject.CurrentState = states[index];
                }
            }
        }
    }
}
