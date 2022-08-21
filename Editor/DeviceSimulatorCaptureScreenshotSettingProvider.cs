using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class DeviceSimulatorCaptureScreenshotSettingProvider : SettingsProvider
    {
        public const string PATH = "Kogane/Device Simulator Capture Screenshot";

        private Editor m_editor;

        private DeviceSimulatorCaptureScreenshotSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = DeviceSimulatorCaptureScreenshotSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            DeviceSimulatorCaptureScreenshotSetting.instance.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new DeviceSimulatorCaptureScreenshotSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}