using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class SnowManManeger : MonoBehaviour {
	
	[SerializeField]
	private GameObject _brokenParticle;
	
	private ScoreManeger _scoreManeger;
	private StageManeger _stageManeger;
	
	// Use this for initialization
	void Start () {
		GameObject stageRoot = transform.parent.parent.gameObject;
		_scoreManeger = stageRoot.GetComponentInChildren<ScoreManeger>();
		_stageManeger = stageRoot.GetComponent<StageManeger>();
		
		
		//*
		HOTween.To(this.transform, 0.5f, new TweenParms()
            .Prop("localPosition", new Vector3(0, 0.2f, 0), true) // Position tween (set as relative)
            .Loops(-1, LoopType.Yoyo) // Infinite yoyo loops
            .Ease(EaseType.EaseInBounce) // Ease
        );
        /**/
		
		/*
		//Sequence sequence = new Sequence(new SequenceParms().Loops(-1, LoopType.Restart));
		Sequence sequence = new Sequence(new SequenceParms());
        // "Append" will add a tween after the previous one/s have completed
		//sequence.Append(HOTween.To(this.transform, 0.2f, new TweenParms().Prop("localPosition", new Vector3(0, 0, 0), true).Ease(EaseType.EaseOutExpo)));
        sequence.Append(HOTween.To(this.transform, 0.2f, new TweenParms().Prop("localPosition", new Vector3(0, 1, 0), true).Ease(EaseType.EaseOutSine)));
        sequence.Append(HOTween.To(this.transform, 0.2f, new TweenParms().Prop("localPosition", new Vector3(0, 0, 0), true).Ease(EaseType.EaseInExpo)));
        
        // "Insert" lets you insert a tween where you want
        // (in this case we're having it start at half the sequence and last until the end)
        //sequence.Insert(sequence.duration * 0.5f, HOTween.To(this.renderer.material, sequence.duration * 0.5f, new TweenParms().Prop("color", colorTo)));
        // Start the sequence animation
        sequence.Play();
        /**/
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collisionInfo) {
		Instantiate(_brokenParticle, transform.position, _brokenParticle.transform.rotation);
		//Instantiate(Detonator-Base, transform.position, _brokenParticle.transform.rotation);
		
		
		// test
		_scoreManeger.AddScore(10);
		_stageManeger.StageEndCheck();
		
		Destroy(gameObject);
	}
}
