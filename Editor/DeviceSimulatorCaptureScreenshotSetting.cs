using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/DeviceSimulatorCaptureScreenshot.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class DeviceSimulatorCaptureScreenshotSetting : ScriptableSingleton<DeviceSimulatorCaptureScreenshotSetting>
    {
        [SerializeField] private string m_directoryName  = "DeviceSimulatorCaptureScreenshot";
        [SerializeField] private string m_dateTimeFormat = "yyyy-MM-dd_HHmmss";
        [SerializeField] private string m_filenameFormat = "%DATE_TIME%.png";

        public string DirectoryName  => m_directoryName;
        public string DateTimeFormat => m_dateTimeFormat;
        public string FilenameFormat => m_filenameFormat;

        public void Save()
        {
            Save( true );
        }
    }
}