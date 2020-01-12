﻿using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
	public class NaughtyPropertyDrawer : PropertyDrawer
	{
		public float GetPropertyHeight(SerializedProperty property)
		{
			return EditorGUI.GetPropertyHeight(property, true);
		}

		public float GetHelpBoxHeight()
		{
			return EditorGUIUtility.singleLineHeight * 3.0f;
		}

		public void DrawDefaultPropertyAndHelpBox(Rect rect, SerializedProperty property, string message, MessageType messageType)
		{
			Rect helpBoxRect = new Rect(
					rect.x,
					rect.y,
					rect.width,
					GetHelpBoxHeight() - 2.0f);

			EditorGUIExtensions.HelpBox(helpBoxRect, message, MessageType.Warning, property.serializedObject.targetObject);

			Rect propertyRect = new Rect(
				rect.x,
				rect.y + GetHelpBoxHeight(),
				rect.width,
				GetPropertyHeight(property));

			EditorGUI.PropertyField(propertyRect, property, true);
		}
	}
}
