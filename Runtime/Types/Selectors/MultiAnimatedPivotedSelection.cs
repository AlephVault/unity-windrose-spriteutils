using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlephVault.Unity.Layout.Utils;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.Support.Utils;
using GameMeanMachine.Unity.WindRose.Authoring.Behaviours.Entities.Visuals.StateBundles;
using GameMeanMachine.Unity.WindRose.Types;
using UnityEngine;
using Animation = GameMeanMachine.Unity.WindRose.Authoring.ScriptableObjects.VisualResources.Animation;
using Object = UnityEngine.Object;


namespace GameMeanMachine.Unity.WindRose.SpriteUtils
{
    namespace Types
    {
        namespace Selectors
        {
            /// <summary>
            ///   A multi-state & animated selector involves a list of sprites per state.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class MultiAnimatedPivotedSelection : MappedSpriteGridSelection<
                Tuple<MultiSettings<ReadOnlyCollection<Vector2Int>>, Vector2>, MultiSettings<Animation>
            >
            {
                // The FPS to use for the selection.
                private uint fps;
                
                public MultiAnimatedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<MultiSettings<ReadOnlyCollection<Vector2Int>>, Vector2> selection,
                    uint framesPerSecond
                ) : base(sourceGrid, selection)
                {
                    if (selection == null) throw new ArgumentNullException(nameof(selection));
                    fps = Values.Max(1u, framesPerSecond);
                }

                /// <summary>
                ///   Validates and maps a dictionary of <see cref="Type"/> => <see cref="ReadOnlyCollection{Vector2Int}"/>.
                ///   Each value must be valid and each type must be a subclass of <see cref="SpriteBundle"/>.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The positions lists to select (mapped from type), and the pivot</param>
                /// <returns>The mapped WindRose animation (mapped from type, and idle state)</returns>
                protected override MultiSettings<Animation> ValidateAndMap(SpriteGrid sourceGrid, Tuple<MultiSettings<ReadOnlyCollection<Vector2Int>>, Vector2> selection)
                {
                    MultiSettings<Animation> mapping = new MultiSettings<Animation>();
                    foreach (KeyValuePair<State, ReadOnlyCollection<Vector2Int>> pair in selection.Item1)
                    {
                        if (pair.Value == null) throw new ArgumentException(
                            $"A null value was given to the sprite list by key: {pair.Key}"
                        );

                        mapping[pair.Key] = ValidateAndMapAnimation(sourceGrid, pair.Value, selection.Item2);
                    }

                    return mapping;
                }

                // Maps an entire animation from the input positions and the sprite grid.
                private Animation ValidateAndMapAnimation(
                    SpriteGrid sourceGrid, ReadOnlyCollection<Vector2Int> value, Vector2 pivot
                )
                {
                    Sprite[] sprites = (from position in value
                                        select ValidateAndMapSprite(sourceGrid, position, pivot)).ToArray();
                    Animation animation = ScriptableObject.CreateInstance<Animation>();
                    Behaviours.SetObjectFieldValues(animation, new Dictionary<string, object> {
                        { "sprites", sprites }, { "fps", fps }
                    });
                    return animation;
                }

                ~MultiAnimatedPivotedSelection()
                {
                    if (result != null)
                    {
                        foreach (Animation state in result.Values)
                        {
                            if (state) Object.Destroy(state);
                        }
                    }
                }
            }
        }
    }
}