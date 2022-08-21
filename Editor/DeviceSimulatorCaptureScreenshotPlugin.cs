using System;
using System.IO;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    [UsedImplicitly]
    internal sealed class DeviceSimulatorCaptureScreenshotPlugin : DeviceSimulatorPlugin
    {
        public override string title => "Capture Screenshot";

        public override VisualElement OnCreateUI()
        {
            var captureScreenshotButton = new Button
            {
                text = "Capture Screenshot",
            };
            captureScreenshotButton.clicked += () =>
            {
                var setting        = DeviceSimulatorCaptureScreenshotSetting.instance;
                var dateTimeString = DateTime.Now.ToString( setting.DateTimeFormat );
                var filename       = setting.FilenameFormat.Replace( "%DATE_TIME%", dateTimeString );
                var directoryName  = setting.DirectoryName;
                var path           = Path.Combine( directoryName, filename );

                Directory.CreateDirectory( directoryName );
                ScreenCapture.CaptureScreenshot( path );
            };

            var projectSettingsButton = new Button
            {
                text = "Project Settings",
            };
            projectSettingsButton.clicked += () =>
            {
                var path = DeviceSimulatorCaptureScreenshotSettingProvider.PATH;
                SettingsService.OpenProjectSettings( path );
            };

            var root = new VisualElement();
            root.Add( captureScreenshotButton );
            root.Add( projectSettingsButton );

            return root;
        }
    }
}