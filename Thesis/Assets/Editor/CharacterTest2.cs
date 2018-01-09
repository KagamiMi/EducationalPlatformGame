using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterTest2 {

	[Test]
	public void CharacterTest2SimplePasses() {
        //EditorSceneManager.OpenScene("Assets/gameScene.unity",OpenSceneMode.Single);
        var gameObject = GameObject.Find("GirlCharacter");
        Assert.IsNotNull(gameObject, "No girl!");
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CharacterTest2WithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
