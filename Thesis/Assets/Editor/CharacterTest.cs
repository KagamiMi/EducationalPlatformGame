using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Reflection;

[TestFixture]
public class CharacterTest {

    //[Test]
    //public void NewEditModeTestSimplePasses() {
    //       // Use the Assert class to test conditions.
    //       //var girlCharacterPrefab = Resources.Load("GirlCharacter");
    //       //GameObject gameObject;// = new GameObject();

    //       PlayerPrefs.SetString("character", "DZIEWCZYNKA");
    //       //gameObject = GameObject.Instantiate(Resources.Load("GirlCharacter")) as GameObject;
    //       var character = GameObject.Find("Character").AddComponent<Character>();
    //       character.tag = "CHŁOPIEC";
    //       //Assert.IsNotNull(character, "Did not add Character...");
    //      // var character = GameObject().Find("GirlCharacter").GetComponent<Character>();
    //       MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic|BindingFlags.Instance);
    //       //Assert.IsNotNull(startMethod, "Can't get method");
    //       startMethod.Invoke(character,null);
    //       //yield return null;
    //       Assert.AreEqual(false, character.gameObject.activeSelf);
    //}
    Character character;

    [SetUp] 
    public void Init()
    {
        character = GameObject.Find("Character").AddComponent<Character>();
    }

    [UnityTest]
    public IEnumerator Collider_Test()
    {
        GameObject collider = new GameObject();
        SphereCollider sphereCollider = collider.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        collider.tag = "broccoli";

        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);

        startMethod.Invoke(character, null);
        yield return null;
        //Assert.IsNotNull(sphereCollider, "no go");
        MethodInfo triggerMethod = character.GetType().GetMethod("OnTriggerEnter", BindingFlags.NonPublic | BindingFlags.Instance);
        //Assert.IsNotNull(triggerMethod, "no collider");
        triggerMethod.Invoke(character, new object[] { sphereCollider});
        yield return null;
        Assert.AreEqual(false, collider.activeSelf);

    }


    [Test]
    public void ObjectActive_WhenTheSameTag_Girl()
    {

        PlayerPrefs.SetString("character", "DZIEWCZYNKA");
        character.tag = "DZIEWCZYNKA";
        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
       
        startMethod.Invoke(character, null);
 
        Assert.AreEqual(true, character.gameObject.activeSelf);
    }

    [Test]
    public void ObjectActive_WhenTheSameTag_Boy()
    {
        PlayerPrefs.SetString("character", "CHŁOPIEC");
        character.tag = "CHŁOPIEC";
        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        startMethod.Invoke(character, null);
        Assert.AreEqual(true, character.gameObject.activeSelf);
    }

    [Test]
    public void ObjectInactive_NoTag()
    {
        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        startMethod.Invoke(character, null);
        Assert.AreEqual(false, character.gameObject.activeSelf);
    }

    [Test]
    public void ObjectInactive_WhenOtherTag_Girl()
    {
        PlayerPrefs.SetString("character", "DZIEWCZYNKA");
        character.tag = "CHŁOPIEC";
        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        startMethod.Invoke(character, null);
        Assert.AreEqual(false, character.gameObject.activeSelf);
    }

    [Test]
    public void ObjectInactive_WhenOtherTag_Boy()
    {
        PlayerPrefs.SetString("character", "CHŁOPIEC");
        character.tag = "DZIEWCZYNKA";
        MethodInfo startMethod = character.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
        startMethod.Invoke(character, null);
        Assert.AreEqual(false, character.gameObject.activeSelf);
    }

    [TearDown]
    public void CleanUp()
    {
        PlayerPrefs.DeleteKey("character");
        character.gameObject.SetActive(true);
    }
    //[UnityTest]
    //public 

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    //[UnityTest]
    //public IEnumerator NewEditModeTestWithEnumeratorPasses() {
    //	// Use the Assert class to test conditions.
    //	// yield to skip a frame
    //	yield return null;
    //}
}



