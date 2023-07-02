using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlephVault.Unity.Layout.Utils;
using AlephVault.Unity.SpriteUtils.Types;
using AlephVault.Unity.Support.Utils;
using AlephVault.Unity.WindRose.Authoring.ScriptableObjects.VisualResources;
using AlephVault.Unity.WindRose.Types;
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
            ///   An oriented & animated selector involves a list of sprites per direction.
            ///   It uses a custom pivot instead of bottom-left.
            /// </summary>
            public class RoseAnimatedPivotedSelection : MappedSpriteGridSelection<
                Tuple<RoseTuple<ReadOnlyCollection<Vector2Int>>, Vector2>, AnimationRose
            >
            {
                // The FPS to use for the selection.
                private uint fps;

                public RoseAnimatedPivotedSelection(
                    SpriteGrid sourceGrid, Tuple<RoseTuple<ReadOnlyCollection<Vector2Int>>, Vector2> selection,
                    uint framesPerSecond
                ) : base(sourceGrid, selection)
                {
                    if (selection == null) throw new ArgumentNullException(nameof(selection));
                    fps = Values.Max(1u, framesPerSecond);
                }

                /// <summary>
                ///   The validation and mapping process involves a list of sprites
                ///   from a list of vector for each direction.
                /// </summary>
                /// <param name="sourceGrid">The grid to validate against</param>
                /// <param name="selection">The positions rose tuple to select</param>
                /// <returns>The mapped WindRose animation rose</returns>
                protected override AnimationRose ValidateAndMap(
                    SpriteGrid sourceGrid, Tuple<RoseTuple<ReadOnlyCollection<Vector2Int>>, Vector2> selection
                )
                {
                    if (selection.Item1.Up == null || selection.Item1.Left == null || selection.Item1.Right == null ||
                        selection.Item1.Down == null)
                    {
                        throw new ArgumentException(
                            $"A null value was given to the sprite list rose tuple in one of the fields"
                        );
                    }
                    
                    AnimationRose animationRose = ScriptableObject.CreateInstance<AnimationRose>();
                    Behaviours.SetObjectFieldValues(animationRose, new Dictionary<string, object>() {
                        { "up", MakeAnimation(from position in selection.Item1.Up
                                              select ValidateAndMapSprite(sourceGrid, position, selection.Item2)) },
                        { "down", MakeAnimation(from position in selection.Item1.Down
                                                select ValidateAndMapSprite(sourceGrid, position, selection.Item2)) },
                        { "left", MakeAnimation(from position in selection.Item1.Left
                                                select ValidateAndMapSprite(sourceGrid, position, selection.Item2)) },
                        { "right", MakeAnimation(from position in selection.Item1.Right
                                                 select ValidateAndMapSprite(sourceGrid, position, selection.Item2)) },
                    });
                    return animationRose;
                }
                
                // Creates an animation object.
                private Animation MakeAnimation(IEnumerable<Sprite> sprites)
                {
                    Animation result = ScriptableObject.CreateInstance<Animation>();
                    Behaviours.SetObjectFieldValues(result, new Dictionary<string, object> {
                        { "sprites", sprites.ToArray() }, { "fps", fps }
                    });
                    return result;
                }
                
                ~RoseAnimatedPivotedSelection()
                {
                    if (result != null)
                    {
                        Object.Destroy(result.GetForDirection(Direction.UP));
                        Object.Destroy(result.GetForDirection(Direction.DOWN));
                        Object.Destroy(result.GetForDirection(Direction.LEFT));
                        Object.Destroy(result.GetForDirection(Direction.RIGHT));
                        Object.Destroy(result);
                    }
                }
            }
        }
    }
}