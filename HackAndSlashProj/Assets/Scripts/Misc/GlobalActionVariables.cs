using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GAV {
    public static class GlobalActionVariables {
        public static float myActivationTime = 0.16f;
    }
    public static class GlobalCharacterVariables {
        public enum CharState { Normal, Stunned, LAttack, HAttack, LDefend, HDefend, LSpecial, HSpecial }
    }
}
