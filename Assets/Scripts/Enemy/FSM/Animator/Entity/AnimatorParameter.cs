using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorParameter
{
    public static class Combact
    {
        public static string Parameter { get; } = "WeaponType";

        public enum WeaponTree
        {
            AXE = -1,
            HAMMER = -2,
            SPEAR = -3,
        }

        public static class AxeTree
        {
            public static string Parameter { get; } = "WeaponAttack";
            public enum AttackTree
            {
                FIRST = 0,
                LAST = 1,
            }
        }

        public static class SpearTree
        {
            public static string Parameter { get; } = "WeaponAttack";
            public enum AttackTree
            {
                FIRST = 0,
                LAST = 0,
            }
        }

        public static class HammerTree
        {
            public static string Parameter { get; } = "WeaponAttack";
            public enum AttackTree
            {
                FIRST = 0,
                LAST = 1,
            }
        }

        internal static string GetParameter(int weaponType)
        {
            switch (weaponType)
            {
                case (int)WeaponTree.AXE:
                    return AxeTree.Parameter;

                case (int)WeaponTree.HAMMER:
                    return HammerTree.Parameter;

                case (int)WeaponTree.SPEAR:
                    return SpearTree.Parameter;

                default:
                    return AxeTree.Parameter;
            }
        }

        internal static float GetRandomAttack(int weaponType)
        {
            switch (weaponType)
            {
                case (int)WeaponTree.AXE:
                    return UnityEngine.Random
                        .Range((int)AxeTree.AttackTree.FIRST,
                        (int)AxeTree.AttackTree.LAST);

                case (int)WeaponTree.HAMMER:
                    return UnityEngine.Random
                        .Range((int)HammerTree.AttackTree.FIRST,
                        (int)HammerTree.AttackTree.LAST);

                case (int)WeaponTree.SPEAR:
                    return UnityEngine.Random
                        .Range((int)SpearTree.AttackTree.FIRST,
                        (int)SpearTree.AttackTree.LAST);

                default:
                    return (int)AxeTree.AttackTree.FIRST;
            }
        }
    }

    public static class Reaction
    {
        public static string Parameter { get; } = "Reaction";

        public enum ReactionTree
        {
            IDLE_TREE = -1,
            INDICATE = 0,
            VICTORY = 1,
            SEEK = 2,
        }

        public class Idle
        {
            public static string Parameter { get; } = "IdleType";
            public enum IdleTree
            {
                FIRST = 0,
                LAST = 1,
            }
        }
    }

    public static class Motion
    {
        public static string Parameter { get; } = "MotionType";

        public enum MotionTree
        {
            WALK = 0,
            WALK_ARMED = 1,
            RUN = 2,
        }
    }

    public static class Transition
    {
        public const string IS_COMBACT_STATE = "IsCombactState";
        public const string IS_IDLE_STATE = "IsIdleState";
        public const string COMBACT_MOVE = "CombactMove";
        public const string IDLE_TRIGGER = "Idle";
    }
}
