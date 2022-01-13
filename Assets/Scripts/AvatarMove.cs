using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMove : MonoBehaviour
{
	private Camera _mainCamera;
	private Transform _avatarTransform;
	
	private bool _isJumping;
	private float _avatarYSpeed;
	private float _avatarZSpeed;
	private float _avatarLeftLimit=-1f;
	private float _avatarRightLimit=1f;
	private float _avatarNewPosition = 0;
	private float _avatarModificator = 0.2f;
	private float _multiplier = 2.655f;

	private void Start()
    {
	    _avatarYSpeed = 1 * Time.fixedDeltaTime;
	    _avatarZSpeed = 2 * Time.fixedDeltaTime;
	    _mainCamera = Camera.main;
	    _avatarTransform = transform;

    }

	private void Update()
	{
		if (SwipeController.Tap && !_isJumping) 
		{
			_isJumping = true;
		}
		
		if (SwipeController.SwipeRight && _avatarNewPosition!=_avatarRightLimit)
		{
			_avatarNewPosition +=_avatarModificator ;
			_avatarTransform.position = new Vector3(_avatarNewPosition * _multiplier, _avatarTransform.position.y,
				_avatarTransform.position.z);
		}
		else if (SwipeController.SwipeLeft && _avatarNewPosition != _avatarLeftLimit)
		{
			_avatarNewPosition -= _avatarModificator;
			_avatarTransform.position = new Vector3(_avatarNewPosition * _multiplier, _avatarTransform.position.y,
				_avatarTransform.position.z);
		}
	}
    private void FixedUpdate()
    {
	    if (_isJumping)
	    {
		    transform.position = new Vector3(transform.position.x, transform.position.y + _avatarYSpeed,
			    transform.position.z + _avatarZSpeed);
		    _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y + _avatarYSpeed,
			    _mainCamera.transform.position.z + _avatarZSpeed);
	    }

    }

}
