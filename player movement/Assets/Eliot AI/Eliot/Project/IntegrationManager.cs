#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;

namespace Eliot
{
    /// <summary>
    /// Responsible for configuring the project so that it is ready to seamlessly work
    /// together with integrated assets if they are installed. Or to work as if no
    /// additional code is there.
    /// </summary>
    [InitializeOnLoad] public class IntegrationManager
    {
        /// <summary>
        /// Do this on project recompilation
        /// </summary>
        static IntegrationManager()
        {
            SetupPackage("Eliot", "ELIOT");
            SetupPackage("Pathfinding", "ASTAR_EXISTS");
        }

        /// <summary>
        /// Get project ready for a third-party package
        /// </summary>
       private static void SetupPackage(string @namespace, string directiveName)
        {
            // Search for Pathfinding namespace in the project
            var namespaceFound = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.Namespace == @namespace
                select type).Any(); 

            // If found, get build target platform
            var buildTargetGroup =  BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
            
            // Check if we already added needed #define preprocessor directive
            var existingSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            if (existingSymbols.Contains(directiveName))
            {
                if (!namespaceFound)
                {
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup,
                        existingSymbols.Replace(directiveName, ""));
                    return;
                }
                return;
            }

            if (namespaceFound)
            {
                // If not, add it now
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup,
                    existingSymbols + (";" + directiveName));
            }
        }
    }
}
#endif