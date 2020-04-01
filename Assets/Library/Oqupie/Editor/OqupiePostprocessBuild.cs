#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;

namespace Oqupie
{
    public class OqupiePostprocessBuild
    {


        [PostProcessBuild(100)]
        public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
        {
            if (buildTarget == BuildTarget.iOS)
            {
                string pbxProjectPath = PBXProject.GetPBXProjectPath(path);
                PBXProject pbxProject = new PBXProject();
                pbxProject.ReadFromString(File.ReadAllText(pbxProjectPath));
#if UNITY_2019_3_OR_NEWER
                string targetGuid = pbxProject.GetUnityMainTargetGuid();
#else
                string targetGuid = pbxProject.TargetGuidByName("Unity-iPhone");
#endif

                // Framework Embed
                const string relativeFrameworkFolder = "Library/Oqupie/SDK/iOS";
                const string frameworkName = "OqupieSupportSDK.framework";
                string frameworkPath = Path.Combine(relativeFrameworkFolder, frameworkName);
                string fileGuid = pbxProject.AddFile(frameworkPath, "Frameworks/" + frameworkPath, PBXSourceTree.Sdk);
                pbxProject.AddFileToEmbedFrameworks(targetGuid, fileGuid);
                pbxProject.SetBuildProperty(targetGuid, "LD_RUNPATH_SEARCH_PATHS", "$(inherited) @executable_path/Frameworks");

                // PBXProject 저장
                pbxProject.WriteToFile(pbxProjectPath);

                // plist 수정
                string plistPath = path + "/Info.plist";
                PlistDocument plist = new PlistDocument();
                plist.ReadFromString(File.ReadAllText(plistPath));
                PlistElementDict rootDict = plist.root;

                // Privacy - Photo Library Usage Description
                rootDict.SetString("NSPhotoLibraryUsageDescription", "This app needs to use photo library for file attachment");
                // Privacy - Camera Usage Description
                rootDict.SetString("NSCameraUsageDescription", "This app needs to use camera for file attachment");

                // plist 저장
                File.WriteAllText(plistPath, plist.WriteToString());
            }
        }
    }
}
#endif
