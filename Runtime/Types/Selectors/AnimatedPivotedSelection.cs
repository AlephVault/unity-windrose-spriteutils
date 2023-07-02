using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlephVault.Unity.Layout.Utils;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.Support.Utils;
using UnityEngine;
using Animation = AlephVault.Unity.WindRose.Authoring.ScriptableObjects.VisualResources.Animation;
using Object = UnityEngine.Object;


namespace AlephVault.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        namespace Selectors
        {
            /// <summary>
            ///   A simple & animated selector involves a list of sprites.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class AnimatedPivotedSelection : MappedSpriteGridSelection<
                Tuple<ReadOnlyCollection<Vector2Int>, Vector2>, Animation
            >
            {
                // The FPS to use for the selection.
                private uint fps;
                
                public AnimatedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<ReadOnlyCollection<Vector2Int>, Vector2> selection,
                    uint framesPerSecond
                ) : base(sourceGrid, selection)
                {
                    if (selection == null) throw new ArgumentNullException(nameof(selection));
                    fps = Values.Max(1u, framesPerSecond);
                }

                /// <summary>
                ///   The validation and mapping process involves a list of sprites
                ///   from a list of vector.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The positions to select, and the pivot</param>
                /// <returns>The mapped WindRose animation</returns>
                protected override Animation ValidateAndMap(SpriteGrid sourceGrid, Tuple<ReadOnlyCollection<Vector2Int>, Vector2> selection)
                {
                    Sprite[] sprites = (from position in selection.Item1
                                        select ValidateAndMapSprite(sourceGrid, position, selection.Item2)).ToArray();
                    Animation result = ScriptableObject.CreateInstance<Animation>();
                    Behaviours.SetObjectFieldValues(result, new Dictionary<string, object> {
                        { "sprites", sprites }, { "fps", fps }
                    });
                    return result;
                }

                ~AnimatedPivotedSelection()
                {
                    if (result != null) Object.Destroy(result);
                }
            }
        }
    }
}