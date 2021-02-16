using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GRandom
{
    public static System.Random FixedSeedRandom;

    public static void Initialize( int seed ) {
        FixedSeedRandom = new System.Random( seed );
    }

    /// <returns>Returns a pseudo-random normalized float variable.</returns>
    public static float RandomFloat() {
        return (float)FixedSeedRandom.NextDouble();
    }

    /// <returns>Returns a pseudo-random integer variable.</returns>
    public static int RandomInt() {
        return FixedSeedRandom.Next();
    }

    /// <returns>Returns a pseudo-random integer variable within the given min/max range.</returns>
    public static float RandomInt( int min, int max ) {
        return FixedSeedRandom.Next( min, max );
    }
}


/*
    public static Random FixedSeedRandom;

public static void Initialize( int seed ) {
    FixedSeedRandom = new Random( seed );
}

/// <returns>Returns a pseudo-random normalized float variable.</returns>
public static float RandomFloat() {
    return (float)FixedSeedRandom.NextDouble();
}

/// <returns>Returns a pseudo-random integer variable.</returns>
public static int RandomInt() {
    return FixedSeedRandom.Next();
}

/// <returns>Returns a pseudo-random integer variable within the given min/max range.</returns>
public static float RandomInt( int min, int max ) {
    return FixedSeedRandom( min, max );
}
*/
