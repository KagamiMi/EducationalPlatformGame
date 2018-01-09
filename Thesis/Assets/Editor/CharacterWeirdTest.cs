using UnityEngine;
using UnityEditor;
using NSubstitute;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterWeirdTest {

    [Test]
    public void MoveRight()
    {
        var character = Substitute.For<CharacterActionController>();
        var movementController = Substitute.For<IMovementController>();
        character.SetMovementController(movementController);
        character.MoveRight(1f);

        movementController.Received(1).MoveRight(1f);
    }

	//[Test]
	//public void CharacterSimplePasses() {
	//	// Use the Assert class to test conditions.
	//}

	//// A UnityTest behaves like a coroutine in PlayMode
	//// and allows you to yield null to skip a frame in EditMode
	//[UnityTest]
	//public IEnumerator CharacterWithEnumeratorPasses() {
	//	// Use the Assert class to test conditions.
	//	// yield to skip a frame
	//	yield return null;
	//}
}
