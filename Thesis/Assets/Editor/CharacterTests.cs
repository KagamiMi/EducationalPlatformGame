using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterTests {

	//[Test]
	//public void CharacterTestsSimplePasses() {
	//	// Use the Assert class to test conditions.
	//}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	//[UnityTest]
	//public IEnumerator CharacterTestsWithEnumeratorPasses() {
	//	// Use the Assert class to test conditions.
	//	// yield to skip a frame
	//	yield return null;
	//}

    [UnityTest]
    public IEnumerator GotAllComponents_WhenTagCharacterMatches()
    {
        var girlCharacterPrefab = Resources.Load("GirlCharacter");
        var character = new GameObject().AddComponent<Character>();
        PlayerPrefs.SetString("character","DZIEWCZYNKA");
        yield return null;
        Assert.AreEqual(character.enabled,true);
    }
}
