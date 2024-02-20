using UnityEngine;

namespace T1.Controllers
{
	public class CameraController : SingletonMono<CameraController>
	{
		[SerializeField] private Transform center;
		private float _oldTouchDeltaX = 0;
		private float _oldTouchDeltaY = 0;


		public void SetCenter(Transform center)
			=> this.center = center;

		private void Update()
		{
			if (Input.touchCount == 2)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Moved)
				{
					float touchDeltaX = touch.deltaPosition.x;
					float touchDeltaY = touch.deltaPosition.y;

					transform.position += (_oldTouchDeltaY - touchDeltaY) * Time.deltaTime * transform.forward;
					transform.position += (_oldTouchDeltaX - touchDeltaX) * Time.deltaTime * transform.right;

					_oldTouchDeltaX = touchDeltaX;
					_oldTouchDeltaY = touchDeltaY;
				}
				_oldTouchDeltaX = 0;
				_oldTouchDeltaY = 0;
				transform.LookAt(center);
			}
		}
	}
}