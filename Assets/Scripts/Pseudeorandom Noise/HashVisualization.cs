using UnityEngine;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;

using static Unity.Mathematics.math;

namespace Another
{
    public class HashVisualization : MonoBehaviour
    {
        [BurstCompile(FloatPrecision.Standard, FloatMode.Fast, CompileSynchronously = true)]
        struct HashJob : IJobFor
        {
            [WriteOnly]
            public NativeArray<uint> hashes;

            public void Execute(int i)
            {
                // hashes[i] = (uint)i;
            }
        }
    }
}